using Hello_World.Views.Pages.ApiPage;
using Hello_World.Views.Pages.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Hello_World.Views.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void DataAPIWorkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApiNavigationPage());
        }

        private void DataBaseWorkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DataViewPage());
        }
    }
}
