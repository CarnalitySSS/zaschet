using System.Windows;

namespace Hostel
{
    public partial class MainForm : Window
    {
        private User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            Title = $"Главная - Хостел ({user.Role})";
        }
    }
}