using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CofirmationCode : ContentPage
	{
        string code, city, center, role;
        static int i = 0;
        List<string> citiesList = new List<string>();

        Service1Client client = new Service1Client();
        InternetConnection connection = new InternetConnection();

        public CofirmationCode(string r)
        {
            InitializeComponent();
            role = r;

            NavigationPage.SetHasNavigationBar(this, false);

            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                DisplayAlert("Cloud Gaming Application", Connectivity.Text, "موافق");
            }

            else
            {
                GetCities();

                Contact_us_Clicked();
            }
        }

        public CofirmationCode(bool returned)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                layout.IsVisible = false;
                Connectivity.IsVisible = true;
            }

            else
            {
                GetCities();
            }

        }

        private async void GetCities()
        {
            CityPicker.ItemsSource = await FillCities();
        }

        private Task<string[]> FillCities()
        {
            return client.GetCitiesAsync();
        }

        private void CityPicker_OnSelectedChanged(object sender, EventArgs e)
        {
            city = CityPicker.SelectedItem.ToString();
            GetCenters(city);
        }

        private async void GetCenters(string city)
        {
            CenterPicker.ItemsSource = await FillCenters(this.city);
        }

        private Task<string[]> FillCenters(string city)
        {
            return client.GetCentersAsync(this.city);
        }

        private void CenterPicker_OnSelectedChanged(object sender, EventArgs e)
        {
            center = CenterPicker.SelectedItem.ToString();
        }

        private string GetMsg()
        {
            string message;
            message = "الرجاء تحديد المدينه لاختيار المركز \n ثم ادخال رمز المركز للتأكيد";
            return message;
        }

        private void Code_OnTextChanged(object sender, EventArgs e)
            => code = Acode.Text;

        private async void Return_OnClicked(object sender, EventArgs e)
         => await Navigation.PushAsync(new XML_S.MainPage(role));

        private async System.Threading.Tasks.Task CodeEnry_ClickedAsync(object sender, EventArgs e)
        {
            if (city == null)
                city_label.TextColor = Color.Red;

            else if (center == null)
                center_label.TextColor = Color.Red;

            else
            {
                Service1Client client = new Service1Client();
                try
                {
                    bool result = await client.AdminConfirmationAsync(center, code);

                    if (!result)
                    {
                        i++;
                        await DisplayAlert("Cloud Gaming Application", "الرمز المدخل غير صحيح", "موافق");

                        if (i == 3)
                        {
                            Acode.Text = null;
                            Acode.IsEnabled = false;
                            bool codeCheck = await client.RandomStringAsync(5, center);

                            await DisplayAlert("Cloud Gaming Application", "انتهت صلاحية الرمز \n تواصل معنا للمساعده ", "موافق");
                        }
                    }
                    else
                        AdminRegister();
                }

                catch (Exception ex)
                {
                    await DisplayAlert("exception", ex.Message, "ok");
                }
                finally
                {
                    await client.CloseAsync();
                }
            }
        }
        private void Contact_us_Clicked()
        {
            Contact_us_Label.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    try
                    {
                        //var emailMsg = CrossMessaging.Current.EmailMessenger;

                        //if (emailMsg.CanSendEmail)
                        //{
                        //    emailMsg.SendEmail("cloudgamingapp@gmail.com", "Cloud Gaming Application");
                        //}
                        return;
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Exception", ex.Message, "ok");
                    }
                })
            });
        }

        private async void AdminRegister()
            => await Navigation.PushAsync(new admin.AdminRegister(center));
    }
}