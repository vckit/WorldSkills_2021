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
using WpfApp6.Context;
using WpfApp6.Model;

namespace WpfApp6.Views.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для MoreServicesPhotosPage.xaml
    /// </summary>
    public partial class MoreServicesPhotosPage : Page
    {
        public Service Service { get; set; }
        public ObservableCollection<ServicePhoto> Services { get; set; }
        public MoreServicesPhotosPage(Service service)
        {
            InitializeComponent();
            Service = service;
            Services = new ObservableCollection<ServicePhoto>(DbContextObject.db.ServicePhoto.Where(item => item.ServiceID == Service.ID));
            this.DataContext = this;
        }
    }
}
