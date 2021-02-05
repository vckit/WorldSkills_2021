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

namespace WpfApp6.Views.Pages.UserPage
{
    /// <summary>
    /// Логика взаимодействия для DataViewPage.xaml
    /// </summary>
    public partial class DataViewPage : Page
    {
        public ObservableCollection<Service> Services { get; set; }
        public DataViewPage()
        {
            InitializeComponent();
            Services = new ObservableCollection<Service>(DbContextObject.db.Service);
            this.DataContext = this;
        }
    }
}
