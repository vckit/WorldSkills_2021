using Hello_World.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Hello_World.Views.Pages.ApiPage
{
    /// <summary>
    /// Логика взаимодействия для NewsViewPage.xaml
    /// </summary>
    public partial class NewsViewPage : Page
    {
        public ObservableCollection<News> News { get; set; }
        public NewsViewPage()
        {
            InitializeComponent();
            News = new ObservableCollection<News>();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CommentsViewPage((News)NewsListData.SelectedItem));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dev.hakta.pro/o/rally/api/news/");
            var response = await client.GetAsync(client.BaseAddress);
            var result = await response.Content.ReadAsStringAsync();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var serialization = new DataContractJsonSerializer(typeof(ServerResponse<News>));
            var response_object = (ServerResponse<News>)serialization.ReadObject(stream);
            News = new ObservableCollection<News>(response_object.data);
            this.DataContext = this;

            //DbContextObject.db.News.AddRange(News.Select(news => new DataBase.News 
            //{ 
            //    id = int.Parse(news.id), 
            //    title = news.title, 
            //    create_date = news.create_date, 
            //    update_date = news.update_date, 
            //    comments_count = news.comments_count.ToString(), 
            //    share_text = news.share_text, image = news.image
            //}));
            //await DbContextObject.db.SaveChangesAsync();
        }
    }
}
