﻿using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmMap : Form {
    private Character character;
    private Map map;
    private Game game;
    private Weapon thunder_Fury;
    private Weapon Crawler;
    private Weapon Destroyer;
    private Weapon Killer;
    private List<Weapon> CharWeaponList;
    private int level_on = 0 ;

    public FrmMap() {
      InitializeComponent();
     }

    private void FrmMap_Load(object sender, EventArgs e) {
      game = Game.GetGame();
      map = new Map();
      this.level_on += 1;
      character = map.LoadMap("Resources/level.txt", grpMap, 
        str => Resources.ResourceManager.GetObject(str) as Bitmap
      );
      thunder_Fury = new Weapon(null, "Thunder Fury", 5);
      Crawler = new Weapon(null, "Crawler", 6);
      Destroyer = new Weapon(null, "Destroyer", 7);
      Killer = new Weapon(null, "Killer", 9);
      character.inventory.AddWeapon(thunder_Fury);
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
        if (game.State == GameState.BOSSFIGHT) {
          FrmBossFight frmBossFight = new FrmBossFight();
          character.inventory.AddWeapon(Killer);
          frmBossFight.Show();
          
          }
        if (game.State == GameState.NEXT_LEVEL)
        {
            //TODO:ZAB
            this.level_on += 1;
            game.ChangeState(GameState.LOADING);
            // needs character so he moves on level 2 and more 
            string loadmap = "Resources/level" +level_on.ToString() +".txt";
            CharWeaponList = character.inventory.ReturnWeaponList();
            character = map.LoadMap(loadmap, grpMap,str => Resources.ResourceManager.GetObject(str) as Bitmap);
            character.inventory.SetWeaponList(CharWeaponList);
            if(level_on == 2)
            {
                character.inventory.AddWeapon(Crawler);
            }
            if(level_on == 3)
            {
                character.inventory.AddWeapon(Destroyer);
            }
            Width = grpMap.Width + 25;
            Height = grpMap.Height + 50;
            //moves chararter back to start of level 
            character.BackToStart();
            //code below resets the character to level 1 
            //game.SetCharacter(character);
                   
                  
        }
        if (game.State == GameState.DEAD)
                {
                    //TODO : ZAB
                    game.ChangeState(GameState.DEAD);
                    FrmGameOver frmGameOver = new FrmGameOver();
                    frmGameOver.Show();
                }
      }
    }
    }
}
