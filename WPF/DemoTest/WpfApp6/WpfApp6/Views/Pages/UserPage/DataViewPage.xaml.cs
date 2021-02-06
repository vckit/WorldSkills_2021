using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp6.Context;
using WpfApp6.Model;

namespace WpfApp6.Views.Pages.UserPage
{
    /// <summary>
    /// Логика взаимодействия для DataViewPage.xaml
    /// </summary>
    public partial class DataViewPage : Page
    {
        public string counts { get; set; }
        public ObservableCollection<Service> Services { get; set; }

        public DataViewPage()
        {
            InitializeComponent();
            counts = DbContextObject.db.Service.Count().ToString();
            Services = new ObservableCollection<Service>(DbContextObject.db.Service);
            this.DataContext = this;
        }
    }
}
