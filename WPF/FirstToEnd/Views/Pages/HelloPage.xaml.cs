using FirstToEnd.Model;
using FirstToEnd.Views.Pages.AdminPages;
using FirstToEnd.Views.Pages.LaborantPages;
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

namespace FirstToEnd.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для HelloPage.xaml
    /// </summary>
    public partial class HelloPage : Page
    {
        public User user { get; set; }
        public HelloPage(User getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (user.RoleID == 1)
            {
                NavigationService.Navigate(new AdminMenuPage());
                
            } else if (user.RoleID == 2)
            {
                NavigationService.Navigate(new LaborantMenuPage());
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (user.RoleID == 1)
            {
                ImgBox.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/1.png"));
            }
            else if (user.RoleID == 2)
            {
                ImgBox.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/2.jpeg"));
            }
            TxbHello.Content = $"Добро пожаловать {user.FirstName} {user.LastName}! Ваша роль: {user.Role.Title}";
        }
    }
}
