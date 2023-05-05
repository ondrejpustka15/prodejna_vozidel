
namespace ProdejnaVozidel.Sale
{
    partial class NewSale
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
            this.dateSale = new System.Windows.Forms.DateTimePicker();
            this.btnProdat = new System.Windows.Forms.Button();
            this.cbZakaznik = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVozidlo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateSale
            // 
            this.dateSale.Location = new System.Drawing.Point(54, 96);
            this.dateSale.Name = "dateSale";
            this.dateSale.Size = new System.Drawing.Size(200, 20);
            this.dateSale.TabIndex = 0;
            // 
            // btnProdat
            // 
            this.btnProdat.Location = new System.Drawing.Point(54, 149);
            this.btnProdat.Name = "btnProdat";
            this.btnProdat.Size = new System.Drawing.Size(200, 23);
            this.btnProdat.TabIndex = 1;
            this.btnProdat.Text = "Prodat";
            this.btnProdat.UseVisualStyleBackColor = true;
            this.btnProdat.Click += new System.EventHandler(this.Prodat);
            // 
            // cbZakaznik
            // 
            this.cbZakaznik.FormattingEnabled = true;
            this.cbZakaznik.Location = new System.Drawing.Point(54, 122);
            this.cbZakaznik.Name = "cbZakaznik";
            this.cbZakaznik.Size = new System.Drawing.Size(200, 21);
            this.cbZakaznik.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nový prodej";
            // 
            // lblVozidlo
            // 
            this.lblVozidlo.AutoSize = true;
            this.lblVozidlo.Location = new System.Drawing.Point(51, 80);
            this.lblVozidlo.Name = "lblVozidlo";
            this.lblVozidlo.Size = new System.Drawing.Size(35, 13);
            this.lblVozidlo.TabIndex = 4;
            this.lblVozidlo.Text = "label2";
            // 
            // NewSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 217);
            this.Controls.Add(this.lblVozidlo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbZakaznik);
            this.Controls.Add(this.btnProdat);
            this.Controls.Add(this.dateSale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewSale";
            this.Text = "Nový prodej";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateSale;
        private System.Windows.Forms.Button btnProdat;
        private System.Windows.Forms.ComboBox cbZakaznik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVozidlo;
    }
}