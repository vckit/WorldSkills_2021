using Microsoft.Win32;
using ServiceSalonApp.Context;
using ServiceSalonApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ServiceSalonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppAddEditPage.xaml
    /// </summary>
    public partial class AppAddEditPage : Page
    {
        Service selectedService;
        public AppAddEditPage()
        {
            InitializeComponent();
            VisibleID.Visibility = Visibility.Collapsed;
            RemovePhoto.Visibility = Visibility.Collapsed;
        }

        public AppAddEditPage(Service service)
        {
            InitializeComponent();
            this.selectedService = service;
            txbId.Text = service.ID.ToString();
            txbTitle.Text = service.Title;
            txbCost.Text = service.Cost.ToString();
            txbDuration.Text = service.DurationInSeconds.ToString();
            txbDescription.Text = service.Description;
            txbDiscount.Text = service.Discount.ToString();
            var picture = DbContextObject.db.ServicePhoto.Where(item => item.ServiceID == service.ID).ToList();
            for (int i = 0; i < picture.Count; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + picture[i].PhotoPath.Trim()));
                image.Width = 120;
                image.Height = 120;
                lvPhotos.Items.Add(image);
            }
            ImageMain.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\" + service.MainImagePath.Trim()));
        }
        string mainImpagePath = "";
        private void ButtonLoadMainImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                mainImpagePath = file.FileName;
                ImageMain.Source = new BitmapImage(new Uri(mainImpagePath));
            }
        }

        private void txtLoadPhoto_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Move;
        }
        List<string> photoPath = new List<string>();

        private void txtLoadPhoto_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] photo = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < photo.Length; i++)
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(photo[i]));
                    image.Width = 120;
                    image.Height = 120;
                    lvPhotos.Items.Add(image);
                    photoPath.Add(photo[i]);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedService != null)
                {
                    bool error = false;
                    var service = DbContextObject.db.Service.Where(item => item.ID == selectedService.ID).FirstOrDefault();
                    var titles = DbContextObject.db.Service.Where(item => item.Title.ToLower() == txbTitle.Text.ToLower()).ToList();

                    try
                    {
                        error = Convert.ToInt32(txbDuration.Text) > 14400 ? true : false;
                    }
                    catch
                    {
                        throw new Exception("Длительность должна быть указана числом!");
                    }
                    if (error)
                        throw new Exception("Неверно введённые данные!");
                    else
                    {
                        try
                        {
                            service.Title = txbTitle.Text;
                            service.Cost = Convert.ToDecimal(txbCost.Text);
                            service.Description = txbDescription.Text;
                            service.Discount = int.Parse(txbDiscount.Text);
                            service.DurationInSeconds = int.Parse(txbDuration.Text);
                            if (!string.IsNullOrEmpty(mainImpagePath) && !string.IsNullOrWhiteSpace(mainImpagePath))
                                File.Copy(mainImpagePath, service.MainImagePath.Trim(), true);
                            for (int i = 0; i < photoPath.Count; i++)
                            {
                                ServicePhoto servicePhoto = new ServicePhoto();
                                servicePhoto.ServiceID = selectedService.ID;
                                servicePhoto.PhotoPath = $"Услуги школы\\" + System.IO.Path.GetFileName(photoPath[i]);
                                File.Copy(photoPath[i], $"Услуги школы\\{System.IO.Path.GetFileName(photoPath[i])}", true);
                                DbContextObject.db.ServicePhoto.Add(servicePhoto);
                                DbContextObject.db.SaveChanges();
                            }
                            DbContextObject.db.SaveChanges();
                            NavigationService.GoBack();
                        }
                        catch
                        {

                            throw new Exception("Неверно введены данные");
                        }
                    }
                }
                else
                {
                    bool error = false;
                    var titles = DbContextObject.db.Service.Where(item => item.Title.ToLower() == txbTitle.Text.ToLower()).ToList();
                    if (titles.Count != 0)
                        error = true;
                    try
                    {
                        if (Convert.ToInt32(txbDuration.Text) > 14400)
                            error = true;
                    }
                    catch
                    {
                        throw new Exception("");
                    }
                    if (error)
                        throw new Exception("Неверные введены данные ");
                    else
                    {
                        Service service = new Service();
                        service.Title = txbTitle.Text;
                        try
                        {
                            service.Cost = Convert.ToDecimal(txbCost.Text);
                            service.Description = txbDescription.Text;
                            service.Discount = Convert.ToInt32(txbDiscount.Text);
                            service.DurationInSeconds = Convert.ToInt32(txbDuration.Text);
                            if (!string.IsNullOrEmpty(mainImpagePath) && !string.IsNullOrEmpty(mainImpagePath))
                            {
                                File.Copy(mainImpagePath, $"Услуги школы\\{System.IO.Path.GetFileName(mainImpagePath)}");
                                service.MainImagePath = $"Услуги школы\\{System.IO.Path.GetFileName(mainImpagePath)}";
                            }
                            DbContextObject.db.Service.Add(service);
                            for (int i = 0; i < photoPath.Count; i++)
                            {
                                ServicePhoto photo = new ServicePhoto();
                                photo.ServiceID = service.ID;
                                photo.PhotoPath = $"Услуги школы\\{System.IO.Path.GetFileName(photoPath[i])}";
                                File.Copy(photoPath[i], $"Услуги школы\\{System.IO.Path.GetFileName(photoPath[i])}", true);
                                DbContextObject.db.ServicePhoto.Add(photo);
                                DbContextObject.db.SaveChanges();
                            }
                            DbContextObject.db.SaveChanges();
                            NavigationService.GoBack();
                        }
                        catch
                        {
                            throw new Exception("Неверно введны данные");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemovePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (selectedService != null)
            {
                var service = DbContextObject.db.Service.Where(item => item.ID == selectedService.ID).FirstOrDefault();
                if (File.Exists(service.MainImagePath.Trim()))
                    File.Delete(service.MainImagePath.Trim());
                service.MainImagePath = null;
                var servicePhoto = DbContextObject.db.ServicePhoto.Where(item => item.ID == selectedService.ID).ToList();
                for (int i = 0; i < servicePhoto.Count(); i++)
                    if (File.Exists(servicePhoto[i].PhotoPath.Trim()))
                    {
                        File.Exists(servicePhoto[i].PhotoPath.Trim());
                        DbContextObject.db.ServicePhoto.Remove(servicePhoto[i]);
                    }

                DbContextObject.db.SaveChanges();
                ImageMain.Source = null;
                lvPhotos.Items.Clear();
            }
        }
    }
}
