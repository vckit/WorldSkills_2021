using Microsoft.Win32;
using Sessia.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Sessia.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public Service service { get; set; }
        public ServicePage photo { get; set; }
        public ServicePage(Service GetService)
        {
            InitializeComponent();
            service = GetService;
            this.DataContext = this;
        }

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "(*.png); (*.jpg) | *.png; *.jpg";

            if (file.ShowDialog() == true)
            {
                ImgBox.Source = new BitmapImage(new Uri(file.FileName));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var IsUnique = BaseClass.db.Service.FirstOrDefault(x => x.Title == TxbTitle.Text);
                if (service.ID == 0)
                {
                    if (IsUnique != null)
                    {
                        MessageBox.Show("Такая услуга имеется");
                    }
                    else
                    {
                        BaseClass.db.Service.Add(service);

                        BaseClass.db.SaveChanges();
                        MessageBox.Show("Всё сохранено");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "01234567890".IndexOf(e.Text) < 0;
        }

        private void MaxDuration(object sender, TextChangedEventArgs e)
        {
            int TimeLimit = int.Parse(TxbDuration.Text);
            if (TimeLimit > 14400)
            {
                TxbDuration.Text = "14400";
            }
        }
    }
}
