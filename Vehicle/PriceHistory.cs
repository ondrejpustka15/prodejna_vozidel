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
    public partial class PriceHistory : Form
    {
        private List<Cena> historie = new List<Cena>();
        public PriceHistory(Vozidlo v)
        {
            InitializeComponent();
            historie = VozidloTable.Select_cena(v.VID);

            PriceGrid.EnableHeadersVisualStyles = false;
            PriceGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = PriceGrid.ColumnHeadersDefaultCellStyle.BackColor;
            PriceGrid.AutoGenerateColumns = false;

            PriceGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Datum změny",
                DataPropertyName = nameof(Cena.Datum_zmeny)
            });

            PriceGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Cena předchozí",
                DataPropertyName = nameof(Cena.Cena_predchozi)
            });

            PriceGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Cena nová",
                DataPropertyName = nameof(Cena.Cena_nova)
            });

            PriceGrid.DataSource = historie;
        }
    }
}
