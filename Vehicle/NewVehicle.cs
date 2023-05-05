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
    public partial class NewVehicle : Form
    {
        public NewVehicle()
        {
            InitializeComponent();
        }

        private void Ulozit(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtVyrobce.Text))
            {
                MessageBox.Show("Vyplňte výrobce.");
                return;
            } 
            else if (String.IsNullOrEmpty(txtModel.Text)) 
            {
                MessageBox.Show("Vyplňte model.");
                return;
            }
            else if (String.IsNullOrEmpty(txtRok.Text)) 
            {
                MessageBox.Show("Vyplňte rok.");
                return;
            }

            else if (String.IsNullOrEmpty(txtTachometr.Text))
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


            Vozidlo v = new Vozidlo();
            v.Znacka = txtVyrobce.Text;
            v.Model = txtModel.Text;

            v.Rok = int.Parse(txtRok.Text);
            v.Tachometr = int.Parse(txtTachometr.Text);
            v.Motor = txtMotor.Text;
            v.Prevodovka = cbPrevodovka.Text;
            v.Karoserie = txtKaroserie.Text;
            v.Palivo = txtPalivo.Text;
            v.Barva = txtBarva.Text;
            v.Cena = decimal.Parse(txtCena.Text);

            string s = VozidloTable.Insert(v);

            MessageBox.Show(s);
        }
    }
}
