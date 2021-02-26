using ServiceSalonApp.Context;
using ServiceSalonApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ServiceSalonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppServicePage.xaml
    /// </summary>
    public partial class AppServicePage : Page
    {
        public AppServicePage()
        {
            InitializeComponent();
        }

        private void Update(string sort = "", string discountFilter = "", string search = "")
        {
            var services = DbContextObject.db.Service.ToList();
            int all = DbContextObject.db.Service.Count();

            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(sort))
            {
                if (sort == "По возрастанию")
                    services = services.OrderBy(item => item.Cost).ToList();
                else
                    services = services.OrderByDescending(item => item.Cost).ToList();
            }
            if (!string.IsNullOrEmpty(discountFilter) && !string.IsNullOrEmpty(discountFilter))
            {
                if (discountFilter == "от 0 до 5%")
                    services = services.Where(item => 0 <= item.Discount && item.Discount < 5).ToList();
                if (discountFilter == "от 5 до 15%")
                    services = services.Where(item => 5 <= item.Discount && item.Discount < 15).ToList();
                if (discountFilter == "от 15 до 30%")
                    services = services.Where(item => 15 <= item.Discount && item.Discount < 30).ToList();
                if (discountFilter == "от 30 до 70%")
                    services = services.Where(item => 30 <= item.Discount && item.Discount < 70).ToList();
                if (discountFilter == "от 70 до 100%")
                    services = services.Where(item => 70 <= item.Discount && item.Discount < 100).ToList();
            }
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(search))
                services = services.Where(item => item.Title.ToLower().Contains(search.ToLower()) || item.Description.ToLower().Contains(search.ToLower())).ToList();
            NotesCount.Text = $"{services.Count} из {all}";
            DataService.ItemsSource = services;
        }

        private void SortOrderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update((SortOrderComboBox.SelectedItem as ComboBoxItem).Content.ToString(), SortDiscountComboBox.Text, SearchTextBox.Text);
        }

        private void SortDiscountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(SortOrderComboBox.Text, (SortDiscountComboBox.SelectedItem as ComboBoxItem).Content.ToString(), SearchTextBox.Text);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update(SortOrderComboBox.Text, SortDiscountComboBox.Text, SearchTextBox.Text);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentService = DataService.SelectedItem as Service;
            if (currentService != null)
                NavigationService.Navigate(new AppAddEditPage(currentService));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var currentService = DataService.SelectedItem as Service;
            try
            {
                if (currentService != null)
                {
                    if (MessageBox.Show("Вы хотите удалить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var notes = DbContextObject.db.ClientService.Where(item => item.ServiceID == currentService.ID).ToList();
                        if (notes.Count == 0)
                        {
                            var piсtures = DbContextObject.db.ServicePhoto.Where(item => item.ServiceID == currentService.ID).ToList();
                            foreach (var item in piсtures)
                                File.Delete(item.PhotoPath.Trim());
                            if (piсtures.Count != 0)
                                DbContextObject.db.ServicePhoto.RemoveRange(piсtures);
                            DbContextObject.db.Service.Remove(currentService);
                            DbContextObject.db.SaveChanges();
                            Update(SortOrderComboBox.Text, SortDiscountComboBox.Text, SearchTextBox.Text);
                        }
                        else
                            throw new Exception("Услуга не может быть удалена, так как на неё создана запись!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AppAddEditPage());
        }

        private void ViewNoteButton_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new AppNoteViewPage());
        }

        private void ReadNoteButton_Click(object sender, RoutedEventArgs e)
        {
            var service = DataService.SelectedItem as Service;
            if (service != null)
                NavigationService.Navigate(new AppCreateNotePage(service));
            else
                MessageBox.Show("Выберите запись!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) => Update();
    }
}
