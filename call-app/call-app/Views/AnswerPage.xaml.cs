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
		public AnswerPage ()
		{
            InitializeComponent();
        }
       
        async void On5MinClicked(object sender, EventArgs args)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        async void On10MinClicked(object sender, EventArgs args)
        {
          //  await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

	}
}