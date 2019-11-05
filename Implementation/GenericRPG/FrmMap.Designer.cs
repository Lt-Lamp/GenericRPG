namespace GenericRPG {
  partial class FrmMap {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.grpMap = new System.Windows.Forms.GroupBox();
            this.InvOpenLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grpMap
            // 
            this.grpMap.Location = new System.Drawing.Point(12, 12);
            this.grpMap.Name = "grpMap";
            this.grpMap.Size = new System.Drawing.Size(361, 238);
            this.grpMap.TabIndex = 1;
            this.grpMap.TabStop = false;
            // 
            // InvOpenLbl
            // 
            this.InvOpenLbl.AutoSize = true;
            this.InvOpenLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvOpenLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.InvOpenLbl.Location = new System.Drawing.Point(12, 347);
            this.InvOpenLbl.Name = "InvOpenLbl";
            this.InvOpenLbl.Size = new System.Drawing.Size(222, 20);
            this.InvOpenLbl.TabIndex = 14;
            this.InvOpenLbl.Text = "To Open Inventory, Press I";
            // 
            // FrmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(797, 411);
            this.Controls.Add(this.InvOpenLbl);
            this.Controls.Add(this.grpMap);
            this.Name = "FrmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.FrmMap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMap_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion
    private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.Label InvOpenLbl;
    }
}

