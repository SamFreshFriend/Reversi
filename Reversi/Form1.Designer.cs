namespace WindowsFormsApplication2
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
            this.button1 = new System.Windows.Forms.Button();
            this.combo_GameMode = new System.Windows.Forms.ComboBox();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.Score_Blue = new System.Windows.Forms.Label();
            this.Score_Red = new System.Windows.Forms.Label();
            this.Colon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Game_panel
            // 
            this.Game_panel.Location = new System.Drawing.Point(100, 80);
            this.Game_panel.Name = "Game_panel";
            this.Game_panel.Size = new System.Drawing.Size(550, 550);
            this.Game_panel.TabIndex = 0;
            this.Game_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_panel_Paint);
            this.Game_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_panel_MouseClick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WindowsFormsApplication2.Properties.Resources.window_vista_start_button_4900;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(264, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 43);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combo_GameMode
            // 
            this.combo_GameMode.FormattingEnabled = true;
            this.combo_GameMode.Items.AddRange(new object[] {
            "6 by 6",
            "8 by 8",
            "10 by 10",
            "12 by 12",
            "14 by 14",
            "16 by 16"});
            this.combo_GameMode.Location = new System.Drawing.Point(100, 24);
            this.combo_GameMode.Name = "combo_GameMode";
            this.combo_GameMode.Size = new System.Drawing.Size(121, 21);
            this.combo_GameMode.TabIndex = 3;
            this.combo_GameMode.Text = "6 by 6";
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.BackColor = System.Drawing.Color.Transparent;
            this.TurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLabel.ForeColor = System.Drawing.Color.Blue;
            this.TurnLabel.Location = new System.Drawing.Point(405, 27);
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
            this.Score_Blue.Location = new System.Drawing.Point(526, 27);
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
            this.Score_Red.Location = new System.Drawing.Point(580, 27);
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
            this.Colon.Location = new System.Drawing.Point(562, 31);
            this.Colon.Name = "Colon";
            this.Colon.Size = new System.Drawing.Size(16, 24);
            this.Colon.TabIndex = 7;
            this.Colon.Text = ":";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.Colon);
            this.Controls.Add(this.Score_Red);
            this.Controls.Add(this.Score_Blue);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.combo_GameMode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Game_panel);
            this.Name = "Form1";
            this.Text = "Reversi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Game_panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combo_GameMode;
        private System.Windows.Forms.Label TurnLabel;
        private System.Windows.Forms.Label Score_Blue;
        private System.Windows.Forms.Label Score_Red;
        private System.Windows.Forms.Label Colon;
    }
}

