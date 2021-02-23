using ServiceApp.Context;
using ServiceApp.Models;
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

namespace ServiceApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceViewPage.xaml
    /// </summary>
    public partial class ServiceViewPage : Page
    {
        public Service Service { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public ServiceViewPage()
        {
            InitializeComponent();
            Services = new ObservableCollection<Service>(DbContextObject.DB.Service.ToList());
            this.DataContext = this;
        }
    }
}
