using System;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Geolocation;
using System.Threading.Tasks;
using Android.App;
using MineApp;

namespace MineApp.Droid
{
    [Activity(Label = "MineApp", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

                GetLocation();
                MobileMineApp.Init(typeof(MobileMineApp).Assembly);
                Forms.Init(this, bundle);
			
		

        }



        private async Task GetLocation()
        {
            var locator = new Geolocator(this) { DesiredAccuracy = 50 };
           
            var location = await locator.GetPositionAsync(10000);
            MineAppServices.Current.CurrentPosition = location;
        }




    }
}

