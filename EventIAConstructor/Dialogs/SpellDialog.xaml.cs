using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EventIAConstructor.Dialogs
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

        int IDialog.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
