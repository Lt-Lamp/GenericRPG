using GameLibrary;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmGameOver : Form {
    public FrmGameOver() {
      InitializeComponent();
    }

    private void btnQuit_Click(object sender, EventArgs e) {
      List<Form> openForms = new List<Form>();
      foreach (Form frm in Application.OpenForms) {
        openForms.Add(frm);
      }
      foreach(Form openForm in openForms) {
        if (openForm != this)
          openForm.Close();
      }
      Application.Exit();
    }

    private void btnPlayAgain_Click(object sender, EventArgs e) {
      Game game = Game.GetGame();
      game.Character.ResetStats();
      game.Character.BackToStart();
      game.ChangeState(GameState.ON_MAP);
      Close();
    }


        //TODO :ZAB
        private void btncontnue_Click(object sender, EventArgs e)
        {
            Game game = Game.GetGame();
            game.Character.BackToStart();
            game.Character.Continue();
            Close();
        }
    }
}
