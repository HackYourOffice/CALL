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
	public partial class CountdownPage : ContentPage
	{
		public CountdownPage (int time)
		{
			InitializeComponent ();
		}
	}
}