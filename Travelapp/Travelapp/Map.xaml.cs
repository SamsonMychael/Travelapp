using System.Collections.Generic;


using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travelapp.Model;

namespace Travelapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        bool haslocpermission = false;
        public Map()
        {
            InitializeComponent();
            Getpermission();
        }

        private async void Getpermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                {
                    await DisplayAlert("Failed", "We need your Location access", "Okay");
                }
                var request = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
                if (request == PermissionStatus.Granted)
                {
                    status = request;
                }
            }
            if (status == PermissionStatus.Granted)
            {
                haslocpermission = true;
                locationmap.IsShowingUser = true;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (haslocpermission)
            {
                var Locator = CrossGeolocator.Current;
                Locator.PositionChanged += Locator_PositionChanged;
                await Locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
            GetLocation();
            /*using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocation))
            {
                conn.CreateTable<post>();
                var show = conn.Table<post>().ToList();
               
            }*/
          
            
        }

       /* private void DisplayInMap(List<post> show)
        {
            foreach (var post in show)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address,
                    };
                    Locationxml.Pins.Add(pin);
                }
                catch (NullReferenceException nre)
                { }
                catch (Exception ex)
                { }
            }
        }*/
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            var Locator = CrossGeolocator.Current;
            Locator.PositionChanged -= Locator_PositionChanged;
            await Locator.StopListeningAsync();
        }

        private async void GetLocation()
        {
            var location = CrossGeolocator.Current;
            var position = await location.GetPositionAsync();
            Movemap(position);
        }
        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            Movemap(e.Position);
        }

        public void Movemap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationmap.MoveToRegion(span);
        }
    }
}