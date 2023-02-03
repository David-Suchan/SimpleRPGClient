using GUI1.Model;
using KaiserMVVMCore;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GUI1.View
{
    public partial class UserAbilitiesUserControl : UserControl
    {
        public static DependencyProperty AbilitiesProperty =
            DependencyProperty.Register(nameof(Abilities), typeof(List<CharacterAbility>), typeof(UserAbilitiesUserControl));

        public static DependencyProperty BackToStatsCommandProperty =
            DependencyProperty.Register(nameof(BackToStatsCommand), typeof(RelayCommand), typeof(UserAbilitiesUserControl));


        public List<CharacterAbility> Abilities
        {
            get => (List<CharacterAbility>)GetValue(AbilitiesProperty);
            set => SetValue(AbilitiesProperty, value);
        }

        public RelayCommand BackToStatsCommand 
        { 
            get => (RelayCommand)GetValue(BackToStatsCommandProperty); 
            set => SetValue(BackToStatsCommandProperty, value); 
        }

        public UserAbilitiesUserControl()
        {
            InitializeComponent();
        }
    }
}
