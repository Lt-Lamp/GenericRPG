﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary {
  public enum GameState {
    LOADING,
    NEXT_LEVEL,
    TITLE_SCREEN,
    ON_MAP,
    FIGHTING,
    BOSSFIGHT,
    DEAD,
    INVENTORY,
  }

  public class Game {
    private static Game game;

    public Character Character { get; private set; }
    public Weapon FWeapon { get; private set; }
    public Weapon SWeapon { get; private set; }
    public Weapon TWeapon { get; private set; }
    public Weapon RWeapon { get; private set; }

    public GameState State { get; private set; }

    private Game() {
      State = GameState.LOADING;
        }

    public static Game GetGame() {
      if (game == null)
        game = new Game();
      return game;
    }

    public void ChangeState(GameState newState) {
      State = newState;
    }

    public void SetCharacter(Character character) {
      Character = character;
    }

  }
}
