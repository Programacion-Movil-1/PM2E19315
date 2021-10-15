using System;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM2E19315.ViewModel
{
    public class Pantalla1ViewModel : BaseViewModel
    {
        string notAvailable = "no disponible";
        string currentLocation1;
        string currentLocation2;
        int accuracy = (int)GeolocationAccuracy.Default;
        CancellationTokenSource cts;

        public Pantalla1ViewModel()
        {
            GetCurrentLocationCommand = new Command(OnGetCurrentLocation);
        }
        public ICommand GetCurrentLocationCommand { get; }

        public string CurrentLocation1
        {
            get => currentLocation1;
            set => SetProperty(ref currentLocation1, value);
        }

        public string CurrentLocation2
        {
            get => currentLocation2;
            set => SetProperty(ref currentLocation2, value);
        }

        public string[] Accuracies
    => Enum.GetNames(typeof(GeolocationAccuracy));

        public int Accuracy
        {
            get => accuracy;
            set => SetProperty(ref accuracy, value);
        }

        async void OnGetCurrentLocation()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                var request = new GeolocationRequest((GeolocationAccuracy)Accuracy);
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                CurrentLocation1 = FormatLocation1(location);
                CurrentLocation2 = FormatLocation2(location);
            }
            catch (Exception ex)
            {
                CurrentLocation1 = FormatLocation1(null, ex);
                CurrentLocation2 = FormatLocation2(null, ex);
            }
            finally
            {
                cts.Dispose();
                cts = null;
            }
            IsBusy = false;
        }

        string FormatLocation1(Location location, Exception ex = null)
        {

            if (location == null)
            {
                return $"No se puede detectar la ubicación. Excepción: {ex?.Message ?? string.Empty}";
            }

            return
                $"{location.Latitude}";
        }

        string FormatLocation2(Location location, Exception ex = null)
        {

            if (location == null)
            {
                return $"No se puede detectar la ubicación. Excepción: {ex?.Message ?? string.Empty}";
            }

            return
                $"{location.Longitude}";
        }

        public override void OnDisappearing()
        {
            if (IsBusy)
            {
                if (cts != null && !cts.IsCancellationRequested)
                    cts.Cancel();
            }
            base.OnDisappearing();
        }
    }
}
