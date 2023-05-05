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

namespace ProdejnaVozidel.Mechanic
{
    public partial class MechanicDialog : Form
    {
        private Mechanik m;
        public MechanicDialog()
        {
            InitializeComponent();
            m = null;
        }
        public MechanicDialog(Mechanik m)
        {
            InitializeComponent();
            this.m = m;

            txtJmeno.Text = m.Jmeno;
            txtPrijmeni.Text = m.Prijmeni;
            txtEmail.Text = m.Email;
            txtTelefon.Text = m.Telefon;
            txtUlice.Text = m.Ulice;
            txtMesto.Text = m.Mesto;
            txtPsc.Text = m.Psc;
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

            if (m == null)
            {
                m = new Mechanik();
                m.Jmeno = txtJmeno.Text;
                m.Prijmeni = txtPrijmeni.Text;
                m.Email = txtEmail.Text;
                m.Telefon = txtTelefon.Text;
                m.Ulice = txtUlice.Text;
                m.Mesto = txtMesto.Text;
                m.Psc = txtPsc.Text;

                MechanikTable.Insert(m);
            }
            else
            {
                m.Jmeno = txtJmeno.Text;
                m.Prijmeni = txtPrijmeni.Text;
                m.Email = txtEmail.Text;
                m.Telefon = txtTelefon.Text;
                m.Ulice = txtUlice.Text;
                m.Mesto = txtMesto.Text;
                m.Psc = txtPsc.Text;

                MechanikTable.Update(m);
            }
        }
    }
}
