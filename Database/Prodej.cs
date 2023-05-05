using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel
{
    public class Prodej
    {
        public int PID { get; set; }
        public DateTime Datum { get; set; }
        public int MaID { get; set; }
        public int ZID { get; set; }
        public int VID { get; set; }
        public string Manazer { get; set; }
        public string Zakaznik { get; set; }
        public string Vozidlo { get; set; }
    }
}
