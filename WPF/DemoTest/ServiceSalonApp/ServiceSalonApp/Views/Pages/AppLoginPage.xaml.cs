using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServiceSalonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppLoginPage.xaml
    /// </summary>
    public partial class AppLoginPage : Page
    {
        public AppLoginPage()
        {
            InitializeComponent();
        }

        private void CodeAdminTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0; 
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(CodeAdminTextBox.Text == "0000")
            {
                Properties.Settings.Default.isAdmin = "Visible";
                NavigationService.Navigate(new AppServicePage());
            }
            else
                MessageBox.Show("НЕверно введен код администратора", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void GostLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.isAdmin = "Collapsed";
            NavigationService.Navigate(new AppServicePage());
        }
    }
}
