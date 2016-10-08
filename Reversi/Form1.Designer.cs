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
            this.Game_panel = new System.Windows.Forms.Panel();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication2.Properties.Resources.lead_214;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.Game_panel);
            this.Name = "Form1";
            this.Text = "Reversi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Game_panel;
    }
}

