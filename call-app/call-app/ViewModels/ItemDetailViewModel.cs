using System;

using call_app.Models;

namespace call_app.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
		public Event Event { get; set; }
		public ItemDetailViewModel(Event myEvent = null)
        {
			Title = myEvent?.Title;
			Event = myEvent;
        }
    }
}
