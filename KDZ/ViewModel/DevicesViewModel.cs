using KDZ.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KDZ.ViewModel
{
    class DevicesViewModel: DependencyObject
    {


        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(DevicesViewModel), new PropertyMetadata("", FilterText_Chanded));

        private static void FilterText_Chanded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as DevicesViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterDevice;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(ICollectionView), new PropertyMetadata(null));

        public DevicesViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(Device.GetDevices());
            Items.Filter = FilterDevice;
        }

        private bool FilterDevice(object obj)
        {
            bool result = true;
            Device current = obj as Device;
            if  (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.Name.Contains(FilterText) && !current.Problem.Contains(FilterText))
            {
                result = false;
            }
            return result;
        }

    }
}
