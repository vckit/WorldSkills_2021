using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp6.Context;

namespace WpfApp6.Views.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Login_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                var CurrentLogin = DbContextObject.db.Login.FirstOrDefault(LoginData => LoginData.Email == UsernameTextBox.Text && LoginData.Password == PasswordPasswordBox.Password);
                if (CurrentLogin != null)
                {
                    switch (CurrentLogin.IDRole)
                    {
                        case "А":
                            NavigationService.Navigate(new DashboardPage());
                            break;
                    }
                }
                else
                    throw new Exception("Пользователь не найден!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс. Что-то не так.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
