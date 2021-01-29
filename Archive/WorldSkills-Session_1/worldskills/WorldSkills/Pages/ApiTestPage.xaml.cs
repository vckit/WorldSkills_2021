using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using WorldSkills.Models;
using WorldSkills.Models.Request;
using WorldSkills.Models.Response;

namespace WorldSkills.Pages
{
	/// <summary>
	/// Логика взаимодействия для ApiTestPage.xaml
	/// </summary>
	public partial class ApiTestPage : Page
	{
		public ApiTestPage()
		{
			InitializeComponent();
		}

		Fines Fines;
		Data Data;
		int FineInc = 0;

		private void GetFinesButton_Click(object sender, RoutedEventArgs e)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.CreateHttp("http://solutions2019.hakta.pro/api/getFines?participant=06");
			httpWebRequest.Method = "GET";

			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using (Stream stream = httpWebResponse.GetResponseStream())
			{
				using (StreamReader streamReader = new StreamReader(stream))
				{
					var Result = streamReader.ReadToEnd();
					Console.WriteLine(Result);

					Fines = JsonConvert.DeserializeObject<Fines>(Result);
					
				}
			}
			LoadFine(Fines);
		}

		public void LoadFine(Fines fines)
		{
			Data data = Fines.Datas[FineInc];
			Data = data;
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.UriSource = new Uri(data.Photo);
			bitmapImage.EndInit();

			carNumBox.Text = data.CarNum;
			licenceNumBox.Text = data.LicenceNum;
			createDateBox.Text = data.CreateDate.ToString();
			regionNumBox.Text = data.Region;

			finesImage.Source = bitmapImage;
			FineInc++;
		}

		private void PostFinesButton_Click(object sender, RoutedEventArgs e)
		{

			if (Fines != null)
			{

				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.CreateHttp("http://solutions2019.hakta.pro/api/postFine?participant=06");
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/json";

				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					using (StreamWriter streamWriter = new StreamWriter(stream))
					{
						postFine postFine = new postFine()
						{
							Id = Data.Id.ToString(),
							Message = "not recognized"
						};

						var Fine = JsonConvert.SerializeObject(postFine);
						streamWriter.WriteLine(Fine);
					}
				}

				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (Stream stream = httpWebResponse.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(stream))
					{
						var Result = streamReader.ReadToEnd();
						
					}
				}
				LoadFine(Fines);
			}
			else
			{
				MessageBox.Show("Загрузите штрафы");
			}
		}

		private void NextFineButton_Click(object sender, RoutedEventArgs e)
		{
			LoadFine(Fines);
		}
	}
}
