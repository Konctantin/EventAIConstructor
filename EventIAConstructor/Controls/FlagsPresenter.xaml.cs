using System;
using System.Windows;
using System.Windows.Controls;

namespace EventIAConstructor.Controls
{
    /// <summary>
    /// Логика взаимодействия для FlagsPresenter.xaml
    /// </summary>
    public partial class FlagsPresenter : UserControl
    {
        public event EventHandler ChechedChanged;

        #region HeaderProperty

        public static DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(FlagsPresenter), new PropertyMetadata(null));

        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        #endregion

        #region DataSource

        public static DependencyProperty DataSourceProperty = 
            DependencyProperty.Register("DataSource", typeof(Type), typeof(FlagsPresenter),
                new PropertyMetadata(default(Type), DataSourcePropertyChanged));

        public Type DataSource
        {
            get { return (Type)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        private static void DataSourcePropertyChanged(DependencyObject dependecyObject, DependencyPropertyChangedEventArgs e)
        {
            var flagsPresenter = dependecyObject as FlagsPresenter;
            if (flagsPresenter != null && e.NewValue != e.OldValue)
            {
                flagsPresenter.panel.Children.Clear();
                if (e.NewValue != null && ((Type)e.NewValue).IsEnum)
                {
                    foreach (var enumValue in Enum.GetValues((Type)e.NewValue))
                    {
                        var checkBox = new CheckBox();

                        #warning todo: get name form resources
                        checkBox.Content = enumValue.ToString();

                        checkBox.Tag = enumValue;

                        checkBox.Checked += (o, r) =>
                        {
                            var val = (int)flagsPresenter.GetValue(ValueProperty);
                            var flagValue = (int)(o as CheckBox).Tag;
                            val |= flagValue;

                            if (flagValue == 0u)
                                val = 0;

                            flagsPresenter.SetValue(ValueProperty, val);
                            if (flagsPresenter.ChechedChanged != null)
                                flagsPresenter.ChechedChanged(o, new EventArgs());
                        };

                        checkBox.Unchecked += (o, r) =>
                        {
                            var val = (int)flagsPresenter.GetValue(ValueProperty);
                            val &= ~(int)(o as CheckBox).Tag;

                            flagsPresenter.SetValue(ValueProperty, val);
                            if (flagsPresenter.ChechedChanged != null)
                                flagsPresenter.ChechedChanged(o, new EventArgs());
                        };

                        flagsPresenter.panel.Children.Add(checkBox);
                    }
                } 
            }
        }

        #endregion

        #region Value

        public static DependencyProperty ValueProperty = 
            DependencyProperty.Register("Value", typeof(int), typeof(FlagsPresenter),
                new PropertyMetadata(0, ValuePropertyChanged));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValuePropertyChanged(DependencyObject dependecyObject, DependencyPropertyChangedEventArgs e)
        {
            var flagsPresenter = dependecyObject as FlagsPresenter;
            if (flagsPresenter != null && e.NewValue != e.OldValue)
            {
                foreach (CheckBox checkBox in flagsPresenter.panel.Children)
                {
                    var isChecked = ((int)e.NewValue & (int)checkBox.Tag) != 0;

                    if ((int)checkBox.Tag == 0 && (int)e.NewValue == 0)
                        isChecked = true;

                    if (checkBox.IsChecked != isChecked)
                        checkBox.SetValue(CheckBox.IsCheckedProperty, isChecked);
                }
            }
        }

        #endregion

        public FlagsPresenter()
        {
            InitializeComponent();
        }
    }
}
