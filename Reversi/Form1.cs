using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Form1 : Form
    {
        GameClass Game;
        GameLogic logic;
        GameDrawer drawer;
        public Form1()
        {
            InitializeComponent();
            this.Game = new GameClass(this.Game_panel.Size);
            this.logic = new GameLogic(6);
            this.drawer = new GameDrawer(logic, this.Game_panel.Size);
        }

        private void Game_panel_Paint(object sender, PaintEventArgs e)
        {
            //Control c = (Control)sender;//
            Game.drawHandler(e.Graphics);
            //drawer.drawScreen(e.Graphics);//
            this.Invalidate();

        }

        private void Game_panel_MouseClick(object sender, MouseEventArgs e)
        {
            Game.mouseEvent(e.Location);
            //drawer.translateMove(e.Location);//
            switch (this.Game.Current) {
                case -1: break;
                case 1: {
                        this.TurnLabel.Text = "BLUE";
                        this.TurnLabel.ForeColor = Color.Blue;
                        break;
                    }
                case 2: {
                        this.TurnLabel.Text = "RED";
                        this.TurnLabel.ForeColor = Color.Red;
                        break;
                    }
            }
            this.Score_Blue.Text = this.Game.Logic.getBlueScore.ToString();
            this.Score_Red.Text = this.Game.Logic.getRedScore.ToString();
            //this.TurnLabel.Text = (this.drawer.Logic.Current == this.drawer.Logic.Blue) ? "BLUE" : "RED";//
            //this.TurnLabel.ForeColor = (this.drawer.Logic.Current == this.drawer.Logic.Blue) ? Color.Blue : Color.Red;//
            //this.Score_Blue.Text = this.drawer.Logic.getBlueScore.ToString();//
            //this.Score_Red.Text = this.drawer.Logic.getRedScore.ToString();//
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Game.newGame(this.combo_GameMode.SelectedIndex);
            //switch (this.combo_GameMode.SelectedIndex) {///

            //    case -1: this.logic = new GameLogic(6); ; break;
            //    case 0: this.logic = new GameLogic(6); break;
            //    case 1: this.logic = new GameLogic(8); break;
            //    case 2: this.logic = new GameLogic(10); break;
            //    case 3: this.logic = new GameLogic(12); break;
            //    case 4: this.logic = new GameLogic(14); break;
            //    case 5: this.logic = new GameLogic(16); break;


            //}///
            //this.drawer = new GameDrawer(this.logic, this.Game_panel.Size);//
            this.TurnLabel.Text = "BLUE";
            this.Score_Blue.Text = "2";
            this.Score_Red.Text = "2";
            this.Refresh();

        }
    }
}
