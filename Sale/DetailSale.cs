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

namespace ProdejnaVozidel.Sale
{
    public partial class DetailSale : Form
    {
        public DetailSale(Prodej p)
        {
            InitializeComponent();
            Zakaznik z = ZakaznikTable.Select_One(p.ZID);
            Vozidlo v = VozidloTable.Select_One(p.VID);

            lblDatum.Text = "Datum: " + p.Datum.ToString("dd. MM. yyyy");

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
