using ProdejnaVozidel.Database.dao_sqls;
using ProdejnaVozidel.Reservation;
using ProdejnaVozidel.Sale;
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
    public partial class DetailVehicle : Form
    {
        private Vozidlo v;
        private decimal aktualni_cena;
        public DetailVehicle(Vozidlo v)
        {
            InitializeComponent();
            this.v = v;
            lblNazev.Text = v.Znacka + " " + v.Model;
            lblRok.Text = "Rok: " + v.Rok.ToString();
            lblMotor.Text = v.Motor;
            lblPalivo.Text = v.Palivo;
            lblTachometr.Text = v.Tachometr.ToString();
            lblPrevodovka.Text = v.Prevodovka;
            lblKaroserie.Text = v.Karoserie;
            lblBarva.Text = v.Barva;
            lblCena.Text = v.Cena.ToString();

            Mechanik m = MechanikTable.Select_One(v.MeID);
            if(m != null) lblMechanik.Text = m.FullName;

            cbMechanik.DisplayMember = "FullName";
            cbMechanik.ValueMember = "MeID";
            cbMechanik.DataSource = MechanikTable.GetMechanics();

            aktualni_cena = v.Cena;

            if (VozidloTable.Count_cena(v.VID) == 0) btnHistorie.Enabled = false;

            switch (v.Stav)
            {
                case 0:
                    lblStav.Text = "Na prodej";
                    break;
                case 1:
                    lblStav.Text = "Rezervované";
                    btnRezervace.Enabled = false;
                    btnProdat.Enabled = false;
                    break;
                case 2:
                    lblStav.Text = "Prodané";
                    btnEdit.Enabled = false;
                    btnRezervace.Enabled = false;
                    btnProdat.Enabled = false;
                    break;
            }
        }

        private void PriceHistory(object sender, EventArgs e)
        {
            PriceHistory history = new PriceHistory(v);
            history.ShowDialog();
        }

        private void EditVehicle(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            lblMotor.Visible = false;
            lblPalivo.Visible = false;
            lblTachometr.Visible = false;
            lblPrevodovka.Visible = false;
            lblKaroserie.Visible = false;
            lblBarva.Visible = false;
            lblCena.Visible = false;
            lblMechanik.Visible = false;

            btnUlozit.Visible = true;
            txtMotor.Visible = true;
            txtMotor.Text = lblMotor.Text;
            txtPalivo.Visible = true;
            txtPalivo.Text = lblPalivo.Text;
            txtTachometr.Visible = true;
            txtTachometr.Text = lblTachometr.Text;
            txtPrevodovka.Visible = true;
            txtPrevodovka.Text = lblPrevodovka.Text;
            txtKaroserie.Visible = true;
            txtKaroserie.Text = lblKaroserie.Text;
            txtBarva.Visible = true;
            txtBarva.Text = lblBarva.Text;
            txtCena.Visible = true;
            txtCena.Text = lblCena.Text;
                
            cbMechanik.Visible = true;
            cbMechanik.SelectedValue = v.MeID;
        }

        private void Ulozit(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTachometr.Text))
            {
                MessageBox.Show("Vyplňte tachometr.");
                return;
            }
            else if (String.IsNullOrEmpty(txtCena.Text))
            {
                MessageBox.Show("Vyplňte cenu.");
                return;
            }
            else if (int.Parse(txtCena.Text) < 0)
            {
                MessageBox.Show("Neplatná cena.");
                return;
            }

            btnEdit.Visible = true;
            lblMotor.Visible = true;
            lblMotor.Text = txtMotor.Text;
            lblPalivo.Visible = true;
            lblPalivo.Text = txtPalivo.Text;
            lblTachometr.Visible = true;
            lblTachometr.Text = txtTachometr.Text;
            lblPrevodovka.Visible = true;
            lblPrevodovka.Text = txtPrevodovka.Text;
            lblKaroserie.Visible = true;
            lblKaroserie.Text = txtKaroserie.Text;
            lblBarva.Visible = true;
            lblBarva.Text = txtBarva.Text;
            lblCena.Visible = true;
            lblCena.Text = txtCena.Text;
            lblMechanik.Visible = true;
            

            btnUlozit.Visible = false;
            txtMotor.Visible = false;
            txtPalivo.Visible = false;
            txtTachometr.Visible = false;
            txtPrevodovka.Visible = false;
            txtKaroserie.Visible = false;
            txtBarva.Visible = false;
            txtCena.Visible = false;
            cbMechanik.Visible = false;

            v.Motor = txtMotor.Text;
            v.Palivo = txtPalivo.Text;
            v.Tachometr = int.Parse(txtTachometr.Text);
            v.Prevodovka = txtPrevodovka.Text;
            v.Karoserie = txtKaroserie.Text;
            v.Barva = txtBarva.Text;
            v.Cena = decimal.Parse(txtCena.Text);
            v.MeID = (int)cbMechanik.SelectedValue;

            Mechanik m = MechanikTable.GetMechanicById(v.MeID);
            lblMechanik.Text = m.FullName;

            if (v.Cena != aktualni_cena)
            {
                VozidloTable.NovaCena(v.VID, v.Cena);
                btnHistorie.Enabled = true;
            }

            VozidloTable.Update(v);
        }

        private void Prodat(object sender, EventArgs e)
        {
            NewSale newSale = new NewSale(v);
            newSale.ShowDialog();

            if (v.Stav == 2)
            {
                lblStav.Text = "Prodané";
                btnEdit.Enabled = false;
                btnRezervace.Enabled = false;
                btnProdat.Enabled = false;
            }
        }

        private void Rezervace(object sender, EventArgs e)
        {
            NewReservation newReservation = new NewReservation(v);
            newReservation.ShowDialog();

            if (v.Stav == 1)
            {
                lblStav.Text = "Rezervované";
                btnRezervace.Enabled = false;
                btnProdat.Enabled = false;
            }
        }
    }
}
