using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using call_app.Views;
using call_app.Services;
using call_app.Models;
using call_app.Services.Users;
using System.Threading.Tasks;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace call_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
						Console.WriteLine("#####" + events[0].Title);
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
