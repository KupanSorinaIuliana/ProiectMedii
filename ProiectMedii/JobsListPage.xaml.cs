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
    public partial class JobsListPage : ContentPage
    {
        public JobsListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetJobAsync();
        }
        async void DeleteBtn(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var job = (Job)b.BindingContext;
            await App.Database.DeleteJobAsync(job);
            listView.ItemsSource = await App.Database.GetJobAsync();
        }
    }
}