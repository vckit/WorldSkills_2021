using ServiceSalonApp.Context;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ServiceSalonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppNoteViewPage.xaml
    /// </summary>
    public partial class AppNoteViewPage : Page
    {
        public AppNoteViewPage()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e) => Update();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        private void Update()
        {
            DataGridViewNoteService.ItemsSource = null;
            var notes = DbContextObject.db.ClientService.ToList();
            notes = notes.Where(item => item.StartTime >= DateTime.Now && item.StartTime <= DateTime.Now.AddDays(1)).OrderBy(item => item.StartTime).ToList();
            DataGridViewNoteService.ItemsSource = notes;
        }
    }
}
