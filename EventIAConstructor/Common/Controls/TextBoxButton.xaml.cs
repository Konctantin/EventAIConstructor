using EventIAConstructor.Common.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EventIAConstructor.Common.Controls
{
    /// <summary>
    /// Логика взаимодействия для TextBoxButton.xaml
    /// </summary>
    public partial class TextBoxButton : UserControl
    {
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",
            typeof(int),
            typeof(TextBoxButton),
            new FrameworkPropertyMetadata(
                0,
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

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public Type DialogType
        {
            get { return (Type)GetValue(DialogTypeProperty); }
            set { SetValue(DialogTypeProperty, value); }
        }

        private void CommandBinding_Play_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (!(DialogType.IsSubclassOf(typeof(Window))))
                throw new Exception();

            var window = (Window)Activator.CreateInstance(DialogType);
            if (!(window is IDialog))
            {
                throw new Exception();
            }

            window.Owner = Application.Current.MainWindow;
            window.Title = textBox.Text;
            (window as IDialog).Id = Value;
            if (window.ShowDialog() == true)
            {
                Value = (window as IDialog).Id;
            }
        }
    }
}