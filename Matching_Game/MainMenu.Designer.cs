namespace Matching_Game
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.rdbTR = new System.Windows.Forms.RadioButton();
            this.rdbEN = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnEasy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEasy.Location = new System.Drawing.Point(46, 12);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(100, 100);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "\r\n\r\nEasy\r\n\r\n60 Moves";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Location = new System.Drawing.Point(46, 130);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(100, 100);
            this.btnNormal.TabIndex = 1;
            this.btnNormal.Text = "\r\n\r\nNormal\r\n\r\n50 Moves";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnHard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHard.Location = new System.Drawing.Point(46, 249);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(100, 100);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "\r\n\r\nHard\r\n\r\n40 Moves";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.BtnClick);
            // 
            // rdbTR
            // 
            this.rdbTR.AutoSize = true;
            this.rdbTR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbTR.Location = new System.Drawing.Point(0, 332);
            this.rdbTR.Name = "rdbTR";
            this.rdbTR.Size = new System.Drawing.Size(40, 17);
            this.rdbTR.TabIndex = 3;
            this.rdbTR.TabStop = true;
            this.rdbTR.Text = "TR";
            this.rdbTR.UseVisualStyleBackColor = true;
            this.rdbTR.CheckedChanged += new System.EventHandler(this.Rdb_CheckedChanged);
            // 
            // rdbEN
            // 
            this.rdbEN.AutoSize = true;
            this.rdbEN.Checked = true;
            this.rdbEN.Location = new System.Drawing.Point(152, 332);
            this.rdbEN.Name = "rdbEN";
            this.rdbEN.Size = new System.Drawing.Size(40, 17);
            this.rdbEN.TabIndex = 4;
            this.rdbEN.TabStop = true;
            this.rdbEN.Text = "EN";
            this.rdbEN.UseVisualStyleBackColor = true;
            this.rdbEN.CheckedChanged += new System.EventHandler(this.Rdb_CheckedChanged);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 361);
            this.Controls.Add(this.rdbEN);
            this.Controls.Add(this.rdbTR);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnEasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.RadioButton rdbTR;
        private System.Windows.Forms.RadioButton rdbEN;
    }
}

