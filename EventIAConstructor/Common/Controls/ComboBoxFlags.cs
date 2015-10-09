using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EventIAConstructor.Common.Controls
{
    public class ComboBoxFlags : ComboBox
    {
        public static DependencyProperty SelectedFlagProperty = DependencyProperty.Register("SelectedFlag", typeof(int), typeof(ComboBoxFlags),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedFlagPropertyPropertyChanged, null, true, System.Windows.Data.UpdateSourceTrigger.PropertyChanged));

        public static DependencyProperty FlagsSourceProperty = DependencyProperty.Register("FlagsSource", typeof(Type), typeof(ComboBoxFlags),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnFlagsSourcePropertyChanged, null, true, System.Windows.Data.UpdateSourceTrigger.PropertyChanged));

        private static void OnSelectedFlagPropertyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var control = d as ComboBoxFlags;
                var flag = (int)e.NewValue;
                if (control.ItemsSource is List<ComboBoxFlagsItem>)
                {
                    foreach (ComboBoxFlagsItem item in control.ItemsSource)
                    {
                        item.IsChecked = (flag & item.RawValue) != 0;
                    }
                }
            }
        }

        private static void OnFlagsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var control = d as ComboBoxFlags;
                if (e.NewValue == null)
                    control.ItemsSource = null;
                else
                {
                    var list = new List<ComboBoxFlagsItem>();
                    foreach (var element in Enum.GetValues((Type)e.NewValue))
                    {
                        var isChecked = (control.SelectedFlag & (int)element) != 0;
                        list.Add(new ComboBoxFlagsItem(control, element, isChecked));
                    }
                    control.ItemsSource = list;
                }
            }
        }

        public int SelectedFlag
        {
            get { return (int)GetValue(SelectedFlagProperty); }
            set { SetValue(SelectedFlagProperty, value); }
        }

        public Type FlagsSource
        {
            get { return (Type)GetValue(FlagsSourceProperty); }
            set { SetValue(FlagsSourceProperty, value); }
        }
    }

    public class ComboBoxFlagsItem : BaseViewModel
    {
        public ComboBoxFlagsItem(ComboBoxFlags control, object value, bool isChecked)
        {
            this.control = control;
            this.isChecked = isChecked;
            RawValue = (int)value;
            Value = value;
        }

        private ComboBoxFlags control;

        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChanged();
                    if (value)
                        control.SelectedFlag |= RawValue;
                    else
                        control.SelectedFlag &= ~RawValue;
                }
            }
        }

        public int RawValue { get; set; }

        public object Value { get; set; }
    }
}