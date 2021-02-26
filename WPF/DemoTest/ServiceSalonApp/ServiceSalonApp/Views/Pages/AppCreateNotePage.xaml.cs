using ServiceSalonApp.Context;
using ServiceSalonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace ServiceSalonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppCreateNotePage.xaml
    /// </summary>
    public partial class AppCreateNotePage : Page
    {
        // будем принимать данные из страницы AppServicePage.xaml
        private Service _selectedItem;
        public AppCreateNotePage(Service service)
        {
            InitializeComponent();
            txbServiceTitile.Text = service.Title;
            txbDuration.Text = service.DurationInSeconds.ToString();
            cmbClient.ItemsSource = DbContextObject.db.Client.ToList();
            this._selectedItem = service;
        }

        private void txbStartTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txbStartTime.Text.Contains(":"))
                {
                    string[] line = txbStartTime.Text.Split(':');
                    if (!string.IsNullOrEmpty(line[1]) && !string.IsNullOrWhiteSpace(line[1]))
                    {
                        DateTime date = new DateTime();
                        date = Convert.ToDateTime("01.01.2021" + $" {line[0]}:{line[1]}");
                        date = date.AddMinutes(Convert.ToInt32(txbDuration.Text));
                        txbEnd.Text = date.ToShortTimeString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbStartTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789:".IndexOf(e.Text) < 0;
        }

        private void ButtonAddNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientService clientService = new ClientService();
                clientService.ClientID = (cmbClient.SelectedItem as Client).ID;
                clientService.ServiceID = _selectedItem.ID;
                clientService.Comment = txbComment.Text;
                string date = dtpDateService.SelectedDate.Value.ToShortDateString() + " " + txbStartTime.Text;
                clientService.StartTime = Convert.ToDateTime(date);
                DbContextObject.db.ClientService.Add(clientService);
                DbContextObject.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
