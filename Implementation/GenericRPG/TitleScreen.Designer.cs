﻿namespace GenericRPG
{
	partial class TitleScreen
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Lime;
			this.button1.Location = new System.Drawing.Point(232, 186);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "New Game";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.btnNewGame_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 245);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 30);
			this.button2.TabIndex = 1;
			this.button2.Text = "Load Game";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnLoadGame_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(232, 304);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(100, 30);
			this.button3.TabIndex = 2;
			this.button3.Text = "Option";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.btnOption_Click);
			// 
			// TitleScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::GenericRPG.Properties.Resources.titlescreen;
			this.ClientSize = new System.Drawing.Size(344, 361);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "TitleScreen";
			this.Text = "TitleScreen";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}