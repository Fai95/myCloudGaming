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

namespace myCloudGaming.XML_S
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgetPass : ContentPage
	{
        string uname, role, pass;
        public ForgetPass(string r)
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
                RestoreInfo_lable_Clicked();
                role = r;
            }
        }

        private void Uname_OnTextChanged(object sender, EventArgs e)
        {
            uname = email.Text;
        }

        private void RestoreInfo_lable_Clicked()
        {
            restoreInfo_label.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    DisplayAlert("تعليمات", "1- ادخل البريد الإلكتروني المسجل بالنظام\n 2- اضغط على 'استعادة'\n 3- ستصلك كلمة المرور المسجلة عن طريق البريد الإلكتروني ", "موافق");
                })
            });
        }

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new XML_S.Login(role));


        private async System.Threading.Tasks.Task Restore_OnClickAsync()
        {
            if (!Regex.IsMatch(uname, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")
             || email.Text == null)
            {
                email_label.TextColor = Color.Red;
            }

            else
            {
                Service1Client client = new Service1Client();
                // AndrWebServiceSoapClient client = new AndrWebServiceSoapClient(); 
                try
                {
                    Boolean isExist = false;
                    isExist = await client.EmailIsExistsAsync(uname, role);

                    if (isExist)
                    {
                        pass = await client.GetPassAsync(uname, role);

                        await DisplayAlert("", pass, "ok");

                        bool check = SendEmail(uname, pass);

                        if (check)
                            await DisplayAlert("استعادة كلمة المرور", "تم ارسال معلومات كلمة المرور الى بريدكم الإلكتروني", "موافق");

                        else
                            await DisplayAlert("استعادة كلمة المرور", "خطأ!!", "موافق");
                    }

                    else
                    {
                        await DisplayAlert("استعادة كلمة المرور", "البريد الإلكتروني المدخل غير مسجل", "موافق");
                    }
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

            /*
             ckeck if the email is existed 
             call restoring function

             if( client.EmailIsExistsAsync(email,role))
                {   
                    string pass = client.GetPassAsync(email, role);
                    display msg
                 }
             */
        }

        private bool SendEmail(string email, string pass)
        {
            //var emailMsg = CrossMessaging.Current.EmailMessenger;

            //try
            //{
            //    if (emailMsg.CanSendEmail)
            //    {
            //        emailMsg.SendEmail(email, "cloud gaming application", pass);

            //        return true;
            //    }

            //    else
            //        return false;
            //}
            //catch (Exception e)
            //{
            //    DisplayAlert("exception", e.Message, "ok");
            //    return false;
            //}
            return true;
        }
    }
}