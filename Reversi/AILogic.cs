using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class AILogic : GameLogic
    {
        private const int score_high = 5;
        private const int score_medium = 2;
        private const int score_neutral = 1;
        private const int score_low = -2;
        private int[,] scoreField;
        private int[,] currentField;
        protected override bool computer { get { return true; } }
        private const int DEPTH = 3;
        private GameClass game;

        public AILogic(int player, int dimension, int[,] field) : base(player, dimension, field)
        {
            this.buildScoreField();
        }

        public Point getMove(GameClass Game)
        {
            game = Game;
            this.buildCurrentField();
            this.checkPossibilities();
            Point move = this.bestMove();
            return this.bestMove();
        }
        private void buildCurrentField()
        {
            currentField = new int[this.Dimension, this.Dimension];
            for (int x = 0; x < this.Dimension; x++)
            {
                for (int y = 0; y < this.Dimension; y++)
                {
                    currentField[x, y] = 0;
                }

            }
        }
        private int miniMax(GameClass Game, int depth)
        {
            // When DEPTH is reached, or the game is over at this point,
            // we just return a heuristic value
            if (depth == DEPTH || Game.GameOver)
                return getBoardScore(Game.Field, Dimension);

            List<Point> moves = getPossibleMoves(Game);
            if (moves.Count == 0)
            {
                Game.changeCurrent();
                moves = getPossibleMoves(Game);
                depth++;
                if (moves.Count == 0)
                {
                    // The game is over, return a heuristic value
                    return getBoardScore(Game.Field, Dimension);
                }

            }

            if (Game.Current.Player == this.Player)
            {
                // It is our turn, so we should maximize
                int maximum = int.MinValue;

                foreach (Point move in moves)
                {
                    GameClass newGame = new GameClass(Game, false, false);
                    newGame.makeMove(move.X, move.Y);
                    maximum = Math.Max(maximum, miniMax(newGame, depth + 1));
                }

                return maximum;
            }
            else if (Game.Current.Player == this.Opponent)
            {
                // It is the opponents turn, so we should minimize
                int minimum = int.MaxValue;

                foreach (Point move in moves)
                {
                    GameClass newGame = new GameClass(Game, false, false);
                    newGame.makeMove(move.X, move.Y);
                    minimum = Math.Min(minimum, miniMax(newGame, depth + 1));
                }

                return minimum;
            }
            else
            {
                throw new Exception();
            }
        }

        private int getPositionScore(int x, int y)
        {
            // We will use the Minimax algorithm to calculate the
            // value (score) of this move.
            GameClass newGame = new GameClass(game, false, false);
            newGame.makeMove(x, y);
            return miniMax(newGame, 1);
        }
        private List<Point> getPossibleMoves(GameClass Game)
        {
            List<Point> moves = new List<Point>();
            for (int x = 0; x < Dimension; x++)
                for (int y = 0; y < Dimension; y++)
                    if (Game.Current.Possibilities[x, y])
                        moves.Add(new Point(x, y));
            return moves;
        }
        private void checkPossibilities()
        {
            this.updateCurrentPossibilities();
            for (int x = 0; x < this.Dimension; x++)
            {
                for (int y = 0; y < this.Dimension; y++)
                {
                    if (this.Possibilities[x, y]) currentField[x, y] += getPositionScore(x, y);
                }
            }
        }

        private Point bestMove()
        {
            List<Point> moves = new List<Point>();
            Point move = new Point(0, 0);
            int highest = int.MinValue;
            for (int x = 0; x < this.Dimension; x++)
            {
                for (int y = 0; y < this.Dimension; y++)
                {
                    move.X = x; move.Y = y;
                    if (!this.Possibilities[move.X, move.Y]) continue;
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

        private int getBoardScore(int[,] field, int dimension)
        {
            int score = 0;
            for (int x = 0; x < dimension; x++)
                for (int y = 0; y < dimension; y++)
                    if (field[x, y] == Player)
                        score += scoreField[x, y];
                    else if (field[x, y] == Opponent)
                        score -= scoreField[x, y];
            return score;
        }

        private void buildScoreField()
        {
            scoreField = new int[this.Dimension, this.Dimension];
            for (int x = 0; x < this.Dimension; x++)
            {
                for (int y = 0; y < this.Dimension; y++)
                {
                    if (x == 0 | x == this.Dimension - 1) this.scoreField[x, y] = score_medium;
                    else if (y == 0 | y == this.Dimension - 1) this.scoreField[x, y] = score_medium;
                    else this.scoreField[x, y] = score_neutral;

                    if (((x < 2 && y < 2) || (x < 2 && y > this.Dimension - 3)) || ((x > this.Dimension - 3 && y > this.Dimension - 3) || (x > this.Dimension - 3 && y < 2))) this.scoreField[x, y] = score_low;
                    if (((x == 0 && y == 0) || (x == 0 && y == this.Dimension - 1)) || ((x == this.Dimension - 1 && y == this.Dimension - 1) || (x == this.Dimension - 1 && y == 0))) this.scoreField[x, y] = score_high;
                }
            }
        }
    }
}
