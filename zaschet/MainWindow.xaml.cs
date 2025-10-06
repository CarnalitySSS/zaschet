using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hostel
{
    public partial class MainWindow : Window
    {

        private readonly User[] users = new[]
        {
            new User { Login = "admin", Password = "admin123", Role = "Администратор" },
            new User { Login = "reception", Password = "reception123", Role = "Ресепшен" },
            new User { Login = "cleaner", Password = "cleaner123", Role = "Уборщик" }
        };

        public MainWindow()
        {
            InitializeComponent();
            LoginTextBox.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AttemptLogin();
        }

        private void AttemptLogin()
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            User authenticatedUser = AuthenticateUser(login, password);

            if (authenticatedUser != null)
            {
                // Успешная авторизация
                ShowSuccessMessage(authenticatedUser);
                OpenMainWindow(authenticatedUser);
            }
            else
            {
                ShowErrorMessage("Неверный логин или пароль");

                PasswordBox.Clear();
                PasswordBox.Focus();
            }
        }

        private User AuthenticateUser(string login, string password)
        {

            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        private void OpenMainWindow(User user)
        {

            MainForm mainForm = new MainForm(user);
            mainForm.Show();

            this.Close();
        }

        private void ShowSuccessMessage(User user)
        {
            MessageBox.Show($"Добро пожаловать, {user.Role}!", "Авторизация успешна",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowErrorMessage(string message)
        {
            ErrorMessageText.Text = message;
            ErrorMessageText.Visibility = Visibility.Visible;
        }

        private void HideErrorMessage()
        {
            ErrorMessageText.Visibility = Visibility.Collapsed;
            ErrorMessageText.Text = "";
        }

        private void ValidateInput()
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            bool isValid = !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password);
            LoginButton.IsEnabled = isValid;


            if (ErrorMessageText.Visibility == Visibility.Visible)
            {
                HideErrorMessage();
            }
        }


        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInput();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidateInput();
        }

        private void LoginTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && LoginButton.IsEnabled)
            {
                PasswordBox.Focus();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && LoginButton.IsEnabled)
            {
                AttemptLogin();
            }
        }
    }

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}