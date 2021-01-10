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
    public partial class Page3 : ContentPage
    {
        Job job;
        public Page3(Job job)
        {
            InitializeComponent();
            this.job = job;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Save_btn(object sender, EventArgs e)
        {
            var j = (Job)BindingContext;
            j.ID = job.ID;
            j.TypeId = job.TypeId;
            await App.Database.SaveJobAsync(j);
            await Navigation.PopAsync();
        }

       async void Cancel_btn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}