using EventIAConstructor.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace EventIAConstructor.Common.Dialogs
{
    public class CreatureEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для Creature.xaml
    /// </summary>
    public partial class CreatureDialog : Window, IDialog
    {
        public ObservableCollection<CreatureEntry> CreatureList { get; set; } = new ObservableCollection<CreatureEntry>();

        public CreatureDialog()
        {
            InitializeComponent();
            DataContext = CreatureList;
            textBox.Focus();
        }

        public int Id { get; set; }

        void CommandBinding_Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(CreatureList);
            if (view.CurrentItem is CreatureEntry)
            {
                Id = (view.CurrentItem as CreatureEntry).Id;
                DialogResult = true;
            }
        }

        void CommandBinding_Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var conn = new MySqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();
                using (var command = new MySqlCommand("select entry, name from creature_template", conn))
                {
                    var reader = command.ExecuteReader();
                    CreatureList.Clear();

                    while (reader.Read())
                    {
                        CreatureList.Add(new CreatureEntry {
                            Id   = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });

                    }

                    if (Id != 0)
                    {
                        var entry = CreatureList.FirstOrDefault(x => x.Id == Id);
                        list.SelectedItem = entry;
                        list.ScrollIntoView(entry);
                    }
                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (sender as TextBox).Text;
            var view = CollectionViewSource.GetDefaultView(CreatureList);
            if (view != null)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    view.Filter = null;
                }
                else
                {
                    int spellId = 0;
                    if (int.TryParse(text, out spellId))
                    {
                        view.Filter = new Predicate<object>((raw) =>
                        {
                            var entry = raw as CreatureEntry;
                            if (entry == null)
                                return false;
                            return entry.Id == spellId;
                        });
                    }
                    else
                    {
                        view.Filter = new Predicate<object>((raw) =>
                        {
                            var entry = raw as CreatureEntry;
                            if (string.IsNullOrWhiteSpace(entry?.Name))
                                return false;
                            return entry.Name.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) > -1;
                        });
                    }
                }
                view.Refresh();
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(CreatureList);
            if (view.CurrentItem is CreatureEntry)
            {
                Id = (view.CurrentItem as CreatureEntry).Id;
                DialogResult = true;
            }
        }
    }
}