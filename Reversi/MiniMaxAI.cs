using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Reversi
{
    class MiniMaxAI : AILogic
    {
        private const int DEPTH = 3;
        private GameClass game;

        public MiniMaxAI(int player, int dimension, int[,] field) : base(player, dimension, field)
        {
            game.Current.Possibilities

        }
        public override Point getMove(GameClass Game) {

            return this.BestMove;
        };

        protected override int getPositionScore(int x, int y)
        {
            // We will use the Minimax algorithm to calculate the
            // value (score) of this move.
            GameLogic newLogic = new GameLogic(this.logic);
            newLogic.makeMove(x, y);
            return miniMax(newLogic, 1);
        }

        private int miniMax(GameLogic logic, int depth)
        {
            // When DEPTH is reached, or the game is over at this point,
            // we just return a heuristic value
            if (depth == DEPTH)
                return getBoardScore(logic.Field, logic.Dimension);

            List<Point> moves = getPossibleMoves(logic);
            if (moves.Count == 0)
            {
                logic.changeCurrent();
                moves = getPossibleMoves(logic);
                depth++;
                if (moves.Count == 0)
                {
                    // The game is over, return a heuristic value
                    return getBoardScore(logic.Field, logic.Dimension);
                }
            }

            if (logic.Current == Player)
            {
                // It is our turn, so we should maximize
                int maximum = int.MinValue;

                foreach (Point move in moves)
                {
                    GameLogic newLogic = new GameLogic(logic);
                    newLogic.makeMove(move.X, move.Y);
                    maximum = Math.Max(maximum, miniMax(newLogic, depth + 1));
                }

                return maximum;
            }
            else
            {
                // It is the opponents turn, so we should minimize
                int minimum = int.MaxValue;

                foreach (Point move in moves)
                {
                    GameLogic newLogic = new GameLogic(logic);
                    newLogic.makeMove(move.X, move.Y);
                    minimum = Math.Min(minimum, miniMax(newLogic, depth + 1));
                }

                return minimum;
            }
        }

        private List<Point> getPossibleMoves(GameLogic logic)
        {
            List<Point> moves = new List<Point>();
            for (int x = 0; x < Dimension; x++)
                for (int y = 0; y < Dimension; y++)
                    if (logic.Possibilities[x, y])
                        moves.Add(new Point(x, y));
            return moves;
        }

        // Used as the heuristic function to give a score to an
        // arbitrary non-finished board.
        private int getBoardScore(int[,] field, int dimension)
        {
            int score = 0;
            for (int x = 0; x < dimension; x++)
                for (int y = 0; y < dimension; y++)
                    if (field[x, y] == Player)
                        score += checkPosition(x, y);
                    else if (field[x, y] == Opponent)
                        score -= checkPosition(x, y);
            return score;
        }
    }
}
