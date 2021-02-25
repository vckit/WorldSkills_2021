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
    /// Логика взаимодействия для CommentsViewPage.xaml
    /// </summary>
    public partial class CommentsViewPage : Page
    {
        public ObservableCollection<Comments> Comments { get; set; }
        public News News { get; set; }
        public CommentsViewPage(News get_news)
        {
            InitializeComponent();
            Comments = new ObservableCollection<Comments>();
            News = get_news;
            this.DataContext = this;
        }

        public object HttpClient { get; private set; }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://dev.hakta.pro/o/rally/api/news/{News.id}/comments/");
            var response = await client.GetAsync(client.BaseAddress);
            var result = await response.Content.ReadAsStringAsync();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var serialize = new DataContractJsonSerializer(typeof(ServerResponse<Comments>));
            var response_object = (ServerResponse<Comments>)serialize.ReadObject(stream);
            Comments = new ObservableCollection<Comments>(response_object.data);
            this.DataContext = null;
            this.DataContext = this;
        }
    }
}
