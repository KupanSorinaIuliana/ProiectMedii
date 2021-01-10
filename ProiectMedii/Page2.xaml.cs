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
    public partial class Page2 : ContentPage
    {
        Priority priority;
        public Page2(Priority priority)
        {
            InitializeComponent();
            this.priority = priority;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void Save_btn(object sender, EventArgs e)
        {
            var p = (Priority)BindingContext;
            p.ID = priority.ID;
            await App.Database.SavePriorityAsync(p);
            await Navigation.PopAsync();
        }

        private async void Cancel_btn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}