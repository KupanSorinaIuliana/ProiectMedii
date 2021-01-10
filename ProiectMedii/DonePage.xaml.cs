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
    public partial class DonePage : ContentPage
    {
        public DonePage()
        {
            InitializeComponent();
        }
        async void AddButton(object sender, EventArgs e)
        {
            var job = (Job)BindingContext;
            job.TypeId = 3;
            await App.Database.SaveJobAsync(job);
            await Navigation.PushAsync(new DonePage()
            {
                BindingContext = new Job()
            });
        }

        async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void DoneList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoneListPage());
        }
    }
}
