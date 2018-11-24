using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using call_app.Models;
using call_app.ViewModels;

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

        public ItemDetailPage()
        {
            InitializeComponent();

            var myEvent = new Event
            {
				Title = "Event",
                Description = "This is an event description."
            };

			viewModel = new ItemDetailViewModel(myEvent);
            BindingContext = viewModel;
        }
    }
}