using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel
{
    public class Zakaznik
    {
		public int ZID { get; set; }
		public string Jmeno { get; set; }
		public string Prijmeni { get; set; }
		public string Email { get; set; }
		public string Telefon { get; set; }
		public string Ulice { get; set; }
		public string Mesto { get; set; }
		public string Psc { get; set; }
		public string Heslo { get; set; }
		public int Stav { get; set; }
		public string FullName { get; set; }
	}
}
