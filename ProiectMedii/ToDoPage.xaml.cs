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
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        async void AddButton(object sender, EventArgs e)
        {
            var job = (Job)BindingContext;
            job.TypeId = 1;
            await App.Database.SaveJobAsync(job);
            await Navigation.PushAsync(new ToDoPage()
            {
                BindingContext = new Job()
            });
        }

        async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void ToDoList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoListPage());
        }
    }
}