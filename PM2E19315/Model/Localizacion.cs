using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E19315.Model
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        [MaxLength(100)]
        public String DescripUbi { get; set; }
        [MaxLength(100)]
        public String DescriCort { get; set; }
    }
}
 