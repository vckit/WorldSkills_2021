using IBeginHate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace IBeginHate.Pages.LaborantExplorerPages
{
    /// <summary>
    /// Логика взаимодействия для LaborantExplorer.xaml
    /// </summary>
    public partial class LaborantExplorer : Page
    {
        #region vars
        public List<int> BioradServices = new List<int>()
        {
            619, 548, 258, 176, 543, 855, 836, 659, 797, 287
        };

        public List<int> LedetectService = new List<int>()
        {
            619, 311, 258, 501, 543, 557, 229, 415, 323, 346, 659
        };

        int patienId;
        List<Service> SelectedService = new List<Service>();
        List<BloodService> SelectedOrder = new List<BloodService>();
        #endregion

        public LaborantExplorer()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CmbAnalyzer.ItemsSource = AppData.db.Analyzer.ToList();
            CmbAnalyzer.DisplayMemberPath = "Title";
            GridPatients.ItemsSource = AppData.db.BloodService.ToList();
        }


        // Fill Services
        private void CmbAnalyzer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedAnalyzer = CmbAnalyzer.SelectedItem as Analyzer;
            if (SelectedAnalyzer.Title == "Biorad")
            {
                CmbServices.ItemsSource = AppData.db.Service.Where(s => BioradServices.Contains(s.Code)).ToList();
            } else
            {
                CmbServices.ItemsSource = AppData.db.Service.Where(s => LedetectService.Contains(s.Code)).ToList();
            }


            CmbServices.DisplayMemberPath = "Title";
        }

        private void Loader_me_MediaEnded(object sender, RoutedEventArgs e)
        {
            Loader_me.Position = new TimeSpan(0, 0, 1);
        }

        private async void Send_btn_Click(object sender, RoutedEventArgs e)
        {
            if (GridPatients.SelectedItem != null)
            {
                Loader_me.Visibility = Visibility.Visible;
                Loader_me.Play();
                GridProcess.ItemsSource = GridPatients.SelectedItems;
                foreach (BloodService item in GridPatients.SelectedItems)
                {
                    SelectedOrder.Add(item);
                    SelectedService.Add(item.Service);
                    var order = AppData.db.BloodService.Where(c => c.ID == item.ID).FirstOrDefault();
                    order.status = "in processing";
                    AppData.db.SaveChanges();
                    patienId = order.Blood.PatientID;
                    var json = ConvertToJson(patienId, SelectedService);
                    await Post(json);
                    await Get();

                    Loader_me.Stop();
                    Loader_me.Visibility = Visibility.Collapsed;
                    GridProcess.ItemsSource = null;
                }
            }
            if (patienId != 0)
            {

            }
        }


        string ConvertToJson(int patientID, List<Service> selectedService)
        {
            string result = "{\"patient\":\"{patientID}\",\"services\":[{\"serviceCode\":{serviceCode}}]}";
            result = result.Replace("{patientID}", patientID.ToString()).Replace("{serviceCode}", selectedService[0].Code.ToString());

            for (int i = 0; i < selectedService.Count; i++)
            {
                result = result.Insert(result.LastIndexOf("]"), ",{\"serviceCode\":{serviceCode}}".Replace("{serviceCode}", selectedService[i].Code.ToString()));
            }

            return result;
        }

        private async Task Post(string json)
        {
            try
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    await client.PostAsync("http://localhost:5000/api/analyzer" + CmbAnalyzer.Text, content);
                    MessageBox.Show("Материал был отправлен на изучение!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task Get()
        {

                string returnObj = "";
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("http://localhost:5000/api/analzyer/" + CmbAnalyzer.Text);
                    if (result.ToString().Contains("400"))
                    {
                        MessageBox.Show("Ошибка анализатора!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        do
                        {
                            result = client.GetAsync("http://localhost:5000/api/analyzer/" + CmbAnalyzer.Text).Result;

                        var progress = result.Content.ReadAsStringAsync();
                            if (progress.Result.ToString().Contains("patient"))
                            {
                                returnObj = progress.Result.ToString();
                                break;
                            }
                            if (progress.Result.ToString().Contains("progress"))
                            {
                                try
                                {
                                    
                                }
                                catch (Exception)
                                {
                                    
                                }
                            }
                        } while (!result.Content.ToString().Contains("Analyzer is not working."));

                        var order = JsonSerializer.Deserialize<JsonOrder>(returnObj);
                        var services = order.services.ToList();
                        foreach (JsonService service in services)
                        {
                            var patient = AppData.db.Patient.Where(p => p.ID == patienId).FirstOrDefault();
                            var dbService = AppData.db.Service.Where(s => s.Code == service.serviceCode).FirstOrDefault();
                            if (MessageBox.Show($"Пациент {patient.FirstNaem}\n Услуга: {dbService.Title}\n результат: {service.result}", "Результат", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                var SelectOrder = SelectedOrder.Where(s => s.Service.Code == dbService.Code).FirstOrDefault();
                                SelectOrder.result = service.result.ToString();
                                SelectOrder.status = "Finished";
                                SelectOrder.accepted = true;
                                SelectOrder.finished = DateTime.Now;
                                AppData.db.SaveChanges();
                            }
                            else
                            {
                                var SelectOrder = SelectedOrder.Where(s => s.Service.Code == dbService.Code).FirstOrDefault();
                                SelectOrder.result = service.result.ToString();
                                SelectOrder.status = "Reject";
                                SelectOrder.accepted = false;
                                SelectOrder.finished = DateTime.Now;
                                AppData.db.SaveChanges();
                            }
                        }
                    }
                }
            
            SelectedService.Clear();
            SelectedOrder.Clear();
        }
    }
}
