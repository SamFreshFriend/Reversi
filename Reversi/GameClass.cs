using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Reversi
{
    class GameClass
    {
        GameDrawer drawer;
        //bool bluePLayer;
        //bool redPlayer;
        private GameLogic logicRed;
        private GameLogic logicBlue;
        private GameLogic current;
        private Form1 Form;
        int dimension;
        private const int blue = 1;
        private const int red = 2;
        private int[,] field;
        private bool computer = true;
        private bool previousCouldMove, lastCanMove;
        private bool computerVcomputerMode;
        //Stack<int[,]> movesMade;

        //public Stack<int[,]> MovesMade {
        //    get { return this.movesMade;  }
        //}

        public bool ComputerVcomputerMode
        {
            set { this.computerVcomputerMode = value; }
        }
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
                return (!previousCouldMove && !lastCanMove);
            }
        }

        public GameClass(Form1 f, Size sz, int index, bool bluePlayer, bool redPlayer)
        {
            this.Form = f;
            this.dimension = index;
            this.buildField();
            this.logicBlue = (bluePlayer == computer) ? new AILogic(blue, dimension, field) : new GameLogic(blue, dimension, field);
            this.logicRed = (redPlayer == computer) ? new AILogic(red, dimension, field) : new GameLogic(red, dimension, field);
            this.current = (bluePlayer == redPlayer) ? ((new Random().Next(2) == 1) ? logicBlue : logicRed) : (bluePlayer == computer) ? logicRed : logicBlue;
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
            this.logicRed = (redPlayer == computer) ? new AILogic(red, dimension, field) : new GameLogic(red, dimension, field);
            this.current = (Game.Current.Player == blue) ? (GameLogic)this.logicBlue : (GameLogic)this.logicRed;
            current.Field = field;
            current.Possibilities = (bool[,])Game.current.Possibilities.Clone();
            this.previousCouldMove = Game.previousCouldMove;
            this.lastCanMove = Game.lastCanMove;
        }

        public void changeCurrent()
        {
            current = (current == logicBlue) ? logicRed : logicBlue;
        }

        public void computerMove()
        {
            while (current.whoAmI == computer && !GameOver)
            {
                if (GameOver) return;
                try
                {
                    Point move = ((AILogic)current).getMove(this);
                    this.makeMove(move.X, move.Y);
                }
                catch
                {
                    changeCurrent();
                    updateGameOver();
                }
                //updateGameOver();
            }
        }

        public void mouseEvent(Point p)
        {
            int x = p.X * this.dimension / this.Screen.Width;
            int y = p.Y * this.dimension / this.Screen.Height;
            //this.movesMade.Push(this.Logic.Field);
            if (this.current.checkMove(x, y)) makeMove(x, y);
            if (current.whoAmI == computer && !GameOver)
            {
                if (!computerVcomputerMode) this.updateForm();
                computerMove();
            }

        }
        private void updateForm()
        {
            this.Form.checkLabels();
            this.Form.Refresh();
        }
        public void makeMove(int x, int y)
        {
            if (GameOver) return;
            current.makeMove(x, y);
            this.changeCurrent();
            current.Field = field;
            current.updateCurrentPossibilities();
            updateGameOver();
            //if (current.whoAmI == computer && !GameOver)
            //{
            //    if(!computerVcomputerMode) this.updateForm();
            //    computerMove();

            //}
        }

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
