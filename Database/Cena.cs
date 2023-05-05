using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel
{
    class Cena
    {
        public int CID { get; set; }
        public decimal Cena_predchozi { get; set;}
        public decimal Cena_nova { get; set;}
        public DateTime Datum_zmeny { get; set; }
        public int VID { get; set; }
    }
}
