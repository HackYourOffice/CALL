
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using call_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace call_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CountdownPage : ContentPage
	{
        CountdownViewModel ViewModel;

      /*  public CountdownPage(CountdownViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = viewModel;
        } */

        public CountdownPage (int time)
		{
			InitializeComponent ();
           
		}
	}
}