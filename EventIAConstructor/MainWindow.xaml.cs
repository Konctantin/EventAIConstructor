using System.Windows;

using MySql.Data;
using MySql.Data.MySqlClient;
using EventIAConstructor.EventAI.ViewModel;
using EventIAConstructor.EventAI.Metadata;

namespace EventIAConstructor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var conn = new MySqlConnection("server=localhost;user id=root; password=mangos; database=mangos; pooling=false"))
            {
                conn.Open();
                using (var command = new MySqlCommand("select * from creature_ai_scripts", conn))
                {
                    var reader = command.ExecuteReader();
                    EventAIDataBase.EventAIList.Clear();
                    while (reader.Read())
                    {
                        var ai = new EventAIModel(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5)
                            );
                        var ev = new EventModel(ai, reader.GetInt32(2),
                            reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
                        var ac = new ActionModel[3];
                        for (int i = 0, j = 0; i < ac.Length; ++i, j+=4)
                        {
                            ac[i] = new ActionModel(ai, reader.GetInt32(10+j),
                                reader.GetInt32(11 + j), reader.GetInt32(12 + j), reader.GetInt32(13 + j));
                        }

                        ai.Event = ev;
                        ai.Action1 = ac[0];
                        ai.Action2 = ac[1];
                        ai.Action3 = ac[2];
                        ai.Comment = reader.GetString(22);

                        EventAIDataBase.EventAIList.Add(ai);
                    }
                }
            }

            if (EventAIDataBase.EventAIList.Count > 0)
            {
                grid.SelectedIndex = 0;
            }
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}