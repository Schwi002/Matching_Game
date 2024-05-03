using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Game : Form
    {
        public string GameDifficulty { get; set; }
        public string GameLanguage { get; set; }
        int moveCount = 0;
        int gameScore = 0;

        public Game()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        private void Game_Load(object sender, EventArgs e)
        {
            SetGameDifficulty();
            GetLanguage();
            lblMoves.Text = GetMoves();
        }

        private void SetGameDifficulty()
        {
            if (GameDifficulty == "Easy")
            {
                moveCount = 60;
            }
            else if (GameDifficulty == "Normal")
            {
                moveCount = 50;
            }
            else
            {
                moveCount = 40;
            }
            lblMoves.Text = moveCount.ToString();
        }
        // iki eşleyeceğimiz simgeyi hafızada tutan değerler
        Label firstClicked = null;
        Label secondClicked = null;

        readonly Random random = new Random();
        //Webding fontuyla kullanacağımız karakter listesi
        readonly List<string> icons = new List<string>()
        {
        "!", "!", "N", "N", "Y", "Y", "k", "k", "n", "n", "b", "b", "v", "v", "w", "w", "z", "z", "R", "R"
        };

        private void AssignIconsToSquares()
        {
            // tblGame içindeki her label için listeden rastgele simge ekler
            foreach (Control control in tblGame.Controls)
            {
                if (control is Label iconLabel)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        // labellara hızlı tıklayıp oyunun kitlenmesini önlemek için gerekli değer
        private bool resetInProgress = false;
        private async void Label_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(sender is Label clickedLabel))
                    return; // Handle unexpected sender type

                if (clickedLabel.ForeColor == Color.Black || resetInProgress)
                    return; // Önceden tıklanmış simgeye tıklamayı veya reset boolu açıkken tıklamayı önler

                moveCount--;
                lblMoves.Text = GetMoves();
                lblScore.Text = GetScore();

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    if (moveCount < 1)
                    {
                        MessageBox.Show(GetGameOverMessage(), GetGameOverTitle());
                        this.Hide();
                    }
                    else
                    {
                        return;
                    }
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Simgeler eşleşmiş mi kontrol eder
                if (firstClicked.Text == secondClicked.Text)
                {
                    if (GameDifficulty == "Easy")
                    {
                        gameScore += 10;
                    }
                    else if (GameDifficulty == "Normal")
                    {
                        gameScore += 20;
                    }
                    else
                    {
                        gameScore += 50;
                    }

                    lblMoves.Text = GetMoves();
                    lblScore.Text = GetScore();
                    firstClicked.BackColor = Color.Red;
                    secondClicked.BackColor = Color.Red;
                    firstClicked = null;
                    secondClicked = null;
                }
                else
                {
                    // Simgeler eşleşmezse tekrar arkaplanla aynı renge getirir   
                    // Simgelere bastıktan sonra kısa süreliğine basmayı engelleyerek hata almayı önler
                    resetInProgress = true;

                    await Task.Delay(750);

                    firstClicked.ForeColor = firstClicked.BackColor;
                    secondClicked.ForeColor = secondClicked.BackColor;
                    firstClicked = null;
                    secondClicked = null;

                    // bool değeri eski haline getirerek tekrar hamle yapmayı sağlar
                    resetInProgress = false;
                }

                // Kazanma veya kaybetme koşulunu çalıştırır
                CheckForWinner();
                lblScore.Text = GetScore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetErrorMessage() + ex.Message);
            }
        }
        private void CheckForWinner()
        {
            if (moveCount > 0)
            {
                // tblGame içindeki labelların ForeColor ve BackColor'ı aynı mı diye kontrol ederek oyunun bitip bitmediğini anlar
                foreach (Control control in tblGame.Controls)
                {
                    if (control is Label iconLabel)
                    {
                        if (iconLabel.ForeColor == iconLabel.BackColor)
                            return;
                    }
                }
                if (GameDifficulty == "Easy")
                {
                    gameScore *= 2 + moveCount * 2;
                }
                else if (GameDifficulty == "Normal")
                {
                    gameScore *= 4 + moveCount * 4;
                }
                else
                {
                    gameScore *= 10 + moveCount * 10;
                }
                // koşullar sağlanmadığı zaman oyun biter ve formu gizler, böylece ana menüye geri döneriz
                MessageBox.Show(GetCongratulationsMessage(), GetCongratulationsTitle());
                this.Hide();
            }
            else if (moveCount < 1 && gameScore >= 100)
            {
                if (GameDifficulty == "Easy")
                {
                    gameScore *= 1;
                }
                else if (GameDifficulty == "Normal")
                {
                    gameScore *= 2;
                }
                else
                {
                    gameScore *= 5;
                }
                MessageBox.Show(GetCongratulationsMessage(), GetCongratulationsTitle());
                this.Hide();
            }
            else if (moveCount < 1)
            {
                if (GameDifficulty == "Easy")
                {
                    gameScore *= 1;
                }
                else if (GameDifficulty == "Normal")
                {
                    gameScore *= 2;
                }
                else
                {
                    gameScore *= 5;
                }
                MessageBox.Show(GetGameOverMessage(), GetGameOverTitle());
                this.Hide();
            }
        }
        private void GetLanguage()
        {
            if (GameLanguage == "TR")
            {
                this.Text = "Oyun";
                lblMoves.Text = "0 Hamle Kaldı";
            }
            else
            {
                this.Text = "Game";
                lblMoves.Text = "0 Moves Left";
            }
        }
        private string GetScore()
        {
            if (GameLanguage == "TR")
            {
                return "Skor: " + gameScore;
            }
            else
            {
                return "Score: " + gameScore;
            }
        }
        private string GetMoves()
        {
            if (GameLanguage == "TR")
            {
                return moveCount + " Hamle Kaldı";
            }
            else
            {
                return moveCount + " Moves Left";
            }
        }
        private string GetErrorMessage()
        {
            if (GameLanguage == "TR")
            {
                return "Bir hata oluştu: ";
            }
            else
            {
                return "An error occurred: ";
            }
        }
        private string GetGameOverMessage()
        {
            if (GameLanguage == "TR")
            {
                return "Hamleleriniz bitti! Kaybettiniz. Toplam Skor: " + gameScore;
            }
            else
            {
                return "You are out of moves! Game over. Total Score: " + gameScore;
            }
        }

        private string GetGameOverTitle()
        {
            if (GameLanguage == "TR")
            {
                return "Oyun Bitti";
            }
            else
            {
                return "Game Over";
            }
        }
        private string GetCongratulationsMessage()
        {
            if (GameLanguage == "TR")
            {
                return "Tüm simgeleri eşleştirdiniz! Tebrikler! Toplam Skor: " + gameScore;
            }
            else
            {
                return "You matched all the icons! Congratulations! Total Score: " + gameScore;
            }
        }

        private string GetCongratulationsTitle()
        {
            if (GameLanguage == "TR")
            {
                return "Tebrikler";
            }
            else
            {
                return "Congratulations";
            }
        }
    }
}
