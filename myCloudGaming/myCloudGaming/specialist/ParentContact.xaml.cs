using myCloudGaming.Classes;
using myCloudGamingReference;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.specialist
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParentContact : ContentPage
	{
        Service1Client client = new Service1Client();
        Student student = new Student();

        int id;
        string parentEmail, parentPhone, studnt, email;

        public ParentContact(string mail, int st)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                DisplayAlert("Cloud Gaming Application", "الرجاء التحقق من الاتصال بشبكة الإنترنت", "موافق");
            }
            else
            {
                InitializeComponent();

                email = mail;
                id = st;

                // name.Text = " اسم الطالب:" + student; 


                try
                {
                    GetEmail();
                    GetPhone();
                }
                catch (Exception ex)
                {
                    DisplayAlert("Exception", ex.Message, "ok");
                }
            }
        }

        private async void GetPhone()
        {
            try
            {
                parentPhone = await client.GetParentNumAsync(id, email);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }
            finally
            {
                await client.CloseAsync();
            }
        }

        private async void GetEmail()
        {
            try
            {
                parentEmail = await client.GetParentEmailAsync(id, email);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }
            finally
            {
                await client.CloseAsync();
            }
        }

        private void Sms_Clicked(object sender, EventArgs e, string parent)
        {
            try
            {
                //
            }
            catch (Exception ex)
            {
                DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            try
            {
                //var phoneCallTask = CrossMessaging.Current.PhoneDialer;

                //if (phoneCallTask.CanMakePhoneCall)
                //{
                //    phoneCallTask.MakePhoneCall(parentPhone);
                //}
            }
            catch (Exception ex)
            {
                DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        private void Email_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                //var emailMsg = CrossMessaging.Current.EmailMessenger;

                //if (emailMsg.CanSendEmail)
                //{
                //    emailMsg.SendEmail(parentEmail, "Cloud Gaming Application");
                //}
                //return; 
            }
            catch (Exception ex)
            {
                DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new specialist.StudentResults(email, id));
    }
}