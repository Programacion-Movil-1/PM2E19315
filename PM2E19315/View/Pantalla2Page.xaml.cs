using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E19315.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pantalla2Page : ContentPage
    {
        public Pantalla2Page()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listalocalizacion = await App.BaseDatos.ObtenerLista();
            lslocalizaciones.ItemsSource = listalocalizacion;

        }

        private async void lslocalizaciones_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //When selecciono uno
            
            //View.Pantalla3Page item = (View.Pantalla3Page)e.Item;

            var page = new View.Pantalla3Page();
            //page.BindingContext = item;
            await Navigation.PushAsync(page);
        }
    }
}