using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EventIAConstructor.Controls
{
    public class EnumComboBox : ComboBox
    {
        public static DependencyProperty SelectedEnumValueProperty = DependencyProperty.Register("SelectedEnumValue", typeof(int), typeof(EnumComboBox),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedEnumValuePropertyChanged, null, true, UpdateSourceTrigger.PropertyChanged));

        public static DependencyProperty EnumSourceProperty = DependencyProperty.Register("EnumSource", typeof(Type), typeof(EnumComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnEnumSourcePropertyChanged, null, true, UpdateSourceTrigger.PropertyChanged));

        private static void OnSelectedEnumValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var control = d as EnumComboBox;
                if (control.EnumSource != null)
                {
                    foreach (var item in Enum.GetValues(control.EnumSource))
                    {
                        if ((int)item == (int)e.NewValue)
                        {
                            control.SelectedValue = item;
                        }
                    }
                }
            }
        }

        private static void OnEnumSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var control = d as EnumComboBox;
                var type = e.NewValue as Type;

                if (type != null)
                {
                    var list = new List<object>();
                    foreach (var item in Enum.GetValues(type))
                        list.Add(item);

                    control.ItemsSource = list;

                    // stuff
                    foreach (var item in Enum.GetValues(control.EnumSource))
                    {
                        if ((int)item == control.SelectedEnumValue)
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
            SelectedEnumValue = (int)(SelectedValue ?? 0);
            SetValue(SelectedEnumValueProperty, (int)(SelectedValue ?? 0));
            base.OnSelectionChanged(e);
        }

        public Type EnumSource
        {
            get { return (Type)GetValue(EnumSourceProperty); }
            set { SetValue(EnumSourceProperty, value); }
        }
    }
}
