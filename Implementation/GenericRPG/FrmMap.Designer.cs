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
            this.grpMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMap
            // 
            this.grpMap.Controls.Add(this.InvOpenLbl);
            this.grpMap.Location = new System.Drawing.Point(88, 122);
            this.grpMap.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.grpMap.Name = "grpMap";
            this.grpMap.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.grpMap.Size = new System.Drawing.Size(1413, 870);
            this.grpMap.TabIndex = 1;
            this.grpMap.TabStop = false;
            // 
            // InvOpenLbl
            // 
            this.InvOpenLbl.AutoSize = true;
            this.InvOpenLbl.BackColor = System.Drawing.Color.Transparent;
            this.InvOpenLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvOpenLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.InvOpenLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InvOpenLbl.Location = new System.Drawing.Point(16, 817);
            this.InvOpenLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.InvOpenLbl.Name = "InvOpenLbl";
            this.InvOpenLbl.Size = new System.Drawing.Size(519, 46);
            this.InvOpenLbl.TabIndex = 7;
            this.InvOpenLbl.Text = "To Open Inventory, Press I";
            this.InvOpenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2661, 1261);
            this.Controls.Add(this.grpMap);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.FrmMap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMap_KeyDown);
            this.grpMap.ResumeLayout(false);
            this.grpMap.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.Label InvOpenLbl;
    }
}

