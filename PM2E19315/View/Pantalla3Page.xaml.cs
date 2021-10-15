using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Plugin.Geolocator;
using System.Diagnostics;

namespace PM2E19315.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pantalla3Page : ContentPage
    {
        public Pantalla3Page()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var pin = new Pin()
            {
                Position = new Position(15.5294048, -88.0003413),
                Label = "Cerca de UTH SPS"
            };

            mapa.Pins.Add(pin);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(1)));
        }
    }
}