using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Reversi
{
    class GameClass
    {
        Size screen;
        GameDrawer drawer;
        int dimension;
        AIClass Simulation;
        bool vsComputerMode;
        int computer;
        public GameLogic Logic {
            get { return this.drawer.Logic; }
        }
        public int Blue {
            get { return this.Logic.Blue; }
        }
        public int Red {
            get { return this.Logic.Red; }
        }
        public int Current {
                get { return this.Logic.Current; }
        }
        public Size Screen
        {
            set { this.screen = value; }
        }

        public void drawHandler(Graphics g) {
            this.drawer.drawScreen(g);
        }
        private void computerMove() {
            if (Current != computer) return;
            Simulation = new AIClass(this.dimension, this.Logic.Field);
            Point move = Simulation.makeMove();
            this.Logic.makeMove(move.X, move.Y);

        }

        public void mouseEvent(Point p) {
            int x = p.X * this.dimension / this.screen.Width;
            int y = p.Y * this.dimension / this.screen.Height;
            this.Logic.makeMove(x, y);
            if(vsComputerMode)this.computerMove();

        }
        public GameClass(Size sz)
        {
            this.dimension = 6;
            this.screen = sz;
            // this.logic = new GameLogic(dimension);
            this.drawer = new GameDrawer(new GameLogic(dimension), this.screen);
            this.vsComputerMode = false;
            if (vsComputerMode) computer = Red;
        }

        public void newGame(int index)
        {
            switch (index)
            {
                case -1:  dimension = 6; break;
                case 0: dimension = 6; break;
                case 1: dimension = 8; break;
                case 2: dimension = 10; break;
                case 3: dimension = 12; break;
                case 4: dimension = 14; break;
                case 5: dimension = 16; break;


            }
            //this.logic = new GameLogic(dimension);
            this.drawer = new GameDrawer(new GameLogic(dimension), screen);
        }
    }
}
