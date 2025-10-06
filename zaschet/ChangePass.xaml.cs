using System;
using System.Windows;
using System.Windows.Controls;

namespace ChangePass
{
    public partial class MainWindow : Window
    {

        private const string ValidLogin = "admin";
        private const string ValidPassword = "12345";

        public MainWindow()
        {
            InitializeComponent();
            LoginTextBox.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (AuthenticateUser(login, password))
            {

                ShowSuccessMessage();

            }
            else
            {
                ShowErrorMessage("Неверный логин или пароль");
            }
        }

        private bool AuthenticateUser(string login, string password)
        {
            return login == ValidLogin && password == ValidPassword;
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInput();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidateInput();
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

        private void ShowErrorMessage(string message)
        {
            ErrorMessageText.Text = message;
            ErrorMessageText.Visibility = Visibility.Visible;

            PasswordBox.Focus();
            PasswordBox.SelectAll();
        }

        private void HideErrorMessage()
        {
            ErrorMessageText.Visibility = Visibility.Collapsed;
            ErrorMessageText.Text = "";
        }

        private void ShowSuccessMessage()
        {
            MessageBox.Show("Авторизация успешна!", "Успех",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoginButton_Click(object sender, object e)
        {

        }
    }
}