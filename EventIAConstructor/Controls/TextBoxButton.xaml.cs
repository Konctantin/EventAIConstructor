using EventIAConstructor.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventIAConstructor.Controls
{
    /// <summary>
    /// Логика взаимодействия для TextBoxButton.xaml
    /// </summary>
    public partial class TextBoxButton : UserControl
    {
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text",
            typeof(string),
            typeof(TextBoxButton),
            new FrameworkPropertyMetadata(
                "",
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                null,
                null,
                true,
                UpdateSourceTrigger.PropertyChanged)
            );

        public static DependencyProperty DialogTypeProperty = DependencyProperty.Register("DialogType", typeof(Type), typeof(TextBoxButton));

        public TextBoxButton()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Type DialogType
        {
            get { return (Type)GetValue(DialogTypeProperty); }
            set { SetValue(DialogTypeProperty, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(DialogType.IsSubclassOf(typeof(Window))))
                throw new Exception();

            var window = (Window)Activator.CreateInstance(DialogType);
            if (!(window is IDialog))
            {
                throw new Exception();
            }
            window.Owner = App.Current.MainWindow;
            window.Title = textBox.Text;
            window.ShowDialog();

            Text = 5.ToString();
        }
    }
}
