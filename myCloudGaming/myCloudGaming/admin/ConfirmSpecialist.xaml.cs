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
	public partial class ConfirmSpecialist : ContentPage
	{
        List<string> specialist = new List<string>();
        Service1Client client = new Service1Client();

        string email, speci, first, last;

        public ConfirmSpecialist(string mail, string spec)
        {
            InitializeComponent();

            email = mail;
            speci = spec;


            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                DisplayAlert("Cloud Gaming Application", Connectivity.Text, "موافق");
            }

            else
            {
                try
                {
                    GetInfo();
                }
                catch (Exception ex)
                {
                    DisplayAlert("exception", ex.Message, "ok");
                }
            }
        }

        private async void GetInfo()
        {
            Service1Client client = new Service1Client();
            try
            {
                foreach (var i in await client.AdminSpecialisttInfoAsync(speci))
                        specialist.Add(i.ToString());

                specialist_name.Text = specialist[0];
                specialist_number.Text = specialist[3];
                specialist_email.Text = speci.ToString();
                center.Text = specialist[4];
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

        private async System.Threading.Tasks.Task UnConfirm_OnClickedAsync(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            try
            {
                Boolean check = false;

                check = await client.ConfirmSpecialistAsync(speci, true);

                if (check == true)
                    await DisplayAlert("Cloud Gaming Application", "تم تفعيل الحساب بنجاح", "موافق");
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

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new admin.SpeciaLists(email));
    }
}