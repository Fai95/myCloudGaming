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

namespace myCloudGaming.specialist
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpecialistRegister : ContentPage
	{

        string fn, ln, ph, mail, pass, pass_, city, center, role;  //pass_ = pass2

        public SpecialistRegister(string r)
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
                CityPicker.Items.Add("الرياض");

                CenterPicker.Items.Add("إثراء");
            }
        }

        private void First_name_OnTextChanged(object sender, EventArgs e)
        {
            fn = first_name.Text;
        }

        private void Last_name_OnTextChanged(object sender, EventArgs e)
        {
            ln = last_name.Text;
        }

        void Phone_number_OnTextChanged(object sender, EventArgs e)
        {
            ph = phone_number.Text;
        }

        void Email_OnTextChanged(object sender, EventArgs e)
        {
            mail = email.Text;
        }

        void Pass1_OnTextChanged(object sender, EventArgs e)
        {
            pass = pass1.Text;
        }

        void Pass2_OnTextChanged(object sender, EventArgs e)
        {
            pass_ = pass2.Text;
        }

        void City_OnSelectedChanged(object sender, EventArgs e)
        {
            city = CityPicker.SelectedItem.ToString();
        }
        void Center_OnSelectedChanged(object sender, EventArgs e)
        {
            center = CenterPicker.SelectedItem.ToString();
        }

        async System.Threading.Tasks.Task SpecRegister_OnClickAsync(object sender, EventArgs e)
        {
            if (fn == null)
                first_label.TextColor = Color.Red;
            else
                first_label.TextColor = Color.Black;

            if (ln == null)
                last_label.TextColor = Color.Red;
            else
                last_label.TextColor = Color.Black;

            if (ph == null)
                phone_label.TextColor = Color.Red;

            else
                phone_label.TextColor = Color.Black;


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

            if (pass_ == null)
                pass2_label.TextColor = Color.Red;
            else
                pass2_label.TextColor = Color.Black;

            if (pass != pass_)
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
                    string result = await client.SpecialistRegisterAsync(fn, ln, ph, center, mail, pass);

                    await DisplayAlert(title: "Cloud Gaming Application", message: result.ToString(), cancel: "موافق");
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
            => await Navigation.PushAsync(new XML_S.MainPage(role));
    }
}