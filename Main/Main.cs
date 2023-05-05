using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProdejnaVozidel.Customer;
using ProdejnaVozidel.Database.dao_sqls;
using ProdejnaVozidel.Mechanic;
using ProdejnaVozidel.Reservation;
using ProdejnaVozidel.Sale;
using ProdejnaVozidel.Vehicle;

namespace ProdejnaVozidel
{
    public partial class Main : Form
    {
        private Prodej selectedSale;
        private Zakaznik selectedCustomer;
        private Rezervace selectedReservation;
        private Mechanik selectedMechanic;

        private List<Vozidlo> allVehicles = new List<Vozidlo>();
        private List<Vozidlo> unsoldVehicles = new List<Vozidlo>();
        private List<Vozidlo> reservedVehicles = new List<Vozidlo>();
        private List<Vozidlo> soldVehicles = new List<Vozidlo>();
        private List<Vozidlo> searchVehicles = new List<Vozidlo>();
        public Main()
        {
            InitializeComponent();
            LoadCustomers();
            LoadMechanics();
            LoadSales();
            LoadYears();
            LoadVehicles();
            LoadReservations();

            MechanikTable.Select();
        }

        private void LoadCustomers()
        {
            CustomersGrid.EnableHeadersVisualStyles = false;
            CustomersGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = CustomersGrid.ColumnHeadersDefaultCellStyle.BackColor;
            CustomersGrid.AutoGenerateColumns = false;

            CustomersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Jméno",
                DataPropertyName = nameof(Zakaznik.Jmeno)
            });

            CustomersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Příjmení",
                DataPropertyName = nameof(Zakaznik.Prijmeni)
            });

            CustomersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "E-mail",
                DataPropertyName = nameof(Zakaznik.Email)
            });

            CustomersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Telefon",
                DataPropertyName = nameof(Zakaznik.Telefon)
            });

            ZakaznikTable.Select();
            CustomersGrid.DataSource = ZakaznikTable.GetCustomers();
        }
        private void LoadMechanics()
        {
            MechanicsGrid.EnableHeadersVisualStyles = false;
            MechanicsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = MechanicsGrid.ColumnHeadersDefaultCellStyle.BackColor;
            MechanicsGrid.AutoGenerateColumns = false;

            MechanicsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Jméno",
                DataPropertyName = nameof(Mechanik.Jmeno)
            });

            MechanicsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Příjmení",
                DataPropertyName = nameof(Mechanik.Prijmeni)
            });

            MechanicsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "E-mail",
                DataPropertyName = nameof(Mechanik.Email)
            });

            MechanicsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Telefon",
                DataPropertyName = nameof(Mechanik.Telefon)
            });

            MechanikTable.Select();
            MechanicsGrid.DataSource = MechanikTable.GetMechanics();
        }
        private void LoadSales()
        {
            SalesGrid.EnableHeadersVisualStyles = false;
            SalesGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = SalesGrid.ColumnHeadersDefaultCellStyle.BackColor;
            SalesGrid.AutoGenerateColumns = false;

            SalesGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Datum",
                DataPropertyName = nameof(Prodej.Datum)
            });

            SalesGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Vozidlo",
                DataPropertyName = nameof(Prodej.Vozidlo)
            });

            SalesGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Zákazník",
                DataPropertyName = nameof(Prodej.Zakaznik)
            });

            SalesGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Manažer",
                DataPropertyName = nameof(Prodej.Manazer)
            });

            ProdejTable.Select();
            SalesGrid.DataSource = ProdejTable.GetSales();
        }

        private void LoadReservations()
        {
            ReservationsGrid.EnableHeadersVisualStyles = false;
            ReservationsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ReservationsGrid.ColumnHeadersDefaultCellStyle.BackColor;
            ReservationsGrid.AutoGenerateColumns = false;

            ReservationsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Začátek",
                DataPropertyName = nameof(Rezervace.Datum_zacatek)
            });

            ReservationsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Konec",
                DataPropertyName = nameof(Rezervace.Datum_konec)
            });

            ReservationsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Zákazník",
                DataPropertyName = nameof(Rezervace.Zakaznik)
            });

            ReservationsGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Vozidlo",
                DataPropertyName = nameof(Rezervace.Vozidlo)
            });

            RezervaceTable.Select();
            ReservationsGrid.DataSource = RezervaceTable.GetReservations();
        }

        private void LoadYears()
        {
            cbYear.DataSource = StatistikaTable.Years();
        }

        private void GetStatistics(object sender, EventArgs e)
        {
            foreach (var series in stats.Series)
            {
                series.Points.Clear();
            }
            Statistika s = StatistikaTable.Select(int.Parse(cbYear.Text));
            stats.Series["Year"].Points.AddXY("Leden", s.Leden);
            stats.Series["Year"].Points.AddXY("Únor", s.Unor);
            stats.Series["Year"].Points.AddXY("Březen", s.Brezen);
            stats.Series["Year"].Points.AddXY("Duben", s.Duben);
            stats.Series["Year"].Points.AddXY("Květen", s.Kveten);
            stats.Series["Year"].Points.AddXY("Červen", s.Cerven);
            stats.Series["Year"].Points.AddXY("Červenec", s.Cervenec);
            stats.Series["Year"].Points.AddXY("Srpen", s.Srpen);
            stats.Series["Year"].Points.AddXY("Září", s.Zari);
            stats.Series["Year"].Points.AddXY("Říjen", s.Rijen);
            stats.Series["Year"].Points.AddXY("Listopad", s.Listopad);
            stats.Series["Year"].Points.AddXY("Prosinec", s.Prosinec);
        }

        private void DetailSale(object sender, EventArgs e)
        {
            DetailSale detailSale = new DetailSale(selectedSale);
            detailSale.ShowDialog();
        }

        private void SelectSale(object sender, EventArgs e)
        {
            selectedSale = ProdejTable.GetSale(SalesGrid.CurrentCell.RowIndex);
        }

        private void SelectCustomer(object sender, EventArgs e)
        {
            selectedCustomer = ZakaznikTable.GetCustomer(CustomersGrid.CurrentCell.RowIndex);
            if (selectedCustomer.Stav != 0) btnDeleteCustomer.Enabled = false;
        }

        private void NewCustomer(object sender, EventArgs e)
        {
            CustomerDialog customerDialog = new CustomerDialog();
            customerDialog.ShowDialog();
        }

        private void DetailCustomer(object sender, EventArgs e)
        {
            CustomerDialog customerDialog = new CustomerDialog(selectedCustomer);
            customerDialog.ShowDialog();
            CustomersGrid.Refresh();
        }

        private void DeleteCustomer(object sender, EventArgs e)
        {
            ZakaznikTable.Delete(selectedCustomer);
        }

        private void LoadVehicles()
        {
            VozidloTable.Select();
            allVehicles = VozidloTable.GetAllVehicles();

            foreach (Vozidlo vozidlo in allVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }

        private void LoadAllVehicles(object sender, EventArgs e)
        {
            txtVyrobce.Clear();
            txtModel.Clear();
            txtRok.Clear();
            txtTachometr.Clear();

            VehiclesPanel.Controls.Clear();
            allVehicles = VozidloTable.GetAllVehicles();

            foreach (Vozidlo vozidlo in allVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }

        private void LoadUnsoldVehicles(object sender, EventArgs e)
        {
            txtVyrobce.Clear();
            txtModel.Clear();
            txtRok.Clear();
            txtTachometr.Clear();

            VehiclesPanel.Controls.Clear();
            unsoldVehicles = VozidloTable.GetUnsoldVehicles();

            foreach (Vozidlo vozidlo in unsoldVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }

        private void LoadReservedVehicles(object sender, EventArgs e)
        {
            txtVyrobce.Clear();
            txtModel.Clear();
            txtRok.Clear();
            txtTachometr.Clear();

            VehiclesPanel.Controls.Clear();
            reservedVehicles = VozidloTable.GetReservedVehicles();

            foreach (Vozidlo vozidlo in reservedVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }

        private void LoadSoldVehicles(object sender, EventArgs e)
        {
            txtVyrobce.Clear();
            txtModel.Clear();
            txtRok.Clear();
            txtTachometr.Clear();

            VehiclesPanel.Controls.Clear();
            soldVehicles = VozidloTable.GetSoldVehicles();

            foreach (Vozidlo vozidlo in soldVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }

        private void Search(object sender, EventArgs e)
        {
            rbAllVehicles.Checked = false;
            rbUnsoldVehicles.Checked = false;
            rbReservedVehicles.Checked = false;
            rbSoldVehicles.Checked = false;

            int rok;
            if (String.IsNullOrEmpty(txtRok.Text))
            {
                rok = 0;
            }
            else
            {
                rok = int.Parse(txtRok.Text);
            }

            int tachometr;
            if (String.IsNullOrEmpty(txtTachometr.Text))
            {
                tachometr = 0;
            }
            else
            {
                tachometr = int.Parse(txtTachometr.Text);
            }

            searchVehicles = VozidloTable.Select_Search(txtVyrobce.Text, txtModel.Text, rok, tachometr);

            VehiclesPanel.Controls.Clear();

            foreach (Vozidlo vozidlo in searchVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }
        private void Rok(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void Tachometr(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void DetailReservation(object sender, EventArgs e)
        {
            DetailReservation detailReservation = new DetailReservation(selectedReservation);
            detailReservation.ShowDialog();
        }

        private void SelectReservation(object sender, EventArgs e)
        {
            selectedReservation = RezervaceTable.GetReservation(ReservationsGrid.CurrentCell.RowIndex);
        }

        private void NewVehicle(object sender, EventArgs e)
        {
            NewVehicle newVehicle = new NewVehicle();
            newVehicle.ShowDialog();

            rbAllVehicles.Checked = true;
            VehiclesPanel.Controls.Clear();
            allVehicles = VozidloTable.GetAllVehicles();

            foreach (Vozidlo vozidlo in allVehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vozidlo);
                VehiclesPanel.Controls.Add(vehicleItem);
            }
        }

        private void NewMechanic(object sender, EventArgs e)
        {
            MechanicDialog mechanicDialog = new MechanicDialog();
            mechanicDialog.ShowDialog();
        }

        private void DetailMechanic(object sender, EventArgs e)
        {
            MechanicDialog mechanicDialog = new MechanicDialog(selectedMechanic);
            mechanicDialog.ShowDialog();
            MechanicsGrid.Refresh();
        }
        private void DeleteMechanic(object sender, EventArgs e)
        {
            MechanikTable.Delete(selectedMechanic);
        }

        private void SelectMechanic(object sender, EventArgs e)
        {
            selectedMechanic = MechanikTable.GetMechanic(MechanicsGrid.CurrentCell.RowIndex);
        }
    }
}
