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
        GameDrawer drawer;
        private GameLogic logicRed;
        private GameLogic logicBlue;
        private GameLogic current;
        int dimension;
        private const int blue = 1;
        private const int red = 2;
        private int[,] field;
        private bool computer = true;

        AIClass Simulation;
        bool vsComputerMode;
        private bool previousCouldMove, lastCanMove;
        Stack<int[,]> movesMade;

        //public Stack<int[,]> MovesMade {
        //    get { return this.movesMade;  }
        //}

        public int[,] Field
        {
            get { return field; }
        }
        public GameLogic LogicRed
        {
            set { this.logicRed = value; }
        }
        public GameLogic LogicBlue
        {
            set { this.logicBlue = value; }
        }
        public int getBlueScore
        {
            get
            {
                int score = 0;
                foreach (int i in field)
                {
                    if (i == blue) score++;
                }
                return score;

            }
        }
        public int getRedScore
        {
            get
            {
                int score = 0;
                foreach (int i in field)
                {
                    if (i == red) score++;
                }
                return score;

            }
        }
        public GameLogic Current
        {
            get { return this.current; }
        }
        public Size Screen
        {
            get { return this.drawer.Screen; }
            set { this.drawer.Screen = value; }
        }

        public void drawHandler(Graphics g)
        {
            this.drawer.drawScreen(g, current);
        }


        public bool GameOver
        {
            get
            {
                return !previousCouldMove && !lastCanMove;
            }
        }

        public GameClass(Size sz, bool bluePlayer = false, bool redPlayer = true)
        {
            this.dimension = 6;
            this.buildField();
            this.logicBlue = (bluePlayer == computer) ? new AILogic(blue, dimension, field) : new GameLogic(blue, dimension, field);
            this.logicRed = (redPlayer == computer) ? new AILogic(red, dimension, field) : new GameLogic(red, dimension, field);
            this.current = logicBlue;
            current.Field = field;
            current.updateCurrentPossibilities();
            this.drawer = new GameDrawer(sz);
            this.Screen = sz;
            // this.movesMade = new Stack<int[,]>();
            previousCouldMove = lastCanMove = true;

        }
        public GameClass(GameClass Game, bool bluePlayer = false, bool redPlayer = true)
        {
            this.dimension = Game.dimension;
            this.field = (int[,])Game.field.Clone();
            this.logicBlue = (bluePlayer == computer) ? new AILogic(blue, dimension, field) : new GameLogic(blue, dimension, field);
            this.logicRed = (redPlayer == computer) ? new AILogic(blue, dimension, field) : new GameLogic(blue, dimension, field);
            this.current = (Game.current.Player == blue) ? (GameLogic)this.logicBlue: (GameLogic)this.logicRed;
            current.Field = field;
            current.Possibilities = (bool[,])Game.current.Possibilities.Clone();
            this.previousCouldMove = Game.previousCouldMove;
            this.lastCanMove = Game.lastCanMove;
        }

        public void changeCurrent()
        {
            current = (current == logicBlue) ? logicRed: logicBlue;
        }

        public void computerMove()
        {
            if (GameOver) return;
            Point move = ((AILogic) current).getMove(this);
            if (this.current.checkMove(move.X, move.Y)) this.makeMove(move.X, move.Y);
        }

        public void mouseEvent(Point p)
        {
            int x = p.X * this.dimension / this.Screen.Width;
            int y = p.Y * this.dimension / this.Screen.Height;
            //this.movesMade.Push(this.Logic.Field);
            if (this.current.checkMove(x, y)) makeMove(x, y);

        }
        public void makeMove(int x, int y)
        {
            field = current.makeMove(x, y);
            updateGameOver();
            this.changeCurrent();
            current.Field = field;
            current.updateCurrentPossibilities();
            if (current.whoAmI == computer)
            {
                computerMove();
            }
        }

        //public void popMove() {
        //    try
        //    {
        //        Console.WriteLine();
        //        this.movesMade.Pop();
        //        this.Logic.Field = this.movesMade.First();
        //        this.Logic.changeCurrent();
        //    }
        //    catch { }
        //}

        private void updateGameOver()
        {
            previousCouldMove = lastCanMove;
            lastCanMove = current.canPlayerMove();
            if (!lastCanMove)
            {
                this.changeCurrent();
                previousCouldMove = lastCanMove;
                current.updateCurrentPossibilities();
                lastCanMove = current.canPlayerMove();
            }
        }



        public void newGame(int index)
        {
            switch (index)
            {
                case -1: dimension = 6; break;
                case 0: dimension = 6; break;
                case 1: dimension = 8; break;
                case 2: dimension = 10; break;
                case 3: dimension = 12; break;
                case 4: dimension = 14; break;
                case 5: dimension = 16; break;


            }
            //this.logic = new GameLogic(dimension);
            this.buildField();
            this.logicBlue = new GameLogic(blue, dimension, field);
            this.logicRed = new GameLogic(red, dimension, field);
            this.current = logicBlue;
            this.drawer = new GameDrawer(Screen);
            this.movesMade = new Stack<int[,]>();
        }

        private void buildField()
        {
            this.field = new int[this.dimension, this.dimension];
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    this.field[x, y] = 0;
                }
            }
            this.field[this.dimension / 2 - 1, this.dimension / 2 - 1] = blue;
            this.field[this.dimension / 2 - 1, this.dimension / 2] = red;
            this.field[this.dimension / 2, this.dimension / 2 - 1] = red;
            this.field[this.dimension / 2, this.dimension / 2] = blue;
        }
    }
}
