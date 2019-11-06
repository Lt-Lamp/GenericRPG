using System.IO;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace GameLibrary {
  public class Map {
    private int[,] layout;
    private const int TOP_PAD = 10;
    private const int BOUNDARY_PAD = 5;
    private const int BLOCK_SIZE = 50;
    public double encounterChance;
    private Random rand;

    public int CharacterStartRow { get; private set; }
    public int CharacterStartCol { get; private set; }
    private int NumRows { get { return layout.GetLength(0); } }
    private int NumCols { get { return layout.GetLength(1); } }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapFile"></param>
    /// <param name="grpMap"></param>
    /// <param name="LoadImg"></param>
    /// <returns></returns>
    public Character LoadMap(string mapFile, GroupBox grpMap, Func<string, Bitmap> LoadImg) {
      //TOD: ZAB
      //clears the map of pictures
      grpMap.Controls.Clear();
      // declare and initialize locals
      int top = TOP_PAD;
      int left = BOUNDARY_PAD;
      Character character = null;
      List<string> mapLines = new List<string>();
      
      // read from map file
      using (FileStream fs = new FileStream(mapFile, FileMode.Open)) {
        using (StreamReader sr = new StreamReader(fs)) {
          string line = sr.ReadLine();
          while (line != null) {
            mapLines.Add(line);
            line = sr.ReadLine();
          }
        }
      }
      
      // load map file into layout and create PictureBox objects
      layout = new int[mapLines.Count, mapLines[0].Length];
      int i = 0;
      foreach (string mapLine in mapLines) {
        int j = 0;
        foreach (char c in mapLine) {
          int val = c - '0';
          layout[i, j] = (val == 1 ? 1 : 0);
          //this is where it reads what the "vals" on the map to see which pictures to load.
          PictureBox pb = CreateMapCell(val, LoadImg);
          if (pb != null) {
            pb.Top = top;
            pb.Left = left;
            grpMap.Controls.Add(pb);
            
          }
          if (val == 2) {
            CharacterStartRow = i;
            CharacterStartCol = j;
            //TODO : ZAB
            //just a check probbily not needed
            if (character == null)
                        {
                            character = new Character(pb, new Position(i, j), this);
                        }
            else
                        {
                            layout[i, j] = 1;
                        }
      
          }
          //TODO : ZAB
          //makes the 3(next_level) show up on the layout map along with other numbers 
          if (val ==3)
                    {
                        layout[i, j] = 3;
                    }
          if (val == 4)
                    {
                        layout[i, j] = 4;
                    }
          if(val == 5)
                    {
                        layout[i, j] = 5;
                    }
          left += BLOCK_SIZE;
          j++;
        }
        left = BOUNDARY_PAD;
        top += BLOCK_SIZE;
        i++;
      }

      // resize Group
      grpMap.Width = NumCols * BLOCK_SIZE + BOUNDARY_PAD * 2;
      grpMap.Height = NumRows * BLOCK_SIZE + TOP_PAD + BOUNDARY_PAD;
      grpMap.Top = 5;
      grpMap.Left = 5;

      // initialize for game
      encounterChance = 0.15;
      rand = new Random();
      Game.GetGame().ChangeState(GameState.ON_MAP);

      // return Character object from reading map
      return character;
    }
     

    private PictureBox CreateMapCell(int legendValue, Func<string, Bitmap> LoadImg) {
    PictureBox result = null;
      //this is just for the pictures to load 
      switch (legendValue) {
        // walkable
        case 0:
         break;
        
        //wall
        case 1:
          result = new PictureBox() {
            BackgroundImage = LoadImg("wall"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE
          };
          break;
                    


        // character
        case 2:
          result = new PictureBox() {
            BackgroundImage = LoadImg("character"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE
          };
          break;

        // next level
        // only reads the txt file , need to load new level at charater?
        case 3:
          result = new PictureBox()
          {
            //TODO : ZAB
            //changed the the IMG b/c we have more then 2 levels
            BackgroundImage = LoadImg("next_level"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE  
          };
          break;

        // boss
        case 4:
          result = new PictureBox() {
            BackgroundImage = LoadImg("fightboss"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE
          };
          break;

        // quit
        case 5:
          result = new PictureBox() {
            BackgroundImage = LoadImg("quitgame"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE
          };
          break;
        //this not needed in c# .....but keeping  it 
        default:

        break;
      }
      return result;
    }

    public bool IsValidPos(Position pos) {
      if (pos.row < 0 || pos.row >= NumRows || pos.col < 0 || pos.col >= NumCols || layout[pos.row, pos.col] == 1) {
        return false;
      }
      //DEBUG:ZAB
      if (rand.NextDouble() < encounterChance) {
        encounterChance = 0.15;
        Game.GetGame().ChangeState(GameState.FIGHTING);
      }
      //TODO:ZAB
      if (layout[pos.row, pos.col] == 3)
            {
                Game.GetGame().ChangeState(GameState.NEXT_LEVEL);
            }
      if (layout[pos.row, pos.col] == 5)
            {
                Game.GetGame().ChangeState(GameState.DEAD);
            }
      else {
        //DEBUG:ZAB
        encounterChance += 0.10;
      }

      return true;
    }

    public Position RowColToTopLeft(Position p) {
      return new Position(p.row * BLOCK_SIZE + TOP_PAD, p.col * BLOCK_SIZE + BOUNDARY_PAD);
    }
  }
}
