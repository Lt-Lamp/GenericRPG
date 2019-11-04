using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmMap : Form {
    private Character character;
    private Map map;
    private Game game;

    public FrmMap() {
      InitializeComponent();
     }

    private void FrmMap_Load(object sender, EventArgs e) {
      game = Game.GetGame();
      map = new Map();
      character = map.LoadMap("Resources/level.txt", grpMap, 
        str => Resources.ResourceManager.GetObject(str) as Bitmap
      );
      this.Focus();
      Width = grpMap.Width + 25;
      Height = grpMap.Height + 50;
      game.SetCharacter(character);
    }

    private void FrmMap_KeyDown(object sender, KeyEventArgs e) {
      MoveDir dir = MoveDir.NO_MOVE;
      switch (e.KeyCode) {
        case Keys.Left:
          dir = MoveDir.LEFT;
          break;
        case Keys.Right:
          dir = MoveDir.RIGHT;
          break;
        case Keys.Up:
          dir = MoveDir.UP;
          break;
        case Keys.Down:
          dir = MoveDir.DOWN;
          break;
        case Keys.I:
          FrmInventory frmInventory = new FrmInventory();
          frmInventory.Show();
          break;
      }
      if (dir != MoveDir.NO_MOVE) {
        character.Move(dir);
        if (game.State == GameState.FIGHTING) {
          FrmArena frmArena = new FrmArena();
          frmArena.Show();
        }
        if (game.State == GameState.NEXT_LEVEL)
                {
                    //TODO:ZAB
                    game.ChangeState(GameState.LOADING);
                    // needs character so he moves on level 2 and more 
                    character = map.LoadMap("Resources/level2.txt", grpMap,str => Resources.ResourceManager.GetObject(str) as Bitmap);
                    Width = grpMap.Width + 25;
                    Height = grpMap.Height + 50;
                    //moves chararter back to start of level 
                    character.BackToStart();
                    //code below resets the character to level 1 
                    //game.SetCharacter(character);
                   
                  
                }
      }
    }
    }
}
