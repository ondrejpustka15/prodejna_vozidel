using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel
{
    public class Rezervace
    {
        public int RID { get; set; }
        public DateTime Datum_zacatek { get; set; }
        public DateTime Datum_konec { get; set; }
        public int ZID { get; set; }
        public int VID { get; set; }
        public string Zakaznik { get; set; }
        public string Vozidlo { get; set; }
    }
}
