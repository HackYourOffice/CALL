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

			var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats.Add(BarcodeFormat.QR_CODE);
            options.PossibleFormats.Add(BarcodeFormat.EAN_13);

            var scanView = new ZXingScannerView();
			scanView.HorizontalOptions = LayoutOptions.FillAndExpand;
			scanView.VerticalOptions = LayoutOptions.FillAndExpand;
            
            scanView.Options = options;
			scanView.IsScanning = true;
			scanView.OnScanResult += (result) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					aboutViewModel.Text = result.Text;
					scanView.IsScanning = false;
				});
			};

            ScanPageContent.Children.Add(scanView);

			BindingContext = aboutViewModel = new AboutViewModel();
        }
    }
}