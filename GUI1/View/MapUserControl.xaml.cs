using GUI1.Model;
using KaiserMVVMCore;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GUI1.View
{
    public partial class MapUserControl : UserControl
    {
        public static DependencyProperty MapFieldsProperty =
            DependencyProperty.Register(nameof(MapFields), typeof(List<MapField>), typeof(MapUserControl));
        public List<MapField> MapFields { get => (List<MapField>)GetValue(MapFieldsProperty); set => SetValue(MapFieldsProperty, value); }

        public static DependencyProperty GoNorthCommandProperty =
            DependencyProperty.Register(nameof(GoNorthCommand), typeof(RelayCommand), typeof(MapUserControl));
        public RelayCommand GoNorthCommand { get => (RelayCommand)GetValue(GoNorthCommandProperty); set => SetValue(GoNorthCommandProperty, value); }

        public static DependencyProperty GoEastCommandProperty =
            DependencyProperty.Register(nameof(GoEastCommand), typeof(RelayCommand), typeof(MapUserControl));
        public RelayCommand GoEastCommand { get => (RelayCommand)GetValue(GoEastCommandProperty); set => SetValue(GoEastCommandProperty, value); }

        public static DependencyProperty GoSouthCommandProperty =
            DependencyProperty.Register(nameof(GoSouthCommand), typeof(RelayCommand), typeof(MapUserControl));
        public RelayCommand GoSouthCommand { get => (RelayCommand)GetValue(GoSouthCommandProperty); set => SetValue(GoSouthCommandProperty, value); }

        public static DependencyProperty GoWestCommandProperty =
            DependencyProperty.Register(nameof(GoWestCommand), typeof(RelayCommand), typeof(MapUserControl));
        public RelayCommand GoWestCommand { get => (RelayCommand)GetValue(GoWestCommandProperty); set => SetValue(GoWestCommandProperty, value); }

        public MapUserControl()
        {
            InitializeComponent();
        }
    }
}
