using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.parent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParentPage : ContentPage
	{
        string student, email, fn, ln;
        int id;

        Service1Client client = new Service1Client();

        public ParentPage(string n)
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
                try
                {
                    email = n;
                    GetStudents();
                }
                catch (Exception ex)
                {
                    DisplayAlert("exception", ex.Message, "ok");
                }
            }
        }

        private async void GetStudents()
        {
            StudentPicker.ItemsSource = await FillStudentsAsync();
        }

        private async Task<string[]> FillStudentsAsync()
        {
            return await client.GetStudentsAsync(email, "ولي أمر", true);
        }

        private void StudentPicker_OnSelectedChanged(object sender, EventArgs e)
        {
            student = StudentPicker.SelectedItem.ToString();
            Char delimiter = ' ';
            if (!string.IsNullOrEmpty(student))
            {
                fn = student.Split(delimiter)[0];
                ln = student.Split(delimiter)[1];
                string idStrng = Regex.Replace(student, "[^0-9]+", string.Empty);
                id = Int32.Parse(idStrng);
            }
        }

        private async void Logout_OnClicked(object sender, EventArgs e)
           => await Navigation.PushAsync(new Roles());

        private async void Add_OnClicked(object sender, EventArgs e)
           => await Navigation.PushAsync(new parent.AddStudent(email));

        private async void Choose_OnClick(object sender, EventArgs e)
        {
            if (student == null)
                student_Label.TextColor = Color.Red;
            else
            {
                student_Label.TextColor = Color.Black;
                await Navigation.PushAsync(new Games.MainGamesList(email, id));
            }
        }
        private async void Update_OnClick(object sender, EventArgs e)
        {
            if (student == null)
                student_Label.TextColor = Color.Red;
            else
            {
                student_Label.TextColor = Color.Black;
                await Navigation.PushAsync(new parent.UpdateStudent(email, student));
            }
        }

        private async Task Delete_OnClickedAsync()
        {
            if (student == null)
                student_Label.TextColor = Color.Red;
            else
            {
                student_Label.TextColor = Color.Black;

                Service1Client client1 = new Service1Client();
                try
                {
                    Boolean result = false;

                    result = await client1.DeleteStudentAsync(fn, ln, email);

                    if (result == false)
                        return;
                    else

                        await DisplayAlert("Cloud Gaming Application", "تم حذف الطالب بنجاح", "موافق");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("exception", ex.Message, "ok");
                }
                finally
                {
                    await client1.CloseAsync();
                }
            }
        }
    }
}