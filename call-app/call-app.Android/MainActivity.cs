using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Nfc;
using Android.Content;
using Android.Nfc.Tech;

namespace call_app.Droid
{
    [Activity(
        Label = "call_app", 
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        NfcAdapter nfcAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            nfcAdapter = NfcAdapter.GetDefaultAdapter(this);

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnPause()
        {
            base.OnPause();
            nfcAdapter.DisableForegroundDispatch(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, Class).AddFlags(ActivityFlags.SingleTop), (PendingIntentFlags)0);
            var filter = new IntentFilter(NfcAdapter.ActionTagDiscovered);
            var techList = new string[]
            {
                "android.nfc.tech.NfcA",
                "android.nfc.tech.IsoDep",
            };

            nfcAdapter.EnableForegroundDispatch(this, pendingIntent, new[] { filter }, new[] { techList });
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            var tag = (Tag)intent.GetParcelableExtra(NfcAdapter.ExtraTag);
            Console.WriteLine("supported techlist:");
            foreach (var tech in tag.GetTechList()) Console.WriteLine("\t" + tech);

            ReadIsoDep(tag);
        }

        void ReadIsoDep(Tag tag)
        {
            var iso = IsoDep.Get(tag);
            Console.WriteLine("Connecting ...");
            iso.Connect();

            /* var result = await iso.SendCommandAsync (DesfireCommand.Version);
             result.dumpResponse(); */

            iso.Close();

        }

    }
}