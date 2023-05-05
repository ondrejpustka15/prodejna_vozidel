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
    public partial class DetailReservation : Form
    {
        public DetailReservation(Rezervace r)
        {
            InitializeComponent();

            Zakaznik z = ZakaznikTable.GetCustomerById(r.ZID);
            Vozidlo v = VozidloTable.GetVehicleReservedById(r.VID);

            lblDatum.Text = "Datum: " + r.Datum_zacatek.ToString("dd. MM. yyyy") + " - " + r.Datum_konec.ToString("dd. MM. yyyy");

            lblJmeno.Text = z.Jmeno;
            lblPrijmeni.Text = z.Prijmeni;
            lblEmail.Text = z.Email;
            lblTelefon.Text = z.Telefon;
            lblUlice.Text = z.Ulice;
            lblMesto.Text = z.Mesto;
            lblPsc.Text = z.Psc;

            lblZnacka.Text = v.Znacka;
            lblModel.Text = v.Model;
            lblRok.Text = v.Rok.ToString();
            lblMotor.Text = v.Motor;
            lblPalivo.Text = v.Palivo;
            lblTachometr.Text = v.Tachometr.ToString();
            lblPrevodovka.Text = v.Prevodovka;
            lblKaroserie.Text = v.Karoserie;
            lblBarva.Text = v.Barva;
            lblCena.Text = v.Cena.ToString();
        }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}
