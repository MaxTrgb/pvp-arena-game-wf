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

namespace rpg_game_wf
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.MainMenu menu = new System.Windows.Forms.MainMenu();
        ChoseHeroMenu chooseHeros = new ChoseHeroMenu();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new startBattle();
            form.StartPosition = FormStartPosition.Manual;
            form.Height = this.Height;
            form.Width = this.Width;
            form.Location = this.Location;
            form.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatisticsManager.runStatistics();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
