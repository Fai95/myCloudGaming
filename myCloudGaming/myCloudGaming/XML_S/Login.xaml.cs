using myCloudGaming.Classes;
using AsmxReference;
using System;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using myCloudGamingReference;

namespace myCloudGaming.XML_S
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        string uname, password;
        string role;

        public Login(string r)
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

                role = r;
                Forgetpass_lable_Clicked();
            }
        }

        private void Uname_OnTextChanged(object sender, EventArgs e)
            => uname = email.Text;

        private void Password_OnTextChanged(object sender, EventArgs e)
            => password = pass.Text;

        private async System.Threading.Tasks.Task LoginBtn_ClickedAsync(object sender, EventArgs e)
        {
            if (email.Text != null)
            {
                if (!Regex.IsMatch(uname, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
                {
                    email_label.TextColor = Color.Red;
                }
                else if (pass.Text == null)
                    password_label.TextColor = Color.Red;
                else
                {
                    Service1Client client = new Service1Client();
                  //  AndrWebServiceSoapClient client = new AndrWebServiceSoapClient(AndrWebServiceSoapClient.EndpointConfiguration.AndrWebServiceSoap12); 
                    try
                    {
                        //  Result check = new Result();
                        bool check = false; 
                        email_label.TextColor = Color.Black;
                        password_label.TextColor = Color.Black;

                        if (check != null)
                        {                           
                            check = await client.LoginAsync(uname, password, role);
                        }
                       
                        else
                            await DisplayAlert("خطأ", "", "موافق");

                        if (check == false)
                            await DisplayAlert("خطأ", "", "موافق");
                        else
                            AsyncLog();
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
            else
                email_label.TextColor = Color.Red;
        }

        private async void AsyncLog()
        {
            if (role == "ولي أمر")
                await Navigation.PushAsync(new parent.ParentPage(uname));
            else if (role == "أخصائي")
                await Navigation.PushAsync(new specialist.ChooseStudent(uname));
            else
                await Navigation.PushAsync(new admin.ManageAccounts(uname));
        }

        private void Forgetpass_lable_Clicked()
        {
            forgetpass_label.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new XML_S.ForgetPass(role));
                })
            });
        }

        private async void Return_OnClicked()
          => await Navigation.PushAsync(new XML_S.MainPage(role));
    }
}