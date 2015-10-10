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
                if (control.ItemsSource != null)
                {
                    foreach (var item in control.ItemsSource as IEnumerable<EnumComboBoxItem>)
                    {
                        if (item.Value == (int)e.NewValue)
                        {
                            control.SelectedValue = item;
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
                        list.Add(new EnumComboBoxItem((int)item, item.ToString()));

                    control.ItemsSource = list;

                    // stuff
                    foreach (var item in list)
                    {
                        if (item.Value == control.SelectedEnumValue)
                        {
                            control.SelectedValue = item;
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
            var item = SelectedValue as EnumComboBoxItem;
            SelectedEnumValue = item?.Value ?? 0;
            SetValue(SelectedEnumValueProperty, item?.Value ?? 0);
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
        public string Name { get; private set; }

        public EnumComboBoxItem(int value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}