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
    public partial class ConditionsListPage : ContentPage
    {
        public ConditionsListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetTypeOfConditionAsync();
        }
        async void DeleteBtn(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var condition = (TypeOfCondition)b.BindingContext;
            await App.Database.DeleteTypeOfConditionAsync(condition);
            listView.ItemsSource = await App.Database.GetTypeOfConditionAsync();
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TypeOfCondition p;
            p = e.SelectedItem as TypeOfCondition;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Page1(p)
                {
                    BindingContext = new TypeOfCondition()
            });
               
            }
        }
    }
}