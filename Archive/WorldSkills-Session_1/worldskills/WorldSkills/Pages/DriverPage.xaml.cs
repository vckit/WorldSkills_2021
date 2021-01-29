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
using System.Windows.Threading;
using WorldSkills.Forms;

namespace WorldSkills.Pages
{
	/// <summary>
	/// Логика взаимодействия для DriverPage.xaml
	/// </summary>
	public partial class DriverPage : Page
	{
		DispatcherTimer timer = new DispatcherTimer();

		public DriverPage()
		{
			InitializeComponent();
			timer.Tick += TimerTick;
			timer.Interval = new TimeSpan(0,0,60);
			timer.Start();
		}

		private void TimerTick(object sender, EventArgs e)
		{
			
		}

		private void AddDriverButton_Click(object sender, RoutedEventArgs e)
		{
			AddNewDriverForm addNewDriverForm = new AddNewDriverForm(null);
			addNewDriverForm.ShowDialog();
		}

		private void ApiTestButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new ApiTestPage());
		}

	
	}
}
