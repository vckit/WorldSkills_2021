using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WorldSkills.Pages
{
	/// <summary>
	/// Логика взаимодействия для AuthPage.xaml
	/// </summary>
	public partial class AuthPage : Page
	{
		public AuthPage()
		{
			InitializeComponent();

			var Timer = File.ReadAllText("./AuthBlock.txt");

			if (Timer == "60")
			{
				LoginBox.IsEnabled = false;
				PasswordBox.IsEnabled = false;
				AuthButton.IsEnabled = false;
				AuthTimer.Start();
			}

			AuthTimer.Interval = new TimeSpan(0,0,60);
			AuthTimer.Tick += TimerTick;
		}

		int AuthCount = 0;
		DispatcherTimer AuthTimer = new DispatcherTimer();

		public void TimerTick(object s, EventArgs e)
		{
			LoginBox.IsEnabled = true;
			PasswordBox.IsEnabled = true;
			AuthButton.IsEnabled = true;
			File.WriteAllText("./AuthBlock.txt", "");
			AuthTimer.Stop();
		}

		private void AuthButton_Click(object sender, RoutedEventArgs e)
		{
			if (LoginBox.Text == "Inspector" && PasswordBox.Text == "Inspector")
			{
				NavigationService.Navigate(new DriverPage());
			}
			else
			{
				AuthCount++;

				if (AuthCount == 4)
				{
					MessageBox.Show("Ввод данных заблокирован на минуту");
					LoginBox.IsEnabled = false;
					PasswordBox.IsEnabled = false;
					AuthButton.IsEnabled = false;
					File.WriteAllText("./AuthBlock.txt", 60 + "");
					AuthTimer.Start();
				}
				else
				{
					MessageBox.Show("Неправильные логин или пароль");
				}
			}
		}
	}
}
