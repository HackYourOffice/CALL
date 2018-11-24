using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using call_app.Models;
using call_app.ViewModels;
using call_app.Services;

namespace call_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;


        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            Event myEvent = new Event();
            EventService eventService = new EventService();
            eventService.NotifySubscriberOf(myEvent);
            (sender as Button).Text = "Called!";
        }

        public ItemDetailPage()
        {


            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}