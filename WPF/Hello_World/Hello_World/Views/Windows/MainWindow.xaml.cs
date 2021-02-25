using Hello_World.Views.Pages.MainPages;
using System.Windows;

namespace Hello_World
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StartPage());
        }
    }
}
