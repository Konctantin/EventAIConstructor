using System.Windows;

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

        int IDialog.Id { get; set; }
    }
}