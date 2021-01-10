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
    public partial class ToDoEntryPage : ContentPage
    {
        public ToDoEntryPage()
        {
            InitializeComponent();
        }

        async void PriorityButton(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new PrioritiesPage() {
                 BindingContext = new Priority()
             });

        }

        async void ToDoButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoPage()
            {
                BindingContext = new Job()
            });
        }

        async void InProgressButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InProgressPage()
            {
                BindingContext = new Job()
            });
        }

        async void DoneButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DonePage()
            {
                BindingContext = new Job()
            });
        }

        async void JobsButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JobsListPage());
        }

        async void ConditionButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConditionsPage()
            {
                BindingContext = new TypeOfCondition()
            });
        }
    }
}