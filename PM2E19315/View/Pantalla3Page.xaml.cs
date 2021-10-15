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

            var localizacion = CrossGeolocator.Current;
            if(localizacion != null)
            {
                localizacion.PositionChanged += Localizacion_PositionChanged;

                if (!localizacion.IsListening)
                {
                    Debug.WriteLine("StartListeningAsync");
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100);

                }

                var posicion = await localizacion.GetPositionAsync();
                var mapaalcentro = new Position(posicion.Latitude, posicion.Longitude);

                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(mapaalcentro, Distance.FromMiles(1)));

            }
            else
            {
                await localizacion.GetLastKnownLocationAsync();
                var posicion = await localizacion.GetPositionAsync();
                var mapaalcentro = new Position(posicion.Latitude, posicion.Longitude);

                mapa.MoveToRegion(new MapSpan(mapaalcentro, 2, 2));
            }
        }
        private void Localizacion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var mapaalcentro = new Position(e.Position.Latitude, e.Position.Longitude);
            mapa.MoveToRegion(new MapSpan(mapaalcentro, 2, 2));
        }
    }

    
}