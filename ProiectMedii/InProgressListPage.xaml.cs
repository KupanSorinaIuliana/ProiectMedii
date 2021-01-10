using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMedii.Models;

namespace ProiectMedii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InProgressListPage : ContentPage
    {
        public InProgressListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetJobInProgressAsync();
        }

        async void DeleteBtn(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var job = (Job)b.BindingContext;
            await App.Database.DeleteJobAsync(job);
            listView.ItemsSource = await App.Database.GetJobInProgressAsync();
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Job j;
            j = e.SelectedItem as Job;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Page3(j)
                {
                    BindingContext = new Job()
                });
            }
        }
    }
}