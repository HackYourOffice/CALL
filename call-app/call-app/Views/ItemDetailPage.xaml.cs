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
		ItemDetailViewModel ViewModel;
		EventService eventService;
		Boolean registered = false;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
			eventService = new EventService();

            BindingContext = this.ViewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var myEvent = new Event
            {
				Title = "Event",
                Description = "This is an event description."
            };

			ViewModel = new ItemDetailViewModel(myEvent);
            BindingContext = ViewModel;
        }

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			if (!registered) {
				if (eventService.RegisterAt(ViewModel.Event))
                {
                    (sender as Button).Text = "Event verlassen";
					registered = !registered;
                }				
			} else {
				(sender as Button).Text = "Registriere mich!";
				registered = !registered;
			}


		}
    }
}