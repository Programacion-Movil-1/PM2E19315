using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;

using Xamarin.Forms.Xaml;

namespace PM2E19315.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pantalla1Page : BasePage
    {
        public Pantalla1Page()
        {
            InitializeComponent();
        }

        private async Task<bool> ValidationForm()
        {
            if (String.IsNullOrWhiteSpace(Lat.Text) || String.IsNullOrWhiteSpace(Long.Text))
            {
                await this.DisplayAlert("Advertencia", "GPS no está activo", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(LongDescrpt.Text))
            {
                await this.DisplayAlert("Advertencia", "Debe describir la ubicación", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(ShortDescrpt.Text))
            {
                await this.DisplayAlert("Advertencia", "Debe escribir una descripción corta", "OK");
                return false;
            }

            if (ShortDescrpt.Text.Length >= 15)
            {
                await this.DisplayAlert("Advertencia", "Maximo de caracteres permitidos", "OK");
                return false;
            }

            return true;
        }


        private async Task<bool> ValidationGPS()
        {
            if (String.IsNullOrWhiteSpace(Lat.Text) || String.IsNullOrWhiteSpace(Long.Text))
            {
                await this.DisplayAlert("Advertencia", "GPS no está activo\nPresione obtener ubicación", "OK");
                return false;
            }

            return true;
        }

        async void Continue_Tapped(object sender, EventArgs e)
        {
            try
            {
                var localizacion = new Model.Localizacion
                {
                    Lat = Convert.ToDouble(Lat.Text),
                    Long = Convert.ToDouble(Long.Text),
                    DescripUbi = LongDescrpt.Text,
                    DescriCort = ShortDescrpt.Text
                };

                var resultado = await App.BaseDatos.GrabarLocalizacion(localizacion);

                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Ingresado Exitosamente", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo grabar persona", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            /* if (await ValidationForm())
            {
                await DisplayAlert("Exito", "Guardado Correctamente", "OK");
            } */
            
        }

        async void GPS_Activated(object sender, EventArgs e)
        {
            await ValidationGPS();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Ver Guardadas
            
            
            await Navigation.PushAsync(new View.Pantalla2Page());
            
        }
    }
}