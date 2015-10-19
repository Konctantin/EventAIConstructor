using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EventIAConstructor.Common.Controls
{
    public class EnumComboBox : ComboBox
    {
        public static DependencyProperty SelectedEnumValueProperty = DependencyProperty.Register("SelectedEnumValue", typeof(int), typeof(EnumComboBox),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedEnumValuePropertyChanged, null, true, UpdateSourceTrigger.PropertyChanged));

        public static DependencyProperty EnumSourceProperty = DependencyProperty.Register("EnumSource", typeof(Type), typeof(EnumComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnEnumSourcePropertyChanged, null, true, UpdateSourceTrigger.PropertyChanged));

        static void OnSelectedEnumValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var control = d as EnumComboBox;
                var items = control.ItemsSource as IEnumerable<EnumComboBoxItem>;
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        if (item.Value == (int)e.NewValue)
                        {
                            control.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        static void OnEnumSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var control = d as EnumComboBox;
                var type = e.NewValue as Type;

                if (type != null)
                {
                    var list = new List<EnumComboBoxItem>();
                    foreach (var item in Enum.GetValues(type))
                        list.Add(new EnumComboBoxItem((int)item, item));

                    control.ItemsSource = list;

                    // stuff
                    foreach (var item in list)
                    {
                        if (item.Value == control.SelectedEnumValue)
                        {
                            control.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        public int SelectedEnumValue
        {
            get { return (int)GetValue(SelectedEnumValueProperty); }
            set { SetValue(SelectedEnumValueProperty, value); }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            SelectedEnumValue = (SelectedValue as EnumComboBoxItem)?.Value ?? 0;
            base.OnSelectionChanged(e);
        }

        public Type EnumSource
        {
            get { return (Type)GetValue(EnumSourceProperty); }
            set { SetValue(EnumSourceProperty, value); }
        }
    }

    public class EnumComboBoxItem
    {
        public int Value { get; private set; }
        public object Name { get; private set; }

        public EnumComboBoxItem(int value, object name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString()
        {
            return $"^{Value,-10} {Name}";
        }
    }
}