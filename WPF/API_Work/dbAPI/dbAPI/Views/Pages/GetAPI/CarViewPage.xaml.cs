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
        public ObservableCollection<Car> Cars { get; set; }
        public CarViewPage()
        {
            InitializeComponent();
            Cars = new ObservableCollection<Car>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://solutions2019.hakta.pro/api/getFines?participant=01");
            var response = await client.GetAsync(client.BaseAddress);
            var result = await response.Content.ReadAsStringAsync();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var serializi = new DataContractJsonSerializer(typeof(ServerResponse<Car>));
            var response_object = (ServerResponse<Car>)serializi.ReadObject(stream);
            Cars = new ObservableCollection<Car>(response_object.data);
            this.DataContext = this;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
