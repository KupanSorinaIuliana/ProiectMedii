using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrioritiesPage : ContentPage
    {
        public PrioritiesPage()
        {
            InitializeComponent();
        }

        async void PrioritiesList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrioritiesListPage());
        }

         async void AddButton(object sender, EventArgs e)
        {
            var priority = (Priority)BindingContext;
            await App.Database.SavePriorityAsync(priority);
            await Navigation.PushAsync(new PrioritiesPage()
            {
                BindingContext = new Priority()
            });
        }

         async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}