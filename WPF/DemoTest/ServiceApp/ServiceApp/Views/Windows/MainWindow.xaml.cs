using ServiceApp.Views.Pages;
using System.Windows;

namespace ServiceApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ServiceViewPage());
        }
    }
}
