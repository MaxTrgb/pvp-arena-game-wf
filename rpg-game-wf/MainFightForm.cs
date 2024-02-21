using C_CLASS25._11._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace rpg_game_wf
{
    public partial class MainFightForm : Form
    {
        int damage = 0;

        private ConsoleKeyInfo move1;
        private ConsoleKeyInfo move2;
        private bool playerWins = false;

        PalyersWins palyersWins = new PalyersWins();

        public MainFightForm()
        {
            InitializeComponent();
        }

        private void MainFightForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                damage = StoreInfo.Player1.CalculateDamage(StoreInfo.Player2.AttackPower, Hero.AttackType.Physical, StoreInfo.Player1.CriticalChance, StoreInfo.Player1.Name, move1);
                damage = StoreInfo.Player2.Defend(damage);
                StoreInfo.isPlayer1Turn = false;
                StoreInfo.totalDamagePlayerOne += damage;
                label1.Text = StoreInfo.totalDamagePlayerOne.ToString();
            }
            else
            {
                damage = StoreInfo.Player2.CalculateDamage(StoreInfo.Player1.AttackPower, Hero.AttackType.Physical, StoreInfo.Player2.CriticalChance, StoreInfo.Player2.Name, move1);
                damage = StoreInfo.Player1.Defend(damage);
                StoreInfo.isPlayer1Turn = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1.StartDefending();
                StoreInfo.isPlayer1Turn = false;

            }
            else
            {
                StoreInfo.Player2.StartDefending();
                StoreInfo.isPlayer1Turn = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1.Heal();
                StoreInfo.isPlayer1Turn = false;
            }
            else
            {
                StoreInfo.Player2.Heal();
                StoreInfo.isPlayer1Turn= true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                damage = StoreInfo.Player1.CalculateDamage(StoreInfo.Player2.AttackPower, Hero.AttackType.Physical, StoreInfo.Player1.CriticalChance, StoreInfo.Player1.Name, move1);
                damage = StoreInfo.Player1.Skill(damage);
                damage = StoreInfo.Player2.Defend(damage);
                StoreInfo.isPlayer1Turn = false;
            }
            else
            {
                damage = StoreInfo.Player2.CalculateDamage(StoreInfo.Player1.AttackPower, Hero.AttackType.Physical, StoreInfo.Player2.CriticalChance, StoreInfo.Player2.Name, move1);
                damage = StoreInfo.Player2.Skill(damage);
                damage = StoreInfo.Player1.Defend(damage);
                StoreInfo.isPlayer1Turn = true;
            }
        }
    }
}
