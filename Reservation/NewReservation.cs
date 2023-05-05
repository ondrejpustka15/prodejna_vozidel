using ProdejnaVozidel.Database.dao_sqls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdejnaVozidel.Reservation
{
    public partial class NewReservation : Form
    {
        private Vozidlo v;
        public NewReservation(Vozidlo v)
        {
            InitializeComponent();
            this.v = v;

            lblVozidlo.Text = v.Znacka + " " + v.Model + ", " + v.Rok.ToString();
            cbZakaznik.ValueMember = "ZID";
            cbZakaznik.DisplayMember = "FullName";
            cbZakaznik.DataSource = ZakaznikTable.GetCustomersReservation();
        }

        private void Rezervovat(object sender, EventArgs e)
        {
            Zakaznik z = ZakaznikTable.GetCustomerById((int)cbZakaznik.SelectedValue);
            Rezervace r = new Rezervace();

            r.Datum_zacatek = dateStart.Value;
            r.Datum_konec = dateEnd.Value;
            r.ZID = z.ZID;
            r.VID = v.VID;

            r.Zakaznik = z.Jmeno + " " + z.Prijmeni;
            r.Vozidlo = v.Znacka + " " + v.Model + ", " + v.Rok.ToString();

            RezervaceTable.Insert(r);

            z.Stav = 1;
            ZakaznikTable.Update(z);
            ZakaznikTable.RemoveCustomerReservation(z);

            v.Stav = 1;
            VozidloTable.Update(v);
            VozidloTable.RemoveVehicleFromUnsold(v);
            VozidloTable.AddVehicleToReserved(v);
        }
    }
}
