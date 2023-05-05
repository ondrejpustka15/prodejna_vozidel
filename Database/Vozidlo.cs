using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel
{
    public class Vozidlo
    {
		public int VID { get; set; }
		public string Znacka { get; set; }
		public string Model { get; set; }
		public int? Rok { get; set; }
		public int? Tachometr { get; set; }
		public string Motor { get; set; }
		public string Prevodovka { get; set; }
		public string Karoserie { get; set; }
		public string Palivo { get; set; }
		public string Barva { get; set; }
		public decimal Cena { get; set;}
		public int Stav { get; set; }
		public int MeID { get; set; }
	}
}
