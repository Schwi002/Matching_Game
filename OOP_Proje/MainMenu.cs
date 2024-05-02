using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Proje
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEN.Checked)
            {
                MainMenu.ActiveForm.Text = "Menu";
                btnEasy.Text = "\r\r\nEasy\r\n\r\n60 Moves";
                btnNormal.Text = "\r\r\nNormal\r\n\r\n50 Moves";
                btnHard.Text = "\r\r\nHard\r\n\r\n40 Moves";
            }
            else
            {
                MainMenu.ActiveForm.Text = "Menü";
                btnEasy.Text = "\r\r\nKolay\r\n\r\n60 Hamle";
                btnNormal.Text = "\r\r\nNormal\r\n\r\n50 Hamle";
                btnHard.Text = "\r\r\nZor\r\n\r\n40 Hamle";
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            string GameDifficulty;
            string GameLanguage;
            if (rdbEN.Checked)
            {
                GameLanguage = "EN";
            }
            else
            {
                GameLanguage = "TR";
            }
            Button clickedButton = sender as Button;
            GameDifficulty = clickedButton.Name;
            this.Hide();
            Game game = new Game();
            game.gameDifficulty = GameDifficulty;
            game.gameLanguage = GameLanguage;
            game.ShowDialog();
            this.Show();
        }       
    }
}
