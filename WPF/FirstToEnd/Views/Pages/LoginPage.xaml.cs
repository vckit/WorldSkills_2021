using FirstToEnd.Model;
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

namespace FirstToEnd.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }



        private void BtnToNext_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.User.FirstOrDefault(x => x.login == TxbLogin.Text && x.password == PboxPassword.Password);
            if (TblockCapthca.Text == TxbCaptcha.Text)
            {
                try
                {
                    if (CurrentUser != null)
                    {
                        NavigationService.Navigate(new HelloPage(CurrentUser));
                    }
                    else
                    {
                        MessageBox.Show("неверный логин или пароль!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        TblockCapthca.Text = GetCaptcha();
                        PanelCapthca.Visibility = Visibility.Visible;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                PanelCapthca.Visibility = Visibility.Visible;
                MessageBox.Show("Неверно введена Капча", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }




        private void BtnNewCapthca_Click(object sender, RoutedEventArgs e)
        {
            TblockCapthca.Text = GetCaptcha();
        }

        private void BtnShowPassword(object sender, RoutedEventArgs e)
        {
            if (TxbPassword.Visibility == Visibility.Collapsed)
            {
                TxbPassword.Text = PboxPassword.Password;
                TxbPassword.Visibility = Visibility.Visible;
                PboxPassword.Visibility = Visibility.Collapsed;
            } else
            {
                TxbPassword.Visibility = Visibility.Collapsed;
                PboxPassword.Visibility = Visibility.Visible;
            }
        }


        

        string GetCaptcha()
        {
            string aplhabet = "0123456789QWERTYUIOPLKJHGFDSAZXCVBNM", password = "";
            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                password += aplhabet[rand.Next(aplhabet.Length)];
            }

            return password;
        }
    }
}
