using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldSkills.Database;

namespace WorldSkills.Forms
{
	/// <summary>
	/// Логика взаимодействия для AddNewDriverForm.xaml
	/// </summary>
	public partial class AddNewDriverForm : Window
	{
		public AddNewDriverForm(Driver Driver)
		{
			InitializeComponent();

			if (Driver != null)
			{

				FirstNameBox.Text = Driver.Name;
				MiddleNameBox.Text = Driver.MiddleName;
				PassportBox.Text = Driver.PassportSerial + " " + Driver.PassportNumber;
				CompanyBox.Text = Driver.Company;
				JobnameBox.Text = Driver.Jobname;
				photoImageStr = Driver.Photo;
				EmailBox.Text = Driver.Email;
				IDBox.Text = Driver.Id.ToString();
				PhoneBox.Text = Driver.Phone;
				AddressRegis.Text = Driver.Address;
			}

			this.Driver = Driver;
		}

		Driver Driver;
		string photoImageStr = "";

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{

			if (FirstNameBox.Text == "" || MiddleNameBox.Text == "" || LastNameBox.Text == "" ||
				PassportBox.Text == "" || AddressLifeBox.Text == "" || AddressRegis.Text == "" ||
				PhoneBox.Text == "" || EmailBox.Text == "" || PhotoImage == null)
			{
				MessageBox.Show("Заполните необходимые поля");
			}
			else
			{
				if (Regex.IsMatch(EmailBox.Text, @"[A-Za-z0-9]@[a-z]"))
				{
					if (Driver == null)
					{

						Driver Driver = new Driver()
						{
							Name = LastNameBox.Text + " " + FirstNameBox.Text,
							MiddleName = MiddleNameBox.Text,
							PassportSerial = int.Parse(PassportBox.Text),
							Company = CompanyBox.Text,
							Jobname = JobnameBox.Text,
							Photo = photoImageStr + "shbefhsbfg",
							Email = EmailBox.Text,
							PassportNumber = int.Parse(PassportBox.Text),
							Id = int.Parse(IDBox.Text),
							Phone = PhoneBox.Text,
							Address = AddressRegis.Text + ", " + AddressLifeBox.Text,
							

						};
						Singleton.Context.Driver.Add(Driver);
						Singleton.Context.SaveChanges();
					}
					else if (Driver != null)
					{
						Driver.Name = LastNameBox.Text + " " + FirstNameBox.Text;
						Driver.MiddleName = MiddleNameBox.Text;
						Driver.PassportSerial = int.Parse(PassportBox.Text.Substring(0, 4));
						Driver.Company = CompanyBox.Text;
						Driver.Jobname = JobnameBox.Text;
						Driver.Photo = photoImageStr;
						Driver.Email = EmailBox.Text;
						Driver.PassportNumber = int.Parse(PassportBox.Text.Substring(5, 6));
						Driver.Id = int.Parse(IDBox.Text);
						Driver.Phone = PhoneBox.Text;
						Driver.Address = AddressRegis.Text + ", " + AddressLifeBox.Text;

						Singleton.Context.SaveChanges();
					}
				}
				else
				{
					MessageBox.Show("Email недействительный");
				}
			}
		}

		private void PhotoButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.ShowDialog();

			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.UriSource = new Uri(openFileDialog.FileName);
			bitmapImage.EndInit();
			PhotoImage.Source = bitmapImage;
			photoImageStr = openFileDialog.SafeFileName;
		}
	}
}
