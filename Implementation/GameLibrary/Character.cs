using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace GameLibrary {
  public struct Position {
    public int row;
    public int col;

    /// <summary>
    /// Construct a new 2D position
    /// </summary>
    /// <param name="row">Given row or y value</param>
    /// <param name="col">Given col or x value</param>
    public Position(int row, int col) {
      this.row = row;
      this.col = col;
    }
  }

public struct Inventory
{
    public int MainWeapon;
    public List<Weapons> WeaponList;
    public Inventory(int main, List<Weapons> weplist)
        {
            this.MainWeapon = main;
            this.WeaponList = weplist;
        }
    public void AddWeapon(Weapons weapon)
        {
            if (MainWeapon == -1)
            {
                WeaponList[0] = weapon;
            }
            else
            {
                WeaponList.Add(weapon);
            }
        }
    public void SetMainWeapon(int choosenindex)
        {
            if(choosenindex < WeaponList.Count + 1 && choosenindex < 7)
            {
                MainWeapon = choosenindex;
            }
        }
    public List<Weapons> ReturnWeaponList()
        {
            return WeaponList;
        }
    public Weapons ReturnMainWeapon()
        {
            return WeaponList[MainWeapon];
        }
    public void ResetWeaponList()
        {
            WeaponList.Clear();
            MainWeapon = -1;
        }
    }

  /// <summary>
  /// This represents our player in our game
  /// </summary>
  public class Character : Mortal {
    public PictureBox Pic { get; private set; }
    private Position pos;
    public Inventory inventory;
    private Map map;
    public float XP { get; private set; }
    public bool ShouldLevelUp { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="pos"></param>
    /// <param name="map"></param>
    public Character(PictureBox pb, Position pos, Inventory inv, Map map) : base("Player 1", 1) {
      Pic = pb;
      this.pos = pos;
      this.inventory = inv;
      this.map = map;
      
      ShouldLevelUp = false;
    }

    public void GainXP(float amount) {
      XP += amount;

      // every 100 experience points you gain a level
      if ((int)XP / 100 >= Level) {
        ShouldLevelUp = true;
      }
    }

    public override void LevelUp() {
      base.LevelUp();
      ShouldLevelUp = false;
    }

    public void PickUpWeapon() {
      //inventory.AddWeapon(map.)
    }

    public void BackToStart() {
      pos.row = map.CharacterStartRow;
      pos.col = map.CharacterStartCol;
      Position topleft = map.RowColToTopLeft(pos);
      Pic.Left = topleft.col;
      Pic.Top = topleft.row;
    }
    
    public override void ResetStats() {
      base.ResetStats();
      XP = 0;
    }

    public void Move(MoveDir dir) {
      Position newPos = pos;
      switch (dir) {
        case MoveDir.UP:
          newPos.row--;
          break;
        case MoveDir.DOWN:
          newPos.row++;
          break;
        case MoveDir.LEFT:
          newPos.col--;
          break;
        case MoveDir.RIGHT:
          newPos.col++;
          break;
      }
      if (map.IsValidPos(newPos)) {
        pos = newPos;
        Position topleft = map.RowColToTopLeft(pos);
        Pic.Left = topleft.col;
        Pic.Top = topleft.row;
      }
    }
  }
}
