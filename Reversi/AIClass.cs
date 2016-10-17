using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class AIClass
    {
        private const int score_high = 5;
        private const int score_medium = 2;
        private const int score_neutral = 1;
        private const int score_low = -2;
        protected GameLogic logic;
        protected int dimension;
        private int[,] scoreField;
        private int[,] currentField;

        public AIClass(int dimension, int[,] field)
        {
            this.dimension = dimension;
            logic = new GameLogic(2, this.dimension, field);
            //this.logic.changeCurrent();
            this.buildScoreField();

        }
        public Point makeMove()
        {
            this.buildCurrentField();
            this.checkPossibilities();
            Point move = this.bestMove();
            return this.bestMove();
        }
        private void buildCurrentField()
        {
            currentField = new int[this.dimension, this.dimension];
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    currentField[x, y] = 0;
                }

            }
        }
        protected int checkPosition(int x, int y)
        {
            return scoreField[x, y];
        }

        // This function is overwritten by children of this class
        // to change how they score move. For this basic AI, it
        // just returns the value in the scoreField.
        protected virtual int getPositionScore(int x, int y)
        {
            return checkPosition(x, y);
        }

        private void checkPossibilities()
        {
            this.logic.updateCurrentPossibilities();
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    if (this.logic.Possibilities[x, y]) currentField[x, y] += getPositionScore(x, y);

                }
            }
        }
        private Point bestMove()
        {
            List<Point> moves = new List<Point>();
            Point move = new Point(0, 0);
            int highest = int.MinValue;
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    move.X = x; move.Y = y;
                    if (!this.logic.Possibilities[move.X, move.Y]) continue;
                    if (currentField[move.X, move.Y] == highest) moves.Add(move);
                    else if (currentField[move.X, move.Y] > highest)
                    {
                        moves.Clear();
                        moves.Add(move);
                        highest = currentField[move.X, move.Y];
                    }
                }
            }
            if (moves.Count > 1) return moves[new Random().Next(moves.Count - 1)];
            else return moves[0];
        }
        private void printField()
        {
            for (int x = 0; x < this.dimension; x++)
            {
                string s = "";
                for (int y = 0; y < this.dimension; y++)
                {
                    s += this.scoreField[x, y].ToString() + "    ";
                }
                Console.WriteLine(s);
            }
        }

        private void buildScoreField()
        {
            scoreField = new int[this.dimension, this.dimension];
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    if (x == 0 | x == this.dimension - 1) this.scoreField[x, y] = score_medium;
                    else if (y == 0 | y == this.dimension - 1) this.scoreField[x, y] = score_medium;
                    else this.scoreField[x, y] = score_neutral;

                    if (((x < 2 && y < 2) || (x < 2 && y > this.dimension - 3)) || ((x > this.dimension - 3 && y > this.dimension - 3) || (x > this.dimension - 3 && y < 2))) this.scoreField[x, y] = score_low;
                    if (((x == 0 && y == 0) || (x == 0 && y == this.dimension - 1)) || ((x == this.dimension - 1 && y == this.dimension - 1) || (x == this.dimension - 1 && y == 0))) this.scoreField[x, y] = score_high;
                }
            }
            printField();
        }
    }
}
