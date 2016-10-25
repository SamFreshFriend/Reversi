namespace Reversi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Game_panel = new System.Windows.Forms.Panel();
            this.L_GameOver = new System.Windows.Forms.Label();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.Score_Blue = new System.Windows.Forms.Label();
            this.Score_Red = new System.Windows.Forms.Label();
            this.Colon = new System.Windows.Forms.Label();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.labelR = new System.Windows.Forms.Label();
            this.checkBoxR = new System.Windows.Forms.CheckBox();
            this.labelB = new System.Windows.Forms.Label();
            this.checkBoxB = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.combo_GameMode = new System.Windows.Forms.ComboBox();
            this.Game_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Game_panel
            // 
            this.Game_panel.BackColor = System.Drawing.Color.Black;
            this.Game_panel.BackgroundImage = global::Reversi.Properties.Resources.blackLeather;
            this.Game_panel.Controls.Add(this.L_GameOver);
            this.Game_panel.Location = new System.Drawing.Point(100, 80);
            this.Game_panel.Name = "Game_panel";
            this.Game_panel.Size = new System.Drawing.Size(550, 550);
            this.Game_panel.TabIndex = 0;
            this.Game_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_panel_Paint);
            this.Game_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_panel_MouseClick);
            // 
            // L_GameOver
            // 
            this.L_GameOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.L_GameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_GameOver.ForeColor = System.Drawing.Color.Black;
            this.L_GameOver.Location = new System.Drawing.Point(-1500, -1625);
            this.L_GameOver.Name = "L_GameOver";
            this.L_GameOver.Size = new System.Drawing.Size(150, 81);
            this.L_GameOver.TabIndex = 8;
            this.L_GameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.BackColor = System.Drawing.Color.Transparent;
            this.TurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLabel.ForeColor = System.Drawing.Color.Blue;
            this.TurnLabel.Location = new System.Drawing.Point(370, 24);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(89, 31);
            this.TurnLabel.TabIndex = 4;
            this.TurnLabel.Text = "BLUE";
            // 
            // Score_Blue
            // 
            this.Score_Blue.AutoSize = true;
            this.Score_Blue.BackColor = System.Drawing.Color.Transparent;
            this.Score_Blue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_Blue.ForeColor = System.Drawing.Color.Blue;
            this.Score_Blue.Location = new System.Drawing.Point(491, 24);
            this.Score_Blue.Name = "Score_Blue";
            this.Score_Blue.Size = new System.Drawing.Size(30, 31);
            this.Score_Blue.TabIndex = 5;
            this.Score_Blue.Text = "2";
            // 
            // Score_Red
            // 
            this.Score_Red.AutoSize = true;
            this.Score_Red.BackColor = System.Drawing.Color.Transparent;
            this.Score_Red.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_Red.ForeColor = System.Drawing.Color.Red;
            this.Score_Red.Location = new System.Drawing.Point(545, 24);
            this.Score_Red.Name = "Score_Red";
            this.Score_Red.Size = new System.Drawing.Size(30, 31);
            this.Score_Red.TabIndex = 6;
            this.Score_Red.Text = "2";
            // 
            // Colon
            // 
            this.Colon.AutoSize = true;
            this.Colon.BackColor = System.Drawing.Color.Transparent;
            this.Colon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colon.ForeColor = System.Drawing.Color.Blue;
            this.Colon.Location = new System.Drawing.Point(527, 28);
            this.Colon.Name = "Colon";
            this.Colon.Size = new System.Drawing.Size(16, 24);
            this.Colon.TabIndex = 7;
            this.Colon.Text = ":";
            //
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(260, 34);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(75, 23);
            this.StartStopButton.TabIndex = 29;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            this.StartStopButton.Visible = false;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.BackColor = System.Drawing.Color.Transparent;
            this.labelR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR.ForeColor = System.Drawing.Color.Red;
            this.labelR.Location = new System.Drawing.Point(31, 47);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(34, 31);
            this.labelR.TabIndex = 25;
            this.labelR.Text = "R";
            // 
            // checkBoxR
            // 
            this.checkBoxR.AutoSize = true;
            this.checkBoxR.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxR.Checked = true;
            this.checkBoxR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxR.Location = new System.Drawing.Point(72, 55);
            this.checkBoxR.Name = "checkBoxR";
            this.checkBoxR.Size = new System.Drawing.Size(18, 17);
            this.checkBoxR.TabIndex = 28;
            this.checkBoxR.UseVisualStyleBackColor = false;
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.BackColor = System.Drawing.Color.Transparent;
            this.labelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB.ForeColor = System.Drawing.Color.Blue;
            this.labelB.Location = new System.Drawing.Point(32, 18);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(32, 31);
            this.labelB.TabIndex = 26;
            this.labelB.Text = "B";
            // 
            // checkBoxB
            // 
            this.checkBoxB.AutoSize = true;
            this.checkBoxB.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxB.Location = new System.Drawing.Point(72, 27);
            this.checkBoxB.Name = "checkBoxB";
            this.checkBoxB.Size = new System.Drawing.Size(18, 17);
            this.checkBoxB.TabIndex = 27;
            this.checkBoxB.UseVisualStyleBackColor = false;
            //
            //button1
            //
            this.startButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.Location = new System.Drawing.Point(200, 21);
            this.startButton.Name = "button1";
            this.startButton.Size = new System.Drawing.Size(45, 45);
            this.startButton.TabIndex = 23;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_Click);

            //
            //combo_GameMode
            //
            this.combo_GameMode.FormattingEnabled = true;
            this.combo_GameMode.Items.AddRange(new object[] {
            "6 by 6",
            "8 by 8",
            "10 by 10",
            "12 by 12",
            "14 by 14",
            "16 by 16"});
            this.combo_GameMode.Location = new System.Drawing.Point(98, 36);
            this.combo_GameMode.Name = "combo_GameMode";
            this.combo_GameMode.Size = new System.Drawing.Size(80, 24);
            this.combo_GameMode.TabIndex = 24;
            this.combo_GameMode.Text = "6 by 6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.checkBoxR);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.checkBoxB);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.combo_GameMode);
            this.Controls.Add(this.Colon);
            this.Controls.Add(this.Score_Red);
            this.Controls.Add(this.Score_Blue);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.Game_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Reversi";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Game_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Game_panel;
        private System.Windows.Forms.Label TurnLabel;
        private System.Windows.Forms.Label Score_Blue;
        private System.Windows.Forms.Label Score_Red;
        private System.Windows.Forms.Label Colon;
        private System.Windows.Forms.Label L_GameOver;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.CheckBox checkBoxR;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.CheckBox checkBoxB;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox combo_GameMode;
    }
}

