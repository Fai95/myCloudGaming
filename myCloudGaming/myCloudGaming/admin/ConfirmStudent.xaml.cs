using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmStudent : ContentPage
	{
        string email, studnt;
        int id;

        List<string> student = new List<string>();

        public ConfirmStudent(string em, string stud)
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
                email = em;
                studnt = stud;
                AwaitedCall();

                string idStrng = Regex.Replace(stud, "[^0-9]+", string.Empty);
                id = Int32.Parse(idStrng);
            }
        }

        private async void AwaitedCall()
        {
            await GetSudentInfoAsync();

        }
        private async System.Threading.Tasks.Task GetSudentInfoAsync()
        {
            Service1Client client = new Service1Client();

            try
            {
                foreach (var i in await client.AdminStudentInfoAsync(id))
                    student.Add(i.ToString());
               
                if (student != null)
                {
                    student_name.Text = student[0];
                    student_age.Text = student[3];
                    parent_name.Text = student[4];
                    parent_email.Text = student[5];
                    parent_number.Text = student[6];
                    specialist_name.Text = student[7];
                    specialist_email.Text = student[8];
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
            finally
            {
                await client.CloseAsync();
            }
        }

        private async System.Threading.Tasks.Task Confirm_OnClickedAsync(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            try
            {
                Boolean result;

                result = await client.ConfirmStudentAsync(id, true);

                if (result)
                    await DisplayAlert(title: "Cloud Gaming Application", message: "تم تفعيل الحساب بنجاح", cancel: "موافق");
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
        {
            await Navigation.PushAsync(new admin.StudentsLists(email));
        }
    }
}