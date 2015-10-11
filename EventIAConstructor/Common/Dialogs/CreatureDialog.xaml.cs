using System.Windows;
using System.Windows.Input;

namespace EventIAConstructor.Common.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для Creature.xaml
    /// </summary>
    public partial class CreatureDialog : Window, IDialog
    {
        public CreatureDialog()
        {
            InitializeComponent();
        }

        public int Id { get; set; }

        void CommandBinding_Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }

        void CommandBinding_Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}