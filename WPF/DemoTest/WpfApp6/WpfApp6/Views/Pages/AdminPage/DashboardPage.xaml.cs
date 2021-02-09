using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp6.Context;
using WpfApp6.Model;

namespace WpfApp6.Views.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {

        #region Область объявления переменных
        public int counts { get; set; }
        public ObservableCollection<Service> Services { get; set; }

        public Service SelectedService { get; set; }
        #endregion
        public DashboardPage()
        {
            InitializeComponent();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListService.ItemsSource = DbContextObject.db.Service.Where(keyword => keyword.Title.Contains(SearchTextBox.Text)).ToList();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditSelectedItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            try                                       
            {
                SelectedService = (Service)ListService.SelectedItem;
                if (SelectedService != null)
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Подтвердите удаление.", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DbContextObject.db.Service.Remove(SelectedService);
                        DbContextObject.db.SaveChanges();
                        Services.Remove(SelectedService);
                        --counts;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw new Exception();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Services = new ObservableCollection<Service>(DbContextObject.db.Service);
            counts = Services.Count();
            DataContext = this;
        }
    }
}
