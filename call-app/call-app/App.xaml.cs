using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using call_app.Views;
using call_app.Services;
using call_app.Models;
using call_app.Services.Users;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.FirebasePushNotification;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace call_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();

			CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
				System.Console.WriteLine($"TOKEN : {p.Token}");
            };

			CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {

				System.Console.WriteLine("Received");

            };

			CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
					System.Console.WriteLine($"{data.Key} : {data.Value}");
                }


            };
        }

		protected override void OnStart()
		{
			// Handle when your app starts
			var user = new User();
			if (Application.Current.Properties.ContainsKey("userId"))
			{
				user.UserId = Application.Current.Properties["userId"] as string;
			}
			else
			{
				var userService = new UserService();
				user = userService.Create();
				Application.Current.Properties.Add("userId", user.UserId);
			}
			Share.User = user;

            StartPolling();
		}
        
		private void StartPolling() 
		{
			EventService eventService = new EventService();
            
			System.Threading.Tasks.Task.Run(async () =>
			{
			while (true)
			{
				List<Event> events = eventService.Poll();
				if (events != null && events.Count != 0)
				{
						Event myEvent = events[0];
						if (Share.calledEvent != null && Share.calledEvent.EventId.Equals(myEvent.EventId)) {
							Console.WriteLine("##### Don't print anything");
						} else {
							Device.BeginInvokeOnMainThread(async () =>
                            {
                                await MainPage.DisplayAlert(myEvent.Title, myEvent.Description, "OK");
                            });
							Console.WriteLine("#####" + events[0].Title);
						}
                        
				} 
				else 
				{
					Console.WriteLine("##### Ohh, no events registered");
				}
				await System.Threading.Tasks.Task.Delay(3000);
				}
			}).ConfigureAwait(false);
		}

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
