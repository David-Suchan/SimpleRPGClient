using GUI1.Model;
using KaiserMVVMCore;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GUI1.View
{
    /// <summary>
    /// Interaktionslogik für UserStatsUserControl.xaml
    /// </summary>
    public partial class UserStatsUserControl : UserControl
    {
        public static DependencyProperty UsernameProperty =
            DependencyProperty.Register(nameof(Username), typeof(string), typeof(UserStatsUserControl));

        public static DependencyProperty ExperienceProperty =
            DependencyProperty.Register(nameof(Experience), typeof(int), typeof(UserStatsUserControl));

        public static DependencyProperty CurrentHPProperty =
            DependencyProperty.Register(nameof(CurrentHP), typeof(int), typeof(UserStatsUserControl));

        public static DependencyProperty MaxHPProperty = 
            DependencyProperty.Register(nameof(MaxHP), typeof(int), typeof(UserStatsUserControl));

        public static DependencyProperty GoToAbilitiesCommandProperty =
            DependencyProperty.Register(nameof(GoToAbilitiesCommand), typeof(RelayCommand), typeof(UserStatsUserControl));

        public static DependencyProperty IntelligenceProperty =
            DependencyProperty.Register(nameof(Intelligence), typeof(int), typeof(UserStatsUserControl));

        public static DependencyProperty ItemListProperty =
            DependencyProperty.Register(nameof(ItemList), typeof(List<Item>), typeof(UserStatsUserControl));
        
        public static DependencyProperty StrengthProperty =
            DependencyProperty.Register(nameof(Strength), typeof(int), typeof(UserStatsUserControl));

        public string Username { get => (string)GetValue(UsernameProperty); set => SetValue(UsernameProperty, value); }
        public int Experience { get => (int)GetValue(UsernameProperty); set => SetValue(UsernameProperty, value); }
        public int CurrentHP { get => (int)GetValue(CurrentHPProperty); set => SetValue(CurrentHPProperty, value); }
        public int MaxHP { get => (int)GetValue(MaxHPProperty); set => SetValue(MaxHPProperty, value);}
        public int Intelligence { get => (int)GetValue(IntelligenceProperty); set => SetValue(IntelligenceProperty, value); }
        public int Strength { get => (int)GetValue(StrengthProperty); set => SetValue(StrengthProperty, value); }

        public RelayCommand GoToAbilitiesCommand { get => (RelayCommand)GetValue(GoToAbilitiesCommandProperty); set => SetValue(GoToAbilitiesCommandProperty, value); }

        public List<Item> ItemList { get => (List<Item>)GetValue(ItemListProperty); set => SetValue(ItemListProperty, value); }

        public UserStatsUserControl()

        {
            InitializeComponent();
        }
    }
}
