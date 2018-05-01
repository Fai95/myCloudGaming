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
	public partial class UnConfSpecialist : ContentPage
	{
        string email, name;
        List<string> specialist = new List<string>();
        Service1Client client = new Service1Client();

        public UnConfSpecialist(string spec, string mail)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                DisplayAlert("Cloud Gaming Application", Connectivity.Text, "موافق");
            }
            else
            {
                name = spec;
                specialist_name.Text = name;

                GetInfo();

                email = mail;
            }
        }

        private async void GetInfo()
        {
            try
            {

                specialist.AddRange(await client.AdminSpecialisttInfoAsync(name));

                if (specialist != null)
                {
                    specialist_name.Text = specialist[0];
                    specialist_number.Text = specialist[3];
                    specialist_email.Text = name.ToString();
                    center.Text = specialist[4];
                }
                else
                {
                    await DisplayAlert("exception", "null", "ok");

                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("exception", ex.Message, "ok");

            }

        }

        private async void Return_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new admin.SpeciaLists(email));
        }

        private async System.Threading.Tasks.Task UnConfirm_OnClickedAsync(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            try
            {
                Boolean check = false;

                check = await client.ConfirmSpecialistAsync(name, false);

                if (check == true)
                    await DisplayAlert("Cloud Gaming Application", "تم إلغاء تفعيل الحساب بنجاح", "موافق");
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
}