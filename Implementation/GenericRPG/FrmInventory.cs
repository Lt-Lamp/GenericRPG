using GameLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericRPG
{
    public partial class FrmInventory : Form
    {
        private Game game;
        private Character character;

        public FrmInventory()
        {
            InitializeComponent();
        }

        private void UpdatePlayerInfo()
        {
            lblPlayerLevel.Text = character.Level.ToString();
            lblPlayerHealth.Text = Math.Round(character.Health).ToString();
            lblPlayerStr.Text = Math.Round(character.Str).ToString();
            lblPlayerDef.Text = Math.Round(character.Def).ToString();
            lblPlayerMana.Text = Math.Round(character.Mana).ToString();
            lblPlayerXp.Text = Math.Round(character.XP).ToString();
            lblPlayerName.Text = character.Name;
            lblPlayerWeaponCount.Text = character.inventory.ReturnWeaponList().Count().ToString();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            game = Game.GetGame();
            character = game.Character;

            UpdatePlayerInfo();
        }
    }
}
