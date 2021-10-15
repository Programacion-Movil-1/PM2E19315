using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2E19315.Model;
using SQLite;

namespace PM2E19315.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        public DataBaseSQLite(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Localizacion>().Wait();
        }

        // OperacionesCRUD
        // READ

        public Task<List<Localizacion>> ObtenerLista()
        {
            return db.Table<Localizacion>().ToListAsync();
        }

        // READ uno
        public Task<Localizacion> ObtenerLocalizacion(int cod)
        {
            return db.Table<Localizacion>()
                .Where(i => i.codigo == cod)
                .FirstOrDefaultAsync();
        }

        // CREAR persona
        public Task<int> GrabarLocalizacion(Localizacion localizacion)
        {
            if (localizacion.codigo != 0)
            {
                return db.UpdateAsync(localizacion);
            }
            else
            {
                return db.InsertAsync(localizacion);
            }
        }

        // DELETE
        public Task<int> EliminarLocalizacion(Localizacion localizacion)
        {
            return db.DeleteAsync(localizacion);
        }
    }
}
