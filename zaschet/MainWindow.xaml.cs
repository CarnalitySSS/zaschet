using System.Windows;

namespace StudentAttendanceSystem
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (login == "admin" && password == "admin")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}