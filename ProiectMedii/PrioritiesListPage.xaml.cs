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
    public partial class PrioritiesListPage : ContentPage
    {
        public PrioritiesListPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetPrioritiesAsync();
        }
        async void DeleteBtn(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var priority = (Priority)b.BindingContext;
            await App.Database.DeletePriorityAsync(priority);
            listView.ItemsSource = await App.Database.GetPrioritiesAsync();
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Priority p;
            p = e.SelectedItem as Priority;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Page2(p)
                {
                    BindingContext = new Priority()
                });
            }
        }
    }
}