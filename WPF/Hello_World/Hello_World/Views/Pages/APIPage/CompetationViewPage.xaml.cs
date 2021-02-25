using Hello_World.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Hello_World.Views.Pages.ApiPage
{
    /// <summary>
    /// Логика взаимодействия для CompetationViewPage.xaml
    /// </summary>
    public partial class CompetationViewPage : Page
    {
        public ObservableCollection<Competation> Competations { get; set; }
        public CompetationViewPage()
        {
            InitializeComponent();
            Competations = new ObservableCollection<Competation>();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dev.hakta.pro/o/rally/api/competition");
            var response = await client.GetAsync(client.BaseAddress);
            var result = await response.Content.ReadAsStringAsync();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var serialize = new DataContractJsonSerializer(typeof(ServerResponse<Competation>));
            var response_object = (ServerResponse<Competation>)serialize.ReadObject(stream);
            Competations = new ObservableCollection<Competation>(response_object.data);
            this.DataContext = null;
            this.DataContext = this;
        }
    }
}
