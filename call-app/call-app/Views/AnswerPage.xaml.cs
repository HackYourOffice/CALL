using call_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace call_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerPage : ContentPage
	{
        Event currentEvent = new Event
        {
            Title =  "DFIRGJIEG"
        }; 


		public AnswerPage ()
		{
            InitializeComponent();
        }
       
        async void On5MinClicked(object sender, EventArgs args)
        {
            int time = 5;
            await Navigation.PushModalAsync(new NavigationPage(new CountdownPage(time)));
        }
        async void On10MinClicked(object sender, EventArgs args)
        {
            int time = 10;
            await Navigation.PushModalAsync(new NavigationPage(new CountdownPage(time)));
        }

	}
}