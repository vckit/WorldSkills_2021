using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using WpfApp6.Context;
using WpfApp6.Model;
using WpfApp6.Views.Pages.AdminPage;

namespace WpfApp6.Views.Pages.UserPage
{
    /// <summary>
    /// Логика взаимодействия для DataViewPage.xaml
    /// </summary>
    public partial class DataViewPage : Page
    {
        #region Область объявления переменных
        public int counts { get; set; }
        public ObservableCollection<Service> Services { get; set; }

        #endregion

        public DataViewPage() => InitializeComponent();
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListService.ItemsSource = DbContextObject.db.Service.Where(keyword => keyword.Title.Contains(SearchTextBox.Text)).ToList();
        }

        private void ButtonLoginAdminPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Services = new ObservableCollection<Service>(DbContextObject.db.Service);
            counts = Services.Count();
            this.DataContext = this;
        }
    }
}
