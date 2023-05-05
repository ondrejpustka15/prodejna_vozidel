
namespace ProdejnaVozidel.Vehicle
{
    partial class VehicleItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStavInfo = new System.Windows.Forms.Label();
            this.lblStav = new System.Windows.Forms.Label();
            this.lblZakaznik = new System.Windows.Forms.Label();
            this.btnDeleteVehicle = new System.Windows.Forms.Button();
            this.btnVehicleDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFullName.Location = new System.Drawing.Point(44, 27);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(139, 37);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "FullName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(48, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stav:";
            // 
            // lblStavInfo
            // 
            this.lblStavInfo.AutoSize = true;
            this.lblStavInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStavInfo.Location = new System.Drawing.Point(48, 119);
            this.lblStavInfo.Name = "lblStavInfo";
            this.lblStavInfo.Size = new System.Drawing.Size(58, 15);
            this.lblStavInfo.TabIndex = 2;
            this.lblStavInfo.Text = "StavInfo:";
            // 
            // lblStav
            // 
            this.lblStav.AutoSize = true;
            this.lblStav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStav.Location = new System.Drawing.Point(130, 94);
            this.lblStav.Name = "lblStav";
            this.lblStav.Size = new System.Drawing.Size(29, 15);
            this.lblStav.TabIndex = 3;
            this.lblStav.Text = "Stav";
            // 
            // lblZakaznik
            // 
            this.lblZakaznik.AutoSize = true;
            this.lblZakaznik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblZakaznik.Location = new System.Drawing.Point(130, 119);
            this.lblZakaznik.Name = "lblZakaznik";
            this.lblZakaznik.Size = new System.Drawing.Size(53, 15);
            this.lblZakaznik.TabIndex = 4;
            this.lblZakaznik.Text = "Zakaznik";
            // 
            // btnDeleteVehicle
            // 
            this.btnDeleteVehicle.Location = new System.Drawing.Point(776, 81);
            this.btnDeleteVehicle.Name = "btnDeleteVehicle";
            this.btnDeleteVehicle.Size = new System.Drawing.Size(129, 24);
            this.btnDeleteVehicle.TabIndex = 5;
            this.btnDeleteVehicle.Text = "Smazat";
            this.btnDeleteVehicle.UseVisualStyleBackColor = true;
            this.btnDeleteVehicle.Click += new System.EventHandler(this.DeleteVehicle);
            // 
            // btnVehicleDetail
            // 
            this.btnVehicleDetail.Location = new System.Drawing.Point(776, 113);
            this.btnVehicleDetail.Name = "btnVehicleDetail";
            this.btnVehicleDetail.Size = new System.Drawing.Size(129, 27);
            this.btnVehicleDetail.TabIndex = 6;
            this.btnVehicleDetail.Text = "Detail";
            this.btnVehicleDetail.UseVisualStyleBackColor = true;
            this.btnVehicleDetail.Click += new System.EventHandler(this.DetailVehicle);
            // 
            // VehicleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnVehicleDetail);
            this.Controls.Add(this.btnDeleteVehicle);
            this.Controls.Add(this.lblZakaznik);
            this.Controls.Add(this.lblStav);
            this.Controls.Add(this.lblStavInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFullName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "VehicleItem";
            this.Size = new System.Drawing.Size(969, 173);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStavInfo;
        private System.Windows.Forms.Label lblStav;
        private System.Windows.Forms.Label lblZakaznik;
        private System.Windows.Forms.Button btnDeleteVehicle;
        private System.Windows.Forms.Button btnVehicleDetail;
    }
}
