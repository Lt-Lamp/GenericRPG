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

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            game = Game.GetGame();
            character = game.Character;

            CheckWeaponStatus();

            UpdatePlayerInfo();
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
            lblPlayerWeaponCount.Text = character.inventory.ReturnWeaponList().Count.ToString();
        }

        public void CheckWeaponStatus()
        {
           List<Weapon> weapons = character.inventory.ReturnWeaponList();
           HideWeaponInfoOne(false);
           HideWeaponInfoTwo(false);
           HideWeaponInfoThree(false);
           HideWeaponInfoFour(false);
           if(weapons.Count >= 1)
            {
                HideWeaponInfoOne(true);
                WeaponOneLbl.Text = weapons[0].Name;
                weaponOnePic.SizeMode = PictureBoxSizeMode.StretchImage;
                weaponOnePic.Image = weapons[0].Img;
            }
           if(weapons.Count >= 2)
            {
                HideWeaponInfoTwo(true);
                WeaponTwoLbl.Text = weapons[1].Name;
                weaponTwoPic.SizeMode = PictureBoxSizeMode.StretchImage;
                weaponTwoPic.Image = weapons[1].Img;
            }
            if (weapons.Count >= 3)
            {
                HideWeaponInfoThree(true);
                WeaponThreeLbl.Text = weapons[2].Name;
                weaponThreePic.SizeMode = PictureBoxSizeMode.StretchImage;
                weaponThreePic.Image = weapons[2].Img;
            }
            if (weapons.Count >= 4)
            {
                HideWeaponInfoFour(true);
                WeaponFourLbl.Text = weapons[3].Name;
                weaponFourPic.SizeMode = PictureBoxSizeMode.StretchImage;
                weaponFourPic.Image = weapons[3].Img;
            }
        }

        public void HideWeaponInfoOne(bool HideBool)
        {
            WeaponOneLbl.Visible = HideBool;
            weaponOnePic.Visible = HideBool;
            btnWeaponOne.Visible = HideBool;
        }

        public void HideWeaponInfoTwo(bool HideBool)
        {
            WeaponTwoLbl.Visible = HideBool;
            weaponTwoPic.Visible = HideBool;
            btnWeaponTwo.Visible = HideBool;
        }

        public void HideWeaponInfoThree(bool HideBool)
        {
            WeaponThreeLbl.Visible = HideBool;
            weaponThreePic.Visible = HideBool;
            btnWeaponThree.Visible = HideBool;
        }

        public void HideWeaponInfoFour(bool HideBool)
        {
            WeaponFourLbl.Visible = HideBool;
            weaponFourPic.Visible = HideBool;
            btnWeaponFour.Visible = HideBool;
        }

        private void InvExitButton_Click(object sender, EventArgs e)
        {
            Game.GetGame().ChangeState(GameState.ON_MAP);
            Close();
        }

        private void btnWeaponOne_Click(object sender, EventArgs e)
        {
            character.inventory.SetMainWeapon(0);
        }

        private void btnWeaponTwo_Click(object sender, EventArgs e)
        {
            character.inventory.SetMainWeapon(1);
        }

        private void btnWeaponThree_Click(object sender, EventArgs e)
        {
            character.inventory.SetMainWeapon(2);
        }

        private void btnWeaponFour_Click(object sender, EventArgs e)
        {
            character.inventory.SetMainWeapon(3);
        }
    }
}
