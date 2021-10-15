using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E19315.Controller;
using System.IO;
using PM2E19315.View;

namespace PM2E19315
{
    public partial class App : Application
    {
        static DataBaseSQLite basedatos;
        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM9315.db3"));
                }

                return basedatos;
            }

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pantalla1Page());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
