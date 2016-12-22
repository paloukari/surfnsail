using Geolocator.Plugin;
using Geolocator.Plugin.Abstractions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using surfnsail.Models;

namespace surfnsail.Views.CommonPages
{
    public class TrackingPage : ContentPage
    {

        Map _map;
        IGeolocator _geoLocator;
        bool _Recording = false;
        int _trackingID = 0;

        protected override void OnAppearing()
        {
            _map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(_map.X, _map.Y), Distance.FromMiles(1)));
            base.OnAppearing();
        }

        public void StartRecording()
        {
            if (!_Recording)
            {
                _Recording = true;

                int newID = 0;
                if (App.Database.Routes.Count() > 0)
                    newID = App.Database.Routes.Max(e => e.ID);
                _trackingID = ++newID;
                App.Database.AddRouteItem(new Models.RouteItem { ID = newID });
            }
        }

        public void StopRecording()
        {

        }

        public TrackingPage()
        {
            Title = "Tracking";

            _map = new Map
            {
                MapType = MapType.Satellite,
                IsShowingUser = true,

                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // put the page together
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(_map);
            Content = stack;

            // for debugging output only
#if DEBUG
            _map.PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && _map.VisibleRegion != null)
                    CalculateBoundingCoordinates(_map.VisibleRegion);
            };
#endif

            _geoLocator = CrossGeolocator.Current;
            _geoLocator.DesiredAccuracy = 10;
            _geoLocator.PositionChanged += _geoLocator_PositionChanged;
            _geoLocator.PositionError += _geoLocator_PositionError;
        }

        private void _geoLocator_PositionError(object sender, PositionErrorEventArgs e)
        {

        }

        private void _geoLocator_PositionChanged(object sender, PositionEventArgs e)
        {
            if (_Recording)
            {
                App.Database.AddPositionItem(new PositionItem { Position = e.Position, RouteID = _trackingID });
            }
        }


        /// <summary>
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
        /// Useful if you need to send the bounds to a web service or otherwise calculate what
        /// pins might need to be drawn inside the currently visible viewport.
        /// </summary>
        static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }
    }
}