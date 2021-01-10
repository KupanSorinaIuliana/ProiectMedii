using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMedii.Models;
using ProiectMedii.Data;

namespace ProiectMedii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConditionsPage : ContentPage
    {
        public ConditionsPage()
        {
            InitializeComponent();
        }

        async void AddButton(object sender, EventArgs e)
        {
            var condition = (TypeOfCondition)BindingContext;
            await App.Database.SaveTypeOfConditionAsync(condition);
            await Navigation.PushAsync(new ConditionsPage()
            {
                BindingContext = new TypeOfCondition()
            });
        }

        async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void ConditionsList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConditionsListPage());
        }
    }
}