using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminRegister : ContentPage
	{
        string center, name, mail, pass, pass11, role;

        public AdminRegister(string cntr, string r = "مشرف")
        {
            InitializeComponent();

            role = r;
            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                DisplayAlert("Cloud Gaming Application", Connectivity.Text, "موافق");
            }

            else
            {
                center = cntr;
            }
        }

        private void Name_OnTextChanged(object sender, EventArgs e)
           => name = first_name.Text;

        private void Email_OnTextChanged(object sender, EventArgs e)
           => mail = email.Text;

        private void Pass1_OnTextChanged(object sender, EventArgs e)
           => pass = pass1.Text;

        private void Pass2_OnTextChanged(object sender, EventArgs e)
           => pass11 = pass2.Text;

        private async System.Threading.Tasks.Task Register_OnClickAsync(object sender, EventArgs e)
        {
            if (name == null)
                name_label.TextColor = Color.Red;
            else
                name_label.TextColor = Color.Black;

            if (email.Text == null)
                email_label.TextColor = Color.Red;

            else
            {
                if (!Regex.IsMatch(email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
                {
                    email_label.TextColor = Color.Red;
                }

                else
                    email_label.TextColor = Color.Black;
            }
            if (pass == null)
                pass1_label.TextColor = Color.Red;
            else
                pass1_label.TextColor = Color.Black;

            if (pass11 == null)
                pass2_label.TextColor = Color.Red;
            else

            if (pass != pass11)
            {
                pass1.Text = pass2.Text = null;
                pass1_label.TextColor = Color.Red;
                pass1_label.FontAttributes = FontAttributes.Bold;
                pass2_label.TextColor = Color.Red;
                pass2_label.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                Service1Client client = new Service1Client();

                try
                {
                    string result;

                    result = await client.AdminRegiserAsync(name, mail, pass, center);

                    await DisplayAlert(title: "Cloud Gaming Application", message: result, cancel: "موافق");
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

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new admin.CofirmationCode(role));
    }
}