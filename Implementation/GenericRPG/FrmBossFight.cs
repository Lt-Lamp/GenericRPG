using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG
{
    public partial class FrmBossFight : Form
    {
        private Game game;
        private Character character;
        private Weapon weapon;
        private Random rand;
        private Boss boss;

        public FrmBossFight()
        {
            InitializeComponent();
            SoundPlayer sp = new SoundPlayer(@"Resources\bossmusic.wav");
            sp.Play();
        }
        private void btnEndFight_Click(object sender, EventArgs e)
        {
            EndFight();
        }
        private void EndFight()
        {
            Game.GetGame().ChangeState(GameState.ON_MAP);
            Close();
        }
        private void FrmBossFight_Load(object sender, EventArgs e)
        {

            rand = new Random();

            game = Game.GetGame();
            character = game.Character;
            weapon = character.inventory.ReturnMainWeapon();
            boss = new Boss(rand.Next(character.Level + 3), Resources.boss);

            // stats
            UpdateStats();

            // pictures
            picCharacter.BackgroundImage = character.Pic.BackgroundImage;
            picEnemy.BackgroundImage = boss.Img;

            // names
            lblPlayerName.Text = character.Name;
            lblEnemyName.Text = boss.Name;

            
        }
        public void UpdateStats()
        {

            lblPlayerLevel.Text = character.Level.ToString();
            lblPlayerHealth.Text = Math.Round(character.Health).ToString();
            lblPlayerStr.Text = Math.Round(character.Str).ToString();
            lblPlayerDef.Text = Math.Round(character.Def).ToString();
            lblPlayerMana.Text = Math.Round(character.Mana).ToString();
            lblPlayerXp.Text = Math.Round(character.XP).ToString();

            lblEnemyLevel.Text = boss.Level.ToString();
            lblEnemyHealth.Text = Math.Round(boss.Health).ToString();
            lblEnemyStr.Text = Math.Round(boss.Str).ToString();
            lblEnemyDef.Text = Math.Round(boss.Def).ToString();
            lblEnemyMana.Text = Math.Round(boss.Mana).ToString();

            lblPlayerHealth.Text = Math.Round(character.Health).ToString();
            lblEnemyHealth.Text = Math.Round(boss.Health).ToString();
        }
        private void btnSimpleAttack_Click(object sender, EventArgs e)
        {
            if (lblEndFightMessage.Visible == true)
            {
                lblEndFightMessage.Visible = false;
            }
            float prevEnemyHealth = boss.Health;
            weapon.SimpleWeaponAttack(boss);
            float enemyDamage = (float)Math.Round(prevEnemyHealth - boss.Health);
            lblEnemyDamage.Text = enemyDamage.ToString();
            lblEnemyDamage.Visible = true;
            tmrEnemyDamage.Enabled = true;
            //TODO: ZAB
            SoundPlayer sp = new SoundPlayer(@"Resources\bossmusic.wav");
            if (boss.Health <= 0)
            {
                character.GainXP(boss.XpDropped);
                lblEndFightMessage.Text = "You Gained " + Math.Round(boss.XpDropped) + " xp!";
                lblEndFightMessage.Visible = true;
                SoundPlayer bg = new SoundPlayer(@"Resources\victory.wav");
                bg.Play();
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
                boss.SimpleAttack(character);
                float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
                lblPlayerDamage.Text = playerDamage.ToString();
                lblPlayerDamage.Visible = true;
                tmrPlayerDamage.Enabled = true;
                //TODO: ZAB
                Thread.Sleep(175);//that is .175 of a second , lets the sound play out completely 
                if (character.Health <= 0)
                {
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
                else
                {
                    UpdateStats();
                }
            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(@"Resources\bossmusic.wav");
            boss.SimpleAttack(character);
                UpdateStats();
                lblEndFightMessage.Text = "You can't run from the boss!";
                lblEndFightMessage.Visible = true;

            if (character.Health <= 0)
            {
                UpdateStats();
                game.ChangeState(GameState.DEAD);
                sp.Play();
                lblEndFightMessage.Text = "You Were Defeated!";
                lblEndFightMessage.Visible = true;
                Refresh();
                Thread.Sleep(1200);
                EndFight();
                FrmGameOver frmGameOver = new FrmGameOver();
                frmGameOver.Show();
            }

        }

        private void tmrPlayerDamage_Tick(object sender, EventArgs e)
        {
            lblPlayerDamage.Top -= 2;
            if (lblPlayerDamage.Top < 10)
            {
                lblPlayerDamage.Visible = false;
                tmrPlayerDamage.Enabled = false;
                lblPlayerDamage.Top = 52;
            }
        }

        private void tmrEnemyDamage_Tick(object sender, EventArgs e)
        {
            lblEnemyDamage.Top -= 2;
            if (lblEnemyDamage.Top < 10)
            {
                lblEnemyDamage.Visible = false;
                tmrEnemyDamage.Enabled = false;
                lblEnemyDamage.Top = 52;
            }
        }


        private void btnMagicAttack_Click(object sender, EventArgs e)
        {
            float prevEnemyHealth = boss.Health;
            weapon.ManaWeaponAttack(boss);
            float enemyDamage = (float)Math.Round(prevEnemyHealth - boss.Health);
            lblEnemyDamage.Text = enemyDamage.ToString();
            lblEnemyDamage.Visible = true;
            tmrEnemyDamage.Enabled = true;
            if (character.Mana != 0)
            {
                weapon.ManaWeaponAttack(boss);
                character.Mana -= 10;
                if (boss.Health <= 0)
                {
                    character.GainXP(boss.XpDropped);
                    lblEndFightMessage.Text = "You Gained " + Math.Round(boss.XpDropped) + " xp!";
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
                    boss.SimpleAttack(character);
                    float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
                    lblPlayerDamage.Text = playerDamage.ToString();
                    lblPlayerDamage.Visible = true;
                    tmrPlayerDamage.Enabled = true;

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
                lblEnemyDamage.Visible = false;

            };
        }
    }
}
