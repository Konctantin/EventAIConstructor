using System.Windows;
using MySql.Data.MySqlClient;
using EventIAConstructor.EventAI.ViewModel;
using EventIAConstructor.Properties;

namespace EventIAConstructor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var conn = new MySqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();
                using (var command = new MySqlCommand("select * from creature_ai_scripts", conn))
                {
                    var reader = command.ExecuteReader();
                    EventAIDataBase.EventAIList.Clear();

                    while (reader.Read())
                    {
                        var ai = new EventAIModel(
                            reader.GetInt32(0), // id
                            reader.GetInt32(1), // creature id
                            reader.GetInt32(3), // phase mask
                            reader.GetInt32(4), // chance
                            reader.GetInt32(5)  // event flags
                            );
                        var ev = new EventModel(ai,
                            reader.GetInt32(2), // event type
                            reader.GetInt32(6), // event param 1
                            reader.GetInt32(7), // event param 2
                            reader.GetInt32(8), // event param 3
                            reader.GetInt32(9)  // event param 4
                            );

                        var ac = new ActionModel[3];
                        for (int i = 0, j = 0; i < ac.Length; ++i, j+=4)
                        {
                            ac[i] = new ActionModel(ai,
                                reader.GetInt32(10 + j), // action type
                                reader.GetInt32(11 + j), // action param 1
                                reader.GetInt32(12 + j), // action param 2
                                reader.GetInt32(13 + j)  // action param 3
                                );
                        }

                        ai.Comment = reader.GetString(22); // comment

                        ai.Event = ev;
                        ai.Action1 = ac[0];
                        ai.Action2 = ac[1];
                        ai.Action3 = ac[2];

                        ai.IsModifyed = false;

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