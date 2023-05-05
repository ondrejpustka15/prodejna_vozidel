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

namespace ProdejnaVozidel.Customer
{
    public partial class CustomerDialog : Form
    {
        private Zakaznik z;
        public CustomerDialog()
        {
            InitializeComponent();
            z = null;
        }

        public CustomerDialog(Zakaznik z)
        {
            InitializeComponent();
            this.z = z;

            txtJmeno.Text = z.Jmeno;
            txtPrijmeni.Text = z.Prijmeni;
            txtEmail.Text = z.Email;
            txtTelefon.Text = z.Telefon;
            txtUlice.Text = z.Ulice;
            txtMesto.Text = z.Mesto;
            txtPsc.Text = z.Psc;
        }

        private void Ulozit(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtJmeno.Text))
            {
                MessageBox.Show("Vyplňte jméno.");
                return;
            }
            else if (String.IsNullOrEmpty(txtPrijmeni.Text))
            {
                MessageBox.Show("Vyplňte příjmení.");
                return;
            }
            else if (String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vyplňte email.");
                return;
            }

            else if (String.IsNullOrEmpty(txtTelefon.Text))
            {
                MessageBox.Show("Vyplňte telefon.");
                return;
            }

            if (z == null)
            {
                z = new Zakaznik();
                z.Jmeno = txtJmeno.Text;
                z.Prijmeni = txtPrijmeni.Text;
                z.Email = txtEmail.Text;
                z.Telefon = txtTelefon.Text;
                z.Ulice = txtUlice.Text;
                z.Mesto = txtMesto.Text;
                z.Psc = txtPsc.Text;
                z.Heslo = null;

                ZakaznikTable.Insert(z);
            }
            else
            {
                z.Jmeno = txtJmeno.Text;
                z.Prijmeni = txtPrijmeni.Text;
                z.Email = txtEmail.Text;
                z.Telefon = txtTelefon.Text;
                z.Ulice = txtUlice.Text;
                z.Mesto = txtMesto.Text;
                z.Psc = txtPsc.Text;

                ZakaznikTable.Update(z);
            }
        }
    }
}
