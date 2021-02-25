using ServiceSalonApp.Views.Pages;
using System;
using System.Windows;

namespace ServiceSalonApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new AppLoginPage();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            ButtonBack.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
    }
}
