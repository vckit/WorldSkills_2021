using Hello_World.DataBase;
using Hello_World.DbContext;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hello_World.Views.Pages.Data
{
    /// <summary>
    /// Логика взаимодействия для DataActionPage.xaml
    /// </summary>
    public partial class DataActionPage : Page
    {
        public List<A_Gender> Gender { get; set; }
        public List<L_Group> Groups { get; set; }
        public List<H_Department> Departments { get; set; }
        public T_User User { get; set; }
        public DataActionPage(T_User user)
        {
            InitializeComponent();
            Gender = DbContextObject.db.A_Gender.ToList();
            Groups = DbContextObject.db.L_Group.ToList();
            Departments = DbContextObject.db.H_Department.ToList();
            User = user;
            this.DataContext = this;
        }

        private void ButtonSelectionImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image (*.png; *.jpg; *.jpeg;)|*.png; *.jpg; *.jpeg;";
            PicUsers.Source = file.ShowDialog() == true ? PicUsers.Source = new BitmapImage(new Uri(file.FileName)) : null;

        }

        private void ButtonSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (User.ID == 0)
                DbContextObject.db.T_User.Add(User);

            DbContextObject.db.SaveChanges();

            MessageBox.Show("Данные успешно сохранены!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PhoneTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789+".IndexOf(e.Text) < 0;
        }
    }
}
