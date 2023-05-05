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

namespace ProdejnaVozidel.Vehicle
{
    public partial class VehicleItem : UserControl
    {
        private Vozidlo v;
        private static string hexUnsold = "#d8ffd3";
        private static Color colorUnsold = System.Drawing.ColorTranslator.FromHtml(hexUnsold);
        private static string hexReserved = "#feffd3";
        private static Color colorReserved = System.Drawing.ColorTranslator.FromHtml(hexReserved);
        private static string hexSold = "#ffe6d3";
        private static Color colorSold = System.Drawing.ColorTranslator.FromHtml(hexSold);
        public VehicleItem(Vozidlo v)
        {
            InitializeComponent();
            this.v = v;
            FullName = v.Znacka + " " + v.Model + " " + v.Rok + ", " + v.Motor + ", " + v.Tachometr + " km";
            Stav = v.Stav;


            if (stav != 0)
            {
                if (stav == 1)
                {
                    Rezervace r = RezervaceTable.Select_VID(v.VID);
                    Zakaznik z = ZakaznikTable.GetCustomerById(r.ZID);
                    Zakaznik = r.Datum_zacatek.ToString("dd. MM. yyyy") + " - " + r.Datum_konec.ToString("dd. MM. yyyy") + ", " + z.Jmeno + " " + z.Prijmeni;
                }
                else
                {
                    Prodej p = ProdejTable.Select_VID(v.VID);
                    Zakaznik z = ZakaznikTable.GetCustomerById(p.ZID);
                    Zakaznik = p.Datum.ToString("dd. MM. yyyy") + ", " + z.Jmeno + " " + z.Prijmeni;
                }
            }
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; lblFullName.Text = value; }
        }

        private int stav;

        public int Stav
        {
            get { return stav; }
            set { 
                stav = value;
                switch (value)
                {
                    case 0:
                        lblStav.Text = "Na prodej";
                        lblStavInfo.Visible = false;
                        lblZakaznik.Visible = false;
                        BackColor = colorUnsold;
                        break;
                    case 1:
                        lblStav.Text = "Rezervované";
                        lblStavInfo.Text = "Rezervace:";
                        BackColor = colorReserved;
                        btnDeleteVehicle.Visible = false;
                        break;
                    case 2:
                        lblStav.Text = "Prodané";
                        lblStavInfo.Text = "Prodej:";
                        BackColor = colorSold;
                        btnDeleteVehicle.Visible = false;
                        break;
                }
            }
        }

        private string zakaznik;
        public string Zakaznik
        {
            get { return zakaznik; }
            set { zakaznik = value; lblZakaznik.Text = value; }
        }

        private void DetailVehicle(object sender, EventArgs e)
        {
            DetailVehicle detailVehicle = new DetailVehicle(v);
            detailVehicle.ShowDialog();

            FullName = v.Znacka + " " + v.Model + " " + v.Rok + ", " + v.Motor + ", " + v.Tachometr + " km";
        }

        private void DeleteVehicle(object sender, EventArgs e)
        {
            VozidloTable.Delete(v);

            Control c = Parent;
            c.Controls.Remove(this);
        }
    }
}
