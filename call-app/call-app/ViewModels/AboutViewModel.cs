using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace call_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
		private String text = "dein Text";
		public String Text{
			get { return text; }
            set { SetProperty(ref text, value); }
		}

        public AboutViewModel()
        {
            Title = "Scan QR";
        }
       
    }
}