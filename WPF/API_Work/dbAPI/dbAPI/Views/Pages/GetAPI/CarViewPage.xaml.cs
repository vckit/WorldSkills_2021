using dbAPI.Context;
using dbAPI.DbModel;
using dbAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace dbAPI.Views.Pages.GetAPI
{
    /// <summary>
    /// Логика взаимодействия для CarViewPage.xaml
    /// </summary>
    public partial class CarViewPage : Page
    {
        private static readonly HttpClient client = new HttpClient();

        public ObservableCollection<Car> Cars { get; set; }
        //public IEnumerable<Car> Cars { get; set; }
        //public List<Car> Cars { get; set; }
        public CarViewPage()
        {
            InitializeComponent();
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

                DbContextObject.db.F_Car.AddRange(Cars.Select(car => new DbModel.F_Car { id = int.Parse(car.id), car_num = car.car_num, create_date = car.create_date, licence_num = car.licence_num, photo = car.photo }));
                await DbContextObject.db.SaveChangesAsync();
            }
            catch (Exception ex)
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
