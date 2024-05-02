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
    public partial class Game : Form
    {
        public string gameDifficulty { get ; set; }
        public string gameLanguage { get; set; }
        int moveCount = 0;

        public Game()
        {
            InitializeComponent();
            AssignIconsToSquares();      
        }
        private void Game_Load(object sender, EventArgs e)
        {
            SetGameDifficulty();
            GetLanguage();
        }

        private void SetGameDifficulty()
        {
            if (gameDifficulty == "btnEasy")
            {
                moveCount = 60;
            }
            else if (gameDifficulty == "btnNormal")
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

        Random random = new Random();
        //Webding fontuyla kullanacağımız karakter listesi
        List<string> icons = new List<string>()
        {
        "!", "!", "N", "N", "Y", "Y", "k", "k", "n", "n", "b", "b", "v", "v", "w", "w", "z", "z", "R", "R"
        };

        private void AssignIconsToSquares()
        {
            // tblGame içindeki her label için listeden rastgele simge ekler
            foreach (Control control in tblGame.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
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
        private async void label_Click(object sender, EventArgs e)
        {
            try
            {
                Label clickedLabel = sender as Label;

                if (clickedLabel == null)
                    return; // Handle unexpected sender type

                if (clickedLabel.ForeColor == Color.Black || resetInProgress)
                    return; // Önceden tıklanmış simgeye tıklamayı veya reset boolu açıkken tıklamayı önler

                moveCount--;
                lblMoves.Text = moveCount.ToString()+GetMoves();

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Simgeler eşleşmiş mi kontrol eder
                if (firstClicked.Text == secondClicked.Text)
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetErrorMessage() + ex.Message);
            }
        }
    private void CheckForWinner()
        {
            if (moveCount == 0)
            {
                MessageBox.Show(GetGameOverMessage(), GetGameOverTitle());
                this.Hide();
            }
            else
            {
                // tblGame içindeki labelların ForeColor ve BackColor'ı aynı mı diye kontrol ederek oyunun bitip bitmediğini anlar
                foreach (Control control in tblGame.Controls)
                {
                    Label iconLabel = control as Label;

                    if (iconLabel != null)
                    {
                        if (iconLabel.ForeColor == iconLabel.BackColor)
                            return;
                    }
                }

                // koşullar sağlanmadığı zaman oyun biter ve formu gizler, böylece ana menüye geri döneriz
                MessageBox.Show(GetCongratulationsMessage(), GetCongratulationsTitle());
                this.Hide();
            }
        }
        private void GetLanguage()
        {
            if (gameLanguage == "TR")
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
        private string GetMoves()
        {
            if (gameLanguage == "TR")
            {
                return " Hamle Kaldı";
            }
            else
            {
                return " Moves Left";
            }
        }
        private string GetErrorMessage()
        {
            if (gameLanguage == "TR")
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
            if (gameLanguage == "TR")
            {
                return "Hamleleriniz bitti! Kaybettiniz.";
            }
            else
            {
                return "You are out of moves! Game over.";
            }
        }

        private string GetGameOverTitle()
        {
            if (gameLanguage == "TR")
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
            if (gameLanguage == "TR")
            {
                return "Tüm simgeleri eşleştirdiniz! Tebrikler";
            }
            else
            {
                return "You matched all the icons! Congratulations";
            }
        }

        private string GetCongratulationsTitle()
        {
            if (gameLanguage == "TR")
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
