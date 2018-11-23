using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using call_app.Models;
using call_app.Views;
using call_app.Services;
using System.Collections.Generic;

namespace call_app.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableCollection<Event> Events { get; set; }
		public Command LoadItemsCommand { get; set; }
		public String NoListAvailable { get; set; }
		private Boolean isListEmpty = true;
		public Boolean IsListEmpty 
		{ 
			get { return isListEmpty; }  
			set{SetProperty(ref isListEmpty, value);}
		}
		private Boolean isListVisible = false;
		public Boolean IsListVisible 
		{ 
			get { return isListVisible; }  
			set{SetProperty(ref isListVisible, value);}
		}

		private EventService Service { get; set; }
        
        public ItemsViewModel()
        {
            Title = "Meine Events";
			NoListAvailable = "Du hast noch keine Events";
            Events = new ObservableCollection<Event>();
            Service = new EventService();
			LoadItemsCommand = new Command(async () => await ExecuteLoadEventsCommand());
            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, myEvent) =>
            //{
            //    var newEvent = myEvent as Event;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadEventsCommand()
        {
            //Service.Create(new CreateEvent("Hallo", "duda"));
            List<Event> events = Service.GetOwn();
			IsListEmpty = events.Count == 0;
			IsListVisible = !isListEmpty;
            foreach (var myEvent in events)
            {
				Events.Add(myEvent);
            }
        }
    }
}