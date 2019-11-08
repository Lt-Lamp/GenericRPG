using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmArena : Form {
    private Game game;
    private Character character;
    private Enemy enemy;
    private Weapon weapon;
    private Weapon thunder_Fury;
    private Weapon cave_Crawler;
    private Weapon world_Destroyer;
    private Weapon boss_Killer;
    private Random rand;

    public FrmArena() {
      InitializeComponent();
    }
    private void btnEndFight_Click(object sender, EventArgs e) {
      EndFight();
    }
    private void EndFight() {
      Game.GetGame().ChangeState(GameState.ON_MAP);
      Close();
    }
    private void FrmArena_Load(object sender, EventArgs e) {

                rand = new Random();

      game = Game.GetGame();
      character = game.Character;
      enemy = new Enemy(rand.Next(character.Level + 1), Resources.enemy);
      weapon = character.inventory.ReturnMainWeapon();
      

      // stats
      UpdateStats();

                // pictures
                picCharacter.BackgroundImage = character.Pic.BackgroundImage;
                picEnemy.BackgroundImage = enemy.Img;

                // names
                lblPlayerName.Text = character.Name;
                lblEnemyName.Text = enemy.Name;
            
    }
    public void UpdateStats() {      
      lblPlayerLevel.Text = character.Level.ToString();
      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblPlayerStr.Text = (weapon.Damage).ToString();
      lblPlayerDef.Text = Math.Round(character.Def).ToString();
      lblPlayerMana.Text = Math.Round(character.Mana).ToString();
      lblPlayerXp.Text = Math.Round(character.XP).ToString();

      lblEnemyLevel.Text = enemy.Level.ToString();
      lblEnemyHealth.Text = Math.Round(enemy.Health).ToString();
      lblEnemyStr.Text = Math.Round(enemy.Str).ToString();
      lblEnemyDef.Text = Math.Round(enemy.Def).ToString();
      lblEnemyMana.Text = Math.Round(enemy.Mana).ToString();

      //lblWeaponDamage.Text = weapon.Damage.ToString();

      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblEnemyHealth.Text = Math.Round(enemy.Health).ToString();
    }
    private void btnSimpleAttack_Click(object sender, EventArgs e) {
      float prevEnemyHealth = enemy.Health;
      weapon.SimpleWeaponAttack(enemy);
      float enemyDamage = (float)Math.Round(prevEnemyHealth - enemy.Health);
      lblEnemyDamage.Text = enemyDamage.ToString();
      lblEnemyDamage.Visible = true;
      tmrEnemyDamage.Enabled = true;
      //TODO: ZAB
      SoundPlayer sp = new SoundPlayer(@"Resources\chararter_attack.wav");
      sp.Play();
            
      if (enemy.Health <= 0) {
        character.GainXP(enemy.XpDropped);
        lblEndFightMessage.Text = "You Gained " + Math.Round(enemy.XpDropped) + " xp!";
        character.Mana = 40;
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
        if (character.ShouldLevelUp) {
          FrmLevelUp frmLevelUp = new FrmLevelUp();
          frmLevelUp.Show();
        }
      }
      else {
        float prevPlayerHealth = character.Health;
        enemy.SimpleAttack(character);
        float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
        lblPlayerDamage.Text = playerDamage.ToString();
        lblPlayerDamage.Visible = true;
        tmrPlayerDamage.Enabled = true;
        //TODO: ZAB
        Thread.Sleep(175);//that is .175 of a second , lets the sound play out completely 
        sp = new SoundPlayer(@"Resources\emeny_attack.wav");
        sp.Play();
        if (character.Health <= 0) {
          UpdateStats();
          game.ChangeState(GameState.DEAD);
          sp = new SoundPlayer(@"Resources\game_over.wav");
          sp.Play();
          lblEndFightMessage.Text = "You Were Defeated!";
          lblEndFightMessage.Visible = true;
          Refresh();
          Thread.Sleep(1200);
          EndFight();
          FrmGameOver frmGameOver = new FrmGameOver();
          frmGameOver.Show();
        }
        else {
          UpdateStats();
        }
      }
    }

    private void btnManaAttack_Click(object sender, EventArgs e)
    {
        SoundPlayer sp = new SoundPlayer(@"Resources\chararter_attack.wav");
        float prevEnemyHealth = enemy.Health;
        weapon.ManaWeaponAttack(enemy);
        float enemyDamage = (float)Math.Round(prevEnemyHealth - enemy.Health);
        lblEnemyDamage.Text = enemyDamage.ToString();
        lblEnemyDamage.Visible = true;
        tmrEnemyDamage.Enabled = true;
        if (character.Mana != 0)
        {
        sp.Play();
        weapon.ManaWeaponAttack(enemy);
        character.Mana -= 10;
            if (enemy.Health <= 0)
            {
                character.GainXP(enemy.XpDropped);
                lblEndFightMessage.Text = "You Gained " + Math.Round(enemy.XpDropped) + " xp!";
                character.Mana = 40;
                lblEndFightMessage.Visible = true;
                Refresh();
                Thread.Sleep(1200);
                EndFight();
                if (character.ShouldLevelUp)
                {
                    FrmLevelUp frmLevelUp = new FrmLevelUp();
                    frmLevelUp.Show();
                }
            }
            else
            {
                float prevPlayerHealth = character.Health;
                enemy.SimpleAttack(character);
                float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
                lblPlayerDamage.Text = playerDamage.ToString();
                lblPlayerDamage.Visible = true;
                tmrPlayerDamage.Enabled = true;

                sp = new SoundPlayer(@"Resources\emeny_attack.wav");
                sp.Play();
                if (character.Health <= 0)
                {
                    UpdateStats();
                    game.ChangeState(GameState.DEAD);
                    lblEndFightMessage.Text = "You Were Defeated!";
                    lblEndFightMessage.Visible = true;
                    Refresh();
                    Thread.Sleep(1200);
                    EndFight();
                    FrmGameOver frmGameOver = new FrmGameOver();
                    frmGameOver.Show();
                }
                else
                {
                    UpdateStats();
                        
                }
            }
        }
        else
        {
            lblEndFightMessage.Text = "You have no more mana";
            lblEndFightMessage.Visible = true;
            lblEnemyDamage.Visible = false ;

        };
    }

  private void btnRun_Click(object sender, EventArgs e) {
      if (rand.NextDouble() < 0.25) {
        lblEndFightMessage.Text = "You Ran Like a Coward!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
      }
      else {
        enemy.SimpleAttack(character);
        UpdateStats();
      }
    }

    private void tmrPlayerDamage_Tick(object sender, EventArgs e) {
      lblPlayerDamage.Top -= 2;
      if (lblPlayerDamage.Top < 10) {
        lblPlayerDamage.Visible = false;
        tmrPlayerDamage.Enabled = false;
        lblPlayerDamage.Top = 52;
      }
    }

    private void tmrEnemyDamage_Tick(object sender, EventArgs e) {
      lblEnemyDamage.Top -= 2;
      if (lblEnemyDamage.Top < 10) {
        lblEnemyDamage.Visible = false;
        tmrEnemyDamage.Enabled = false;
        lblEnemyDamage.Top = 52;
      }
    }

        private void picEnemy_Click(object sender, EventArgs e)
        {

        }
    }
}
