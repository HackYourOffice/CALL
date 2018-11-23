using System;
using call_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace call_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
		AboutViewModel aboutViewModel;

        public AboutPage()
        {
            InitializeComponent();

			BindingContext = aboutViewModel = new AboutViewModel();
        }

		private async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var options = new MobileBarcodeScanningOptions();
			options.PossibleFormats.Add(BarcodeFormat.QR_CODE);
			var scan = new ZXingScannerPage(options);
			await Navigation.PushAsync(scan);

			scan.OnScanResult+=(result) => 
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					await Navigation.PopAsync();
					aboutViewModel.Text = result.Text;
				});
			};
           
		}
    }
}