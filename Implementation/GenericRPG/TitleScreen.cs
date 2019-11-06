using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibrary;

namespace GenericRPG
{
	public partial class TitleScreen : Form
	{
		private Game game;

		public TitleScreen()
		{
			InitializeComponent();
		}

		private void btnNewGame_Click(object sender, EventArgs e)
		{
			game = Game.GetGame();
			FrmMap frmMap = new FrmMap();
			frmMap.Show();

		}

		private void btnLoadGame_Click(object sender, EventArgs e)
		{

		}

		private void btnOption_Click(object sender, EventArgs e)
		{

		}
	}
}
