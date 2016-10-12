using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        GameLogic logic;
        GameDrawer drawer;
        public Form1()
        {
            
            InitializeComponent();
            this.logic = new GameLogic();
            this.drawer = new GameDrawer(logic, this.Game_panel.Size);
        }

        private void Game_panel_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            drawer.drawScreen(e.Graphics);
            this.Invalidate();

        }

        private void Game_panel_MouseClick(object sender, MouseEventArgs e)
        {
            drawer.translateMove(e.Location);
            this.Refresh();
        }
    }
}
