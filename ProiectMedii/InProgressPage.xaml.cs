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
    public partial class InProgressPage : ContentPage
    {
        public InProgressPage()
        {
            InitializeComponent();
        }
        async void AddButton(object sender, EventArgs e)
        {
            var job = (Job)BindingContext;
            job.TypeId = 2;
            await App.Database.SaveJobAsync(job);
            await Navigation.PushAsync(new InProgressPage()
            {
                BindingContext = new Job()
            });
        }

        async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void InProgressList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InProgressListPage());
        }
    }
}