using dbAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using System.Runtime.Serialization.Json;
using System.Windows.Shapes;

namespace dbAPI.Views.Pages.GetAPI
{
    /// <summary>
    /// Логика взаимодействия для CarViewPage.xaml
    /// </summary>
    public partial class CarViewPage : Page
    {
        private static readonly HttpClient client = new HttpClient();

        public ObservableCollection<Car> Cars { get; set; }
        public CarViewPage()
        {
            InitializeComponent();
            Cars = new ObservableCollection<Car>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://solutions2019.hakta.pro/api/getFines?participant=01";
            try
            {
                using (var response = await client.GetAsync(url))
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var serializi = new DataContractJsonSerializer(typeof(ServerResponse<Car>));
                    var response_object = (ServerResponse<Car>)serializi.ReadObject(stream);
                    Cars = new ObservableCollection<Car>(response_object.data);
                    this.DataContext = this;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
