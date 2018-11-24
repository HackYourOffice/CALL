using System;
using System.Collections.Generic;
using call_app.Models;
using call_app.Services;
using call_app.Services.Events;

namespace call_app.ViewModels
{
	public class StatisticsViewModel : BaseViewModel
	{
		private String usersAcceptedCall;
		public String UsersAcceptedCall
        {
            get { return usersAcceptedCall; }
            set { SetProperty(ref usersAcceptedCall, value); }
        }

		private String usersDelayedCall;
		public String UsersDelayedCall
		{
            get { return usersDelayedCall; }
            set { SetProperty(ref usersDelayedCall, value); }
        }

        
        public StatisticsViewModel(Event myEvent)
        {
			EventService eventService = new EventService();

			System.Threading.Tasks.Task.Run(async () =>
			{
			for (int i = 0; i < 20; i++)
				{
					EventSubscriber subscriber = eventService.NumberOfSubscribers(myEvent);
					if (subscriber != null)
					{
						int accepted = subscriber.TotalAccepted;
						int total = subscriber.TotalSubscribers;
						int delayed = total - accepted;

						UsersAcceptedCall = accepted + " / " + total;
						UsersDelayedCall = delayed + " / " + total;
					}
					else
					{
					}
					await System.Threading.Tasks.Task.Delay(3000);
				}
			}).ConfigureAwait(false);
        }
    }
}
