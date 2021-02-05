using dbAPI.Views.Pages.GetAPI;
using System.Windows;

namespace dbAPI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Инициализация проекта
            InitializeComponent();
            MainFrame.Navigate(new NavigationPage());
        }
    }
}
