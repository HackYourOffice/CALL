using System;
using System.Collections.Generic;
using call_app.Models;
using call_app.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace call_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CallPage : ContentPage
    {
		Event CallEvent;
		EventService eventService;
        
		public CallPage(Event callEvent)
        {
			InitializeComponent();

			CallEvent = callEvent;
			eventService = new EventService();
        }

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			if (eventService.NotifySubscriberOf(CallEvent)) {
				Share.calledEvent = CallEvent;
				Device.BeginInvokeOnMainThread(async () =>
				{
					await Navigation.PushAsync(new StatisticsPage(CallEvent));
				});
			}
		}
    }
}
