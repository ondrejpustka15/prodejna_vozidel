
namespace ProdejnaVozidel.Reservation
{
    partial class NewReservation
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
            this.lblVozidlo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbZakaznik = new System.Windows.Forms.ComboBox();
            this.btnRezervovat = new System.Windows.Forms.Button();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblVozidlo
            // 
            this.lblVozidlo.AutoSize = true;
            this.lblVozidlo.Location = new System.Drawing.Point(51, 80);
            this.lblVozidlo.Name = "lblVozidlo";
            this.lblVozidlo.Size = new System.Drawing.Size(35, 13);
            this.lblVozidlo.TabIndex = 9;
            this.lblVozidlo.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nová rezervace";
            // 
            // cbZakaznik
            // 
            this.cbZakaznik.FormattingEnabled = true;
            this.cbZakaznik.Location = new System.Drawing.Point(54, 148);
            this.cbZakaznik.Name = "cbZakaznik";
            this.cbZakaznik.Size = new System.Drawing.Size(200, 21);
            this.cbZakaznik.TabIndex = 7;
            // 
            // btnRezervovat
            // 
            this.btnRezervovat.Location = new System.Drawing.Point(54, 175);
            this.btnRezervovat.Name = "btnRezervovat";
            this.btnRezervovat.Size = new System.Drawing.Size(200, 23);
            this.btnRezervovat.TabIndex = 6;
            this.btnRezervovat.Text = "Rezervovat";
            this.btnRezervovat.UseVisualStyleBackColor = true;
            this.btnRezervovat.Click += new System.EventHandler(this.Rezervovat);
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(54, 96);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 20);
            this.dateStart.TabIndex = 5;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(54, 122);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 10;
            this.dateEnd.Value = new System.DateTime(2021, 5, 19, 0, 0, 0, 0);
            // 
            // NewReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 231);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.lblVozidlo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbZakaznik);
            this.Controls.Add(this.btnRezervovat);
            this.Controls.Add(this.dateStart);
            this.Name = "NewReservation";
            this.Text = "NewReservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVozidlo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbZakaznik;
        private System.Windows.Forms.Button btnRezervovat;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
    }
}