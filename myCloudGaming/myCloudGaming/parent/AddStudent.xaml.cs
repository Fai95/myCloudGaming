using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.parent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddStudent : ContentPage
	{
        string fname, lname, gender, city, cntr, specialist, email, spFname, spLname;
        DateTime DoB;

        Service1Client client = new Service1Client();

        public AddStudent(string n)
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
                InitializeComponent();

                GetDateTime();
                email = n;

                GenderPicker.Items.Add("انثى");
                GenderPicker.Items.Add("ذكر");

                GetCities();
            }
        }

        private async void GetSpecialists()
        {
            SpecialistPicker.ItemsSource = await FillSpecialistsAsync(cntr);
        }

        private void GetDateTime()
        {
            DoB = DoBPicker.Date;
            DoBPicker.DateSelected += DoBPicker_DateSelected;
        }

        private async void GetCities()
        {
            CityPicker.ItemsSource = await FillCities();
        }

        private Task<string[]> FillCities()
        {
            return client.GetCitiesAsync();

        }

        private void First_name_OnTextChanged(object sender, EventArgs e)
            => fname = first_name.Text;

        private void Last_name_OnTextChanged(object sender, EventArgs e)
            => lname = last_name.Text;

        private void GenderPicker_OnSelectedChanged(object sender, EventArgs e)
            => gender = GenderPicker.Items.ToString();

        private void DoBPicker_DateSelected(object sender, DateChangedEventArgs e)
            => DoB = DoBPicker.Date;

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
            cntr = CenterPicker.SelectedItem.ToString();

            GetSpecialists(cntr);
        }

        private async void GetSpecialists(string cntr)
        {
            SpecialistPicker.ItemsSource = await FillSpecialistsAsync(this.cntr);
        }

        private async Task<string[]> FillSpecialistsAsync(string cntr)
        {
            return await client.GetSpecialistsAsync(this.cntr);
        }

        private void SpecialistPicker_OnSelectedChanged(object sender, EventArgs e)
        {
            specialist = SpecialistPicker.SelectedItem.ToString();

            Char delimiter = ' ';
            if (!string.IsNullOrEmpty(specialist))
            {
                spFname = specialist.Split(delimiter)[0];
                spLname = specialist.Split(delimiter)[1];
            }
        }

        private async Task AddStudent_OnClickAsync(object sender, EventArgs e)
        {
            if (fname == null)
                first_label.TextColor = Color.Red;
            else
                first_label.TextColor = Color.Black;

            if (lname == null)
                last_label.TextColor = Color.Red;
            else
                last_label.TextColor = Color.Black;

            if (gender == null)
                gender_label.TextColor = Color.Red;
            else
                gender_label.TextColor = Color.Black;

            if (DoB == null)
                dob_label.TextColor = Color.Red;
            else
                dob_label.TextColor = Color.Black;

            if (city == null)
                city_label.TextColor = Color.Red;
            else
                city_label.TextColor = Color.Black;

            if (cntr == null)
                center_label.TextColor = Color.Red;
            else
                center_label.TextColor = Color.Black;

            if (specialist == null)
                specialist_label.TextColor = Color.Red;
            else
                specialist_label.TextColor = Color.Black;

            if (fname != null && lname != null && gender != null && DoB != null
                && city != null && cntr != null && specialist != null)
            {
                Service1Client client = new Service1Client();
                try
                {
                    string result = null;

                    result = await client.AddStudentAsync(fname, lname, gender, email, DoB, cntr, spFname, spLname);

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
            else
            {
                await DisplayAlert(title: "Cloud Gaming Application", message: "NULL", cancel: "موافق");
            }
        }

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new parent.ParentPage(email));
    }
}