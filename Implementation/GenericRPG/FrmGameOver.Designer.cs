namespace GenericRPG {
  partial class FrmGameOver {
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
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPlayAgain.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPlayAgain.FlatAppearance.BorderSize = 2;
            this.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayAgain.ForeColor = System.Drawing.Color.White;
            this.btnPlayAgain.Location = new System.Drawing.Point(98, 253);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(137, 42);
            this.btnPlayAgain.TabIndex = 0;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.Maroon;
            this.btnQuit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnQuit.FlatAppearance.BorderSize = 2;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Location = new System.Drawing.Point(98, 310);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(137, 42);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnContinue.FlatAppearance.BorderSize = 2;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(98, 370);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(137, 42);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btncontnue_Click);
            // 
            // FrmGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GenericRPG.Properties.Resources.gameover;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(905, 471);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPlayAgain);
            this.Name = "FrmGameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Over";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnPlayAgain;
    private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnContinue;
    }
}