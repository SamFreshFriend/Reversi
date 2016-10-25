using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Reversi
{
    /// <summary>
    /// The GameClass represents an entire game of Reversi with all its state, like the two players, 
    /// the current field and the GameOver state.
    /// It is responsible for reacting on mouseEvent calls to make moves, using the GameLogics to
    /// transform the game, and letting the AI move when appropriate.
    /// </summary>
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

        /// <summary>
        /// Signifies whether two computers are playing against eachother (true means two AIs are playing).
        /// </summary>
        public bool ComputerVcomputerMode
        {
            set { this.computerVcomputerMode = value; }
            get { return this.computerVcomputerMode; }
        }

        /// <summary>
        /// The current playing field. An int value of this.blue at a location signifies a blue stone and this.red signifies a red stone.
        /// </summary>
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

        /// <summary>
        /// The GameLogic who's turn it is next.
        /// </summary>
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

        /// <summary>
        /// Whether the game is over at this point. Who won can be calculated by comparing getRedScore and getBlueScore.
        /// </summary>
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
            previousCouldMove = lastCanMove = true;
            computerVcomputerMode = bluePlayer == computer && redPlayer == computer;
        }

        /// <summary>
        /// An alternate constructor, which is used by the AILogic, to copy a current game state into a new GameClass object.
        /// </summary>
        /// <param name="Game"></param>
        /// <param name="bluePlayer"></param>
        /// <param name="redPlayer"></param>
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
            computerVcomputerMode = bluePlayer == computer && redPlayer == computer;
        }

        /// <summary>
        /// Swaps the current, so the next player can do their turn next.
        /// </summary>
        public void changeCurrent()
        {
            current = (current == logicBlue) ? logicRed : logicBlue;
        }

        /// <summary>
        /// Let's the AI play. If a computer is playing against a human, the AI will move repeatedly
        /// </summary>
        public void computerMove()
        {
            while (current.whoAmI == computer && !GameOver)
            {
                if (GameOver) return;
                Point move = ((AILogic)current).getMove(this);
                this.makeMove(move.X, move.Y);
                if (ComputerVcomputerMode) break;
            }
        }

        /// <summary>
        /// Called when the user clicks on the board, with the relative panel coordinates p.
        /// </summary>
        /// <param name="p"></param>
        public void mouseEvent(Point p)
        {
            if (current.whoAmI == computer) return;

            int x = p.X * this.dimension / this.Screen.Width;
            int y = p.Y * this.dimension / this.Screen.Height;
            if (this.current.checkMove(x, y)) makeMove(x, y);
            if (current.whoAmI == computer && !GameOver)
            {
                this.updateForm();
                computerMove();
            }

        }
        private void updateForm()
        {
            this.Form.checkLabels();
            this.Form.Refresh();
        }

        /// <summary>
        /// Actually makes a move using the current GameLogic and the field. Also handles things that should be done after
        /// every move, like switching teams and updating the GameOver state.
        /// </summary>
        public void makeMove(int x, int y)
        {
            if (GameOver) return;
            current.makeMove(x, y);
            this.changeCurrent();
            current.Field = field;
            current.updateCurrentPossibilities();
            updateGameOver();
        }

        /// <summary>
        /// Updates the GameOver state held in the member previousCouldMove and lastCanMove
        /// </summary>
        private void updateGameOver()
        {
            // Once the game is over, it can't stop being over
            if (GameOver) return;

            previousCouldMove = lastCanMove;
            lastCanMove = current.canPlayerMove();

            // If the new player can't move, the teams should be switched again and
            // the values updated again.
            if (!lastCanMove)
            {
                this.changeCurrent();
                previousCouldMove = lastCanMove;
                current.updateCurrentPossibilities();
                lastCanMove = current.canPlayerMove();
            }
        }

        /// <summary>
        /// Builds the initial field
        /// </summary>
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
