using System;
using call_app.Models;
using call_app.Services;
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
		ZXingScannerView scannerView;

		private EventService eventService;

		public AboutPage()
		{
			InitializeComponent();
			eventService = new EventService();

			InitSchmarn();

			ScanPageContent.Children.Add(scannerView);
            
			BindingContext = aboutViewModel = new AboutViewModel();
		}
        
		private async void OpenEventDetail(Result result) 
		{
			Event scannedEvent = eventService.GetById(result.Text);
			aboutViewModel.Text = result.Text;
			var vm = new ItemDetailViewModel(scannedEvent);
			await Navigation.PushAsync(new ItemDetailPage(vm));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			InitSchmarn();
		}

		private void InitSchmarn() 
		{
			var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats.Add(BarcodeFormat.QR_CODE);
            options.PossibleFormats.Add(BarcodeFormat.EAN_13);

            scannerView = new ZXingScannerView();
            scannerView.HorizontalOptions = LayoutOptions.FillAndExpand;
            scannerView.VerticalOptions = LayoutOptions.FillAndExpand;
            scannerView.Options = options;
            scannerView.IsScanning = true;
            scannerView.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(() => OpenEventDetail(result));
                scannerView.IsScanning = false;
            };
		}
	}
}