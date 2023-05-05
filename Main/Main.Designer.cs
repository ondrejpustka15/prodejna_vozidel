
namespace ProdejnaVozidel
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.gbFiltr = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbAllVehicles = new System.Windows.Forms.RadioButton();
            this.rbUnsoldVehicles = new System.Windows.Forms.RadioButton();
            this.rbReservedVehicles = new System.Windows.Forms.RadioButton();
            this.rbSoldVehicles = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVyrobce = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtRok = new System.Windows.Forms.TextBox();
            this.txtTachometr = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.VehiclesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnDetailCustomer = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.CustomersGrid = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnDeleteMechanic = new System.Windows.Forms.Button();
            this.btnDetailMechanic = new System.Windows.Forms.Button();
            this.MechanicsGrid = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SalesGrid = new System.Windows.Forms.DataGridView();
            this.btnDetailSale = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ReservationsGrid = new System.Windows.Forms.DataGridView();
            this.btnDetailReservation = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.stats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnNewMechanic = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbFiltr.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGrid)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsGrid)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesGrid)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationsGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stats)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1027, 636);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.gbFiltr);
            this.tabPage1.Controls.Add(this.VehiclesPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1019, 610);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vozidla";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nové vozidlo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.NewVehicle);
            // 
            // gbFiltr
            // 
            this.gbFiltr.Controls.Add(this.flowLayoutPanel1);
            this.gbFiltr.Location = new System.Drawing.Point(6, 6);
            this.gbFiltr.Name = "gbFiltr";
            this.gbFiltr.Size = new System.Drawing.Size(1007, 118);
            this.gbFiltr.TabIndex = 1;
            this.gbFiltr.TabStop = false;
            this.gbFiltr.Text = "Filtr";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rbAllVehicles);
            this.flowLayoutPanel1.Controls.Add(this.rbUnsoldVehicles);
            this.flowLayoutPanel1.Controls.Add(this.rbReservedVehicles);
            this.flowLayoutPanel1.Controls.Add(this.rbSoldVehicles);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.txtVyrobce);
            this.flowLayoutPanel1.Controls.Add(this.txtModel);
            this.flowLayoutPanel1.Controls.Add(this.txtRok);
            this.flowLayoutPanel1.Controls.Add(this.txtTachometr);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(995, 93);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // rbAllVehicles
            // 
            this.rbAllVehicles.AutoSize = true;
            this.rbAllVehicles.Checked = true;
            this.rbAllVehicles.Location = new System.Drawing.Point(65, 10);
            this.rbAllVehicles.Margin = new System.Windows.Forms.Padding(65, 10, 65, 10);
            this.rbAllVehicles.Name = "rbAllVehicles";
            this.rbAllVehicles.Size = new System.Drawing.Size(103, 17);
            this.rbAllVehicles.TabIndex = 0;
            this.rbAllVehicles.TabStop = true;
            this.rbAllVehicles.Text = "Všechna vozidla";
            this.rbAllVehicles.UseVisualStyleBackColor = true;
            this.rbAllVehicles.Click += new System.EventHandler(this.LoadAllVehicles);
            // 
            // rbUnsoldVehicles
            // 
            this.rbUnsoldVehicles.AutoSize = true;
            this.rbUnsoldVehicles.Location = new System.Drawing.Point(298, 10);
            this.rbUnsoldVehicles.Margin = new System.Windows.Forms.Padding(65, 10, 65, 10);
            this.rbUnsoldVehicles.Name = "rbUnsoldVehicles";
            this.rbUnsoldVehicles.Size = new System.Drawing.Size(114, 17);
            this.rbUnsoldVehicles.TabIndex = 1;
            this.rbUnsoldVehicles.Text = "Neprodaná vozidla";
            this.rbUnsoldVehicles.UseVisualStyleBackColor = true;
            this.rbUnsoldVehicles.Click += new System.EventHandler(this.LoadUnsoldVehicles);
            // 
            // rbReservedVehicles
            // 
            this.rbReservedVehicles.AutoSize = true;
            this.rbReservedVehicles.Location = new System.Drawing.Point(542, 10);
            this.rbReservedVehicles.Margin = new System.Windows.Forms.Padding(65, 10, 65, 10);
            this.rbReservedVehicles.Name = "rbReservedVehicles";
            this.rbReservedVehicles.Size = new System.Drawing.Size(125, 17);
            this.rbReservedVehicles.TabIndex = 2;
            this.rbReservedVehicles.Text = "Rezervovaná vozidla";
            this.rbReservedVehicles.UseVisualStyleBackColor = true;
            this.rbReservedVehicles.Click += new System.EventHandler(this.LoadReservedVehicles);
            // 
            // rbSoldVehicles
            // 
            this.rbSoldVehicles.AutoSize = true;
            this.rbSoldVehicles.Location = new System.Drawing.Point(797, 10);
            this.rbSoldVehicles.Margin = new System.Windows.Forms.Padding(65, 10, 65, 10);
            this.rbSoldVehicles.Name = "rbSoldVehicles";
            this.rbSoldVehicles.Size = new System.Drawing.Size(101, 17);
            this.rbSoldVehicles.TabIndex = 3;
            this.rbSoldVehicles.Text = "Prodaná vozidla";
            this.rbSoldVehicles.UseVisualStyleBackColor = true;
            this.rbSoldVehicles.Click += new System.EventHandler(this.LoadSoldVehicles);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 15, 100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Výrobce";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(55, 15, 100, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(63, 15, 100, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rok";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(650, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(73, 15, 140, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tachometr";
            // 
            // txtVyrobce
            // 
            this.txtVyrobce.Location = new System.Drawing.Point(50, 70);
            this.txtVyrobce.Margin = new System.Windows.Forms.Padding(50, 5, 0, 18);
            this.txtVyrobce.Name = "txtVyrobce";
            this.txtVyrobce.Size = new System.Drawing.Size(190, 20);
            this.txtVyrobce.TabIndex = 4;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(250, 70);
            this.txtModel.Margin = new System.Windows.Forms.Padding(10, 5, 0, 18);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(190, 20);
            this.txtModel.TabIndex = 9;
            // 
            // txtRok
            // 
            this.txtRok.Location = new System.Drawing.Point(450, 70);
            this.txtRok.Margin = new System.Windows.Forms.Padding(10, 5, 0, 18);
            this.txtRok.Name = "txtRok";
            this.txtRok.Size = new System.Drawing.Size(190, 20);
            this.txtRok.TabIndex = 10;
            this.txtRok.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Rok);
            // 
            // txtTachometr
            // 
            this.txtTachometr.Location = new System.Drawing.Point(650, 70);
            this.txtTachometr.Margin = new System.Windows.Forms.Padding(10, 5, 0, 18);
            this.txtTachometr.Name = "txtTachometr";
            this.txtTachometr.Size = new System.Drawing.Size(172, 20);
            this.txtTachometr.TabIndex = 11;
            this.txtTachometr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tachometr);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(832, 70);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(10, 5, 0, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 20);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Hledat";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search);
            // 
            // VehiclesPanel
            // 
            this.VehiclesPanel.AutoScroll = true;
            this.VehiclesPanel.Location = new System.Drawing.Point(6, 159);
            this.VehiclesPanel.Name = "VehiclesPanel";
            this.VehiclesPanel.Size = new System.Drawing.Size(1007, 445);
            this.VehiclesPanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDeleteCustomer);
            this.tabPage2.Controls.Add(this.btnDetailCustomer);
            this.tabPage2.Controls.Add(this.btnNewCustomer);
            this.tabPage2.Controls.Add(this.CustomersGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1019, 610);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zákazníci";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(218, 3);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteCustomer.TabIndex = 3;
            this.btnDeleteCustomer.Text = "Smazat";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.DeleteCustomer);
            // 
            // btnDetailCustomer
            // 
            this.btnDetailCustomer.Location = new System.Drawing.Point(112, 3);
            this.btnDetailCustomer.Name = "btnDetailCustomer";
            this.btnDetailCustomer.Size = new System.Drawing.Size(100, 25);
            this.btnDetailCustomer.TabIndex = 2;
            this.btnDetailCustomer.Text = "Detail";
            this.btnDetailCustomer.UseVisualStyleBackColor = true;
            this.btnDetailCustomer.Click += new System.EventHandler(this.DetailCustomer);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(6, 3);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(100, 25);
            this.btnNewCustomer.TabIndex = 1;
            this.btnNewCustomer.Text = "Nový";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.NewCustomer);
            // 
            // CustomersGrid
            // 
            this.CustomersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomersGrid.BackgroundColor = System.Drawing.Color.White;
            this.CustomersGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.CustomersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersGrid.Location = new System.Drawing.Point(6, 34);
            this.CustomersGrid.Name = "CustomersGrid";
            this.CustomersGrid.ReadOnly = true;
            this.CustomersGrid.RowHeadersVisible = false;
            this.CustomersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomersGrid.Size = new System.Drawing.Size(1007, 570);
            this.CustomersGrid.TabIndex = 0;
            this.CustomersGrid.SelectionChanged += new System.EventHandler(this.SelectCustomer);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnNewMechanic);
            this.tabPage6.Controls.Add(this.btnDeleteMechanic);
            this.tabPage6.Controls.Add(this.btnDetailMechanic);
            this.tabPage6.Controls.Add(this.MechanicsGrid);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1019, 610);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Mechanici";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMechanic
            // 
            this.btnDeleteMechanic.Location = new System.Drawing.Point(218, 5);
            this.btnDeleteMechanic.Name = "btnDeleteMechanic";
            this.btnDeleteMechanic.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteMechanic.TabIndex = 7;
            this.btnDeleteMechanic.Text = "Smazat";
            this.btnDeleteMechanic.UseVisualStyleBackColor = true;
            this.btnDeleteMechanic.Click += new System.EventHandler(this.DeleteMechanic);
            // 
            // btnDetailMechanic
            // 
            this.btnDetailMechanic.Location = new System.Drawing.Point(112, 5);
            this.btnDetailMechanic.Name = "btnDetailMechanic";
            this.btnDetailMechanic.Size = new System.Drawing.Size(100, 25);
            this.btnDetailMechanic.TabIndex = 6;
            this.btnDetailMechanic.Text = "Detail";
            this.btnDetailMechanic.UseVisualStyleBackColor = true;
            this.btnDetailMechanic.Click += new System.EventHandler(this.DetailMechanic);
            // 
            // MechanicsGrid
            // 
            this.MechanicsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MechanicsGrid.BackgroundColor = System.Drawing.Color.White;
            this.MechanicsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.MechanicsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MechanicsGrid.Location = new System.Drawing.Point(6, 36);
            this.MechanicsGrid.Name = "MechanicsGrid";
            this.MechanicsGrid.ReadOnly = true;
            this.MechanicsGrid.RowHeadersVisible = false;
            this.MechanicsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MechanicsGrid.Size = new System.Drawing.Size(1007, 570);
            this.MechanicsGrid.TabIndex = 4;
            this.MechanicsGrid.SelectionChanged += new System.EventHandler(this.SelectMechanic);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.SalesGrid);
            this.tabPage4.Controls.Add(this.btnDetailSale);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1019, 610);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Prodeje";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SalesGrid
            // 
            this.SalesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SalesGrid.BackgroundColor = System.Drawing.Color.White;
            this.SalesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.SalesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesGrid.Location = new System.Drawing.Point(3, 34);
            this.SalesGrid.Name = "SalesGrid";
            this.SalesGrid.ReadOnly = true;
            this.SalesGrid.RowHeadersVisible = false;
            this.SalesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesGrid.Size = new System.Drawing.Size(1013, 573);
            this.SalesGrid.TabIndex = 3;
            this.SalesGrid.SelectionChanged += new System.EventHandler(this.SelectSale);
            // 
            // btnDetailSale
            // 
            this.btnDetailSale.Location = new System.Drawing.Point(3, 3);
            this.btnDetailSale.Name = "btnDetailSale";
            this.btnDetailSale.Size = new System.Drawing.Size(100, 25);
            this.btnDetailSale.TabIndex = 2;
            this.btnDetailSale.Text = "Detail prodeje";
            this.btnDetailSale.UseVisualStyleBackColor = true;
            this.btnDetailSale.Click += new System.EventHandler(this.DetailSale);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ReservationsGrid);
            this.tabPage5.Controls.Add(this.btnDetailReservation);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1019, 610);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Rezervace";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ReservationsGrid
            // 
            this.ReservationsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReservationsGrid.BackgroundColor = System.Drawing.Color.White;
            this.ReservationsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.ReservationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReservationsGrid.Location = new System.Drawing.Point(3, 34);
            this.ReservationsGrid.Name = "ReservationsGrid";
            this.ReservationsGrid.ReadOnly = true;
            this.ReservationsGrid.RowHeadersVisible = false;
            this.ReservationsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReservationsGrid.Size = new System.Drawing.Size(1013, 573);
            this.ReservationsGrid.TabIndex = 5;
            this.ReservationsGrid.SelectionChanged += new System.EventHandler(this.SelectReservation);
            // 
            // btnDetailReservation
            // 
            this.btnDetailReservation.Location = new System.Drawing.Point(3, 3);
            this.btnDetailReservation.Name = "btnDetailReservation";
            this.btnDetailReservation.Size = new System.Drawing.Size(100, 25);
            this.btnDetailReservation.TabIndex = 4;
            this.btnDetailReservation.Text = "Detail rezervace";
            this.btnDetailReservation.UseVisualStyleBackColor = true;
            this.btnDetailReservation.Click += new System.EventHandler(this.DetailReservation);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbYear);
            this.tabPage3.Controls.Add(this.stats);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1019, 610);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistiky";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(3, 3);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(111, 21);
            this.cbYear.TabIndex = 1;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.GetStatistics);
            // 
            // stats
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.stats.ChartAreas.Add(chartArea2);
            this.stats.Location = new System.Drawing.Point(3, 30);
            this.stats.Name = "stats";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Year";
            this.stats.Series.Add(series2);
            this.stats.Size = new System.Drawing.Size(1013, 577);
            this.stats.TabIndex = 0;
            this.stats.Text = "chart1";
            // 
            // btnNewMechanic
            // 
            this.btnNewMechanic.Location = new System.Drawing.Point(6, 5);
            this.btnNewMechanic.Name = "btnNewMechanic";
            this.btnNewMechanic.Size = new System.Drawing.Size(100, 25);
            this.btnNewMechanic.TabIndex = 8;
            this.btnNewMechanic.Text = "Nový";
            this.btnNewMechanic.UseVisualStyleBackColor = true;
            this.btnNewMechanic.Click += new System.EventHandler(this.NewMechanic);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1051, 660);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Prodejna vozidel";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbFiltr.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGrid)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsGrid)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SalesGrid)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReservationsGrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView CustomersGrid;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart stats;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView SalesGrid;
        private System.Windows.Forms.Button btnDetailSale;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnDetailCustomer;
        private System.Windows.Forms.FlowLayoutPanel VehiclesPanel;
        private System.Windows.Forms.GroupBox gbFiltr;
        private System.Windows.Forms.RadioButton rbSoldVehicles;
        private System.Windows.Forms.RadioButton rbReservedVehicles;
        private System.Windows.Forms.RadioButton rbUnsoldVehicles;
        private System.Windows.Forms.RadioButton rbAllVehicles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVyrobce;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtRok;
        private System.Windows.Forms.TextBox txtTachometr;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView ReservationsGrid;
        private System.Windows.Forms.Button btnDetailReservation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnDeleteMechanic;
        private System.Windows.Forms.Button btnDetailMechanic;
        private System.Windows.Forms.DataGridView MechanicsGrid;
        private System.Windows.Forms.Button btnNewMechanic;
    }
}

