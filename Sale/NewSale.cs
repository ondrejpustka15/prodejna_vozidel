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
    public partial class NewSale : Form
    {
        private Vozidlo v;
        public NewSale(Vozidlo v)
        {
            InitializeComponent();
            this.v = v;

            lblVozidlo.Text = v.Znacka + " " + v.Model + ", " + v.Rok.ToString();
            cbZakaznik.ValueMember = "ZID";
            cbZakaznik.DisplayMember = "FullName";
            cbZakaznik.DataSource = ZakaznikTable.GetCustomers();
        }

        private void Prodat(object sender, EventArgs e)
        {
            Zakaznik z = ZakaznikTable.GetCustomerById((int)cbZakaznik.SelectedValue);
            Prodej p = new Prodej();

            p.Datum = dateSale.Value;
            p.ZID = z.ZID;
            p.VID = v.VID;
            p.MaID = 3;
            //p.Manazer = ;
            p.Zakaznik = z.Jmeno + " " + z.Prijmeni;
            p.Vozidlo = v.Znacka + " " + v.Model + ", " + v.Rok.ToString();

            ProdejTable.Insert(p);

            z.Stav = 2;
            ZakaznikTable.Update(z);

            v.Stav = 2;
            VozidloTable.Update(v);
            VozidloTable.RemoveVehicleFromUnsold(v);
            VozidloTable.AddVehicleToSold(v);
        }
    }
}
