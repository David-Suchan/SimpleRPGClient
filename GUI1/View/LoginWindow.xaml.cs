using System.ComponentModel;
using System.Windows;
using GUI1.ServicesFolder;
using GUI1.ViewModel;

namespace GUI1.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, INotifyPropertyChanged
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private bool isLogInVisible = true;

        public bool IsLogInVisible
        {
            get { return isLogInVisible; }
            set { isLogInVisible = value; OnPropertyChanged(nameof(IsLogInVisible)); }
        }

        private bool isRegistrationVisible;
        public bool IsRegistrationVisible
        {
            get { return isRegistrationVisible; }
            set {isRegistrationVisible = value; OnPropertyChanged(nameof(IsRegistrationVisible)); }
        }
        


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Password.Password))
            {
                Services.httpServices.Login(Email.Text, Password.Password);
            }
            else
            {
                MessageBox.Show("You must input a password and username", "", MessageBoxButton.OK);
            }
            
        }

        private void RegisterForm_Click(object sender, RoutedEventArgs e)
        {
            this.IsLogInVisible = false;      
            this.IsRegistrationVisible = true;                                
        }
        
        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Services.httpServices.Register(RegisterEmail.Text, RegisterUsername.Text, RegisterPassword.Password);

        }

        private void LoginFormClick(object sender, RoutedEventArgs e)
        {
            this.IsLogInVisible = true;
            this.IsRegistrationVisible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
