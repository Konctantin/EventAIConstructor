using System.Windows;

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

            cbFlags.FlagsSource = typeof(EventAIMetadata.EventFlags);
            cbFlags.SelectedFlag = 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}