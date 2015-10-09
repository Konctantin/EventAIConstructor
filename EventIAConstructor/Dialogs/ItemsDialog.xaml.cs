using System.Windows;

namespace EventIAConstructor.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для ItemsDialog.xaml
    /// </summary>
    public partial class ItemsDialog : Window, IDialog
    {
        public ItemsDialog()
        {
            InitializeComponent();
        }

        int IDialog.Id { get; set; }
    }
}