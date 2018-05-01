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
	public partial class UpdateStudent : ContentPage
	{
        string email, studnt, fn, ln, fname, lname, gndr, city, center, specialist, spfn, spln;
        DateTime DoB;
        int id;

        Student student = new Student();
        Service1Client client = new Service1Client();

        public UpdateStudent(string e, string nm)
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
                studnt = nm;


                email = e;

                GetCities();

                string idStrng = Regex.Replace(studnt, "[^0-9]+", string.Empty);
                id = Int32.Parse(idStrng);
            }
        }

        private async void GetName()
        {
            first_name.Text = await client.GetFirstnameAsync(studnt);
            last_name.Text = await client.GetLastNameAsync(studnt);
        }

        private async void GetSpecialists()
        {
            SpecialistPicker.ItemsSource = await FillSpecialistsAsync(center);
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
            center = CenterPicker.SelectedItem.ToString();

            GetSpecialists(center);
        }

        private async void GetSpecialists(string cntr)
        {
            SpecialistPicker.ItemsSource = await FillSpecialistsAsync(this.center);
        }

        private async Task<string[]> FillSpecialistsAsync(string center)
        {
            return await client.GetSpecialistsAsync(this.center);
        }

        private void SpecialistPicker_OnSelectedChanged(object sender, EventArgs e)
        {
            specialist = SpecialistPicker.SelectedItem.ToString();

            Char delimiter = ' ';
            if (!string.IsNullOrEmpty(specialist))
            {
                spfn = specialist.Split(delimiter)[0];
                spln = specialist.Split(delimiter)[1];
            }
        }

        private async Task UpdateStudent_OnClickAsync(object sender, EventArgs e)
        {
            if (fname != null)  // first name has changed
            {
                try
                {
                    Service1Client client = new Service1Client();

                    Boolean result = false;

                    result = await client.UpdateStudentfnameAsync(id, fname);

                    if (result == true)
                        await DisplayAlert(title: "Cloud Gaming Application", message: "تم تحديث الاسم الاول", cancel: "موافق");
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

            if (lname != null)
            {
                try
                {
                    Service1Client client = new Service1Client();

                    await client.OpenAsync();

                    Boolean result = false;

                    result = await client.UpdateStudentLnameAsync(id, lname);

                    if (result == true)
                        await DisplayAlert(title: "Cloud Gaming Application", message: "تم تحديث الاسم الاخير", cancel: "موافق");
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

            if (DoB != null)
            {
                try
                {
                    Service1Client client = new Service1Client();

                    await client.OpenAsync();

                    Boolean result = false;

                    result = await client.UpdateStudentDoBAsync(id, DoB);

                    if (result == true)
                        await DisplayAlert(title: "Cloud Gaming Application", message: "تم تحديث تاريخ الميلاد", cancel: "موافق");
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

            if (spfn != null || spln != null)
            {
                try
                {
                    Service1Client client = new Service1Client();

                    await client.OpenAsync();
                    string result;

                    result = await client.UpdateStudentSpecAsync(id, spfn, spln, center, email);

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
            => await Navigation.PushAsync(new parent.ParentPage(email));
    }
}