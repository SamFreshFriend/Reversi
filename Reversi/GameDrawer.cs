using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class GameDrawer
    {
        private int dimension;
        private Size screen;
        private GameLogic logic;
        public Size Screen {
            set { this.screen = value; }
        }
        //public GameLogic Logic {
        //    get { return this.logic; }
        //}
        public GameDrawer(GameLogic g, Size s)
        {
            this.logic = g;
            this.Screen = s;
            this.dimension = logic.Dimensions;


        }
        public void drawCircles(Graphics gr, int cubeSize)
        {
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    if (this.logic.Field[x, y] == 1) gr.FillEllipse(Brushes.Blue, x * cubeSize, y * cubeSize, cubeSize, cubeSize);
                    else if (this.logic.Field[x, y] == 2) gr.FillEllipse(Brushes.Red, x * cubeSize, y * cubeSize, cubeSize, cubeSize);
                }
            }
        }
        public void translateMove(Point p) {
            int x = p.X * this.dimension / this.screen.Width;
            int y = p.Y * this.dimension / this.screen.Height;
            this.logic.makeMove(x,y);

        }


        public void drawScreen(Graphics gr)
        {
            int CubeSize = this.screen.Width / this.dimension;
            for (int i = 1; i < this.dimension; i++)
            {
                int x = CubeSize * i;
                int y = CubeSize * i;
                gr.DrawLine(Pens.Black, 0, y, this.screen.Width, y);
                gr.DrawLine(Pens.Black, x, 0, x, this.screen.Height);
                this.drawCircles(gr, CubeSize);
                //for (int y = 1; y < this.logic.Dimensions; y++)
                //{
                //    gr.DrawLine()

                //}
            }
        }
    }
}
