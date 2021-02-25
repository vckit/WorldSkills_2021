using Hello_World.DataBase;
using Hello_World.DbContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hello_World.Views.Pages.Data
{
    /// <summary>
    /// Логика взаимодействия для DataViewPage.xaml
    /// </summary>
    public partial class DataViewPage : Page
    {
        public ObservableCollection<T_User> Users { get; set; }
        public List<A_Gender> Genders { get; set; }
        public DataViewPage()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Users = new ObservableCollection<T_User>(DbContextObject.db.T_User.ToList());
            this.DataContext = this;
        }

        private void ListDataView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new DataActionPage((T_User)ListDataView.SelectedItem));
        }

        private void AddButtonPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new DataActionPage(new T_User()));
        }

        private void RemoveSelection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (T_User)ListDataView.SelectedItem;
                if (selectedItem != null)
                    if (MessageBox.Show("Вы действительно хотите это удалить?", "Удалить?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DbContextObject.db.T_User.Remove(selectedItem);
                        DbContextObject.db.SaveChanges();
                        Users.Remove(selectedItem);
                        MessageBox.Show("Удалено!");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
