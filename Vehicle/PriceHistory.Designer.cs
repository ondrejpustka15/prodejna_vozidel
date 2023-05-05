
namespace ProdejnaVozidel.Vehicle
{
    partial class PriceHistory
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
            this.PriceGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PriceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PriceGrid
            // 
            this.PriceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PriceGrid.BackgroundColor = System.Drawing.Color.White;
            this.PriceGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.PriceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PriceGrid.Location = new System.Drawing.Point(12, 12);
            this.PriceGrid.Name = "PriceGrid";
            this.PriceGrid.ReadOnly = true;
            this.PriceGrid.RowHeadersVisible = false;
            this.PriceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PriceGrid.Size = new System.Drawing.Size(776, 426);
            this.PriceGrid.TabIndex = 4;
            // 
            // PriceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PriceGrid);
            this.Name = "PriceHistory";
            this.Text = "Historie ceny";
            ((System.ComponentModel.ISupportInitialize)(this.PriceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PriceGrid;
    }
}