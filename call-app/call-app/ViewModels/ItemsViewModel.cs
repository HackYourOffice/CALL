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
        private EventService Service { get; set; }
        
        public ItemsViewModel()
        {
            Title = "Meine Events";
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
            List<Event> events = Service.GetOwn();
            foreach (var myEvent in events)
            {
				Events.Add(myEvent);
            }
        }
        //async Task ExecuteLoadItemsCommand()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
    }
}