using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Hello_World.Views.Pages.ApiPage
{
    /// <summary>
    /// Логика взаимодействия для ApiNavigationPage.xaml
    /// </summary>
    public partial class ApiNavigationPage : Page
    {
        public ApiNavigationPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NewsPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewsViewPage());
        }

        private void CompetationPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetationViewPage());
        }
    }
}
