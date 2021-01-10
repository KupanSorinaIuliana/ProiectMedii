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
    public partial class Page1 : ContentPage
    {
        TypeOfCondition condition;
        public Page1(TypeOfCondition condition)
        {
            InitializeComponent();
            this.condition = condition;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Save_btn(object sender, EventArgs e)
        {
            var c = (TypeOfCondition)BindingContext;
            c.ID = condition.ID;
            await App.Database.SaveTypeOfConditionAsync(c);
            await Navigation.PopAsync();
        }

        private async void Cancel_btn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}