using System.Windows;

namespace EventIAConstructor.Common.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для SpellDialog.xaml
    /// </summary>
    public partial class SpellDialog : Window, IDialog
    {
        public SpellDialog()
        {
            InitializeComponent();
        }

        int IDialog.Id { get; set; }
    }
}