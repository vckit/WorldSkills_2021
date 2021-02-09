using Sessia.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Sessia.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ObservableCollection<Service> service { get; set; }
        public ServiceListPage()
        {
            InitializeComponent();
            service = new ObservableCollection<Service>(BaseClass.db.Service.ToList());
            this.DataContext = this;

            
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (CmbSort.Text == "по возрастанию")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.OrderBy(x => x.Cost).ToList();
            }
            else if (CmbSort.Text == "по убыванию")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.OrderByDescending(x => x.Cost).ToList();
            }
            else if (CmbSort.Text == "скидка 0-5%")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.Where(x => x.Discount < 5).ToList();
            }
            else if (CmbSort.Text == "скидка 5-15%")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.Where(x =>  x.Discount < 15).ToList();
            }
            else if (CmbSort.Text == "скидка 15-30%")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.Where(x => x.Discount < 30).ToList();
            }
            else if (CmbSort.Text == "скидка 30-70%")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.Where(x =>x.Discount < 70).ToList();
            }
            else if (CmbSort.Text == "скидка 70-100%")
            {
                ProductListView.ItemsSource = BaseClass.db.Service.Where(x => x.Discount > 70).ToList();
            }
            else if (CmbSort.Text == "Все")
            {   
                ProductListView.ItemsSource = BaseClass.db.Service.ToList();
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var DelService = (Service)ProductListView.SelectedItem;
            BaseClass.db.Service.Remove(DelService);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate((Service)ProductListView.SelectedItem);

        }
    }
}
