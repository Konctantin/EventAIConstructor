using System.Windows;

namespace EventIAConstructor.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для GameobjectDialog.xaml
    /// </summary>
    public partial class GameobjectDialog : Window, IDialog
    {
        public GameobjectDialog()
        {
            InitializeComponent();
        }

        int IDialog.Id { get; set; }
    }
}