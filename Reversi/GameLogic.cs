﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Reversi
{
    /// <summary>
    /// A GameLogic is a player used in the GameClass to manage the logic of the game.
    /// A plain GameLogic will not think of moves itself, but will instead rely on an
    /// outside source of moves, like a human that clicks on the screen. Subclasses of
    /// GameLogic, like AILogic, may provide moves themselves.
    /// </summary>
    class GameLogic
    {
        private int dimension;
        private int player;
        private int opponent;
        public const int blue = 1;
        public const int red = 2;
        private int[,] field;
        private int x;
        private int y;
        private List<Vector> directions;
        private bool[,] currentPossibilities;
        protected virtual bool computer
        {
            get { return false; }
        }
        /// <summary>
        /// Returns whether this GameLogic is an AI
        /// </summary>
        public bool whoAmI
        {
            get { return computer; }
        }

        /// <summary>
        /// All the possible moves that this GameLogic can make
        /// </summary>
        public bool[,] Possibilities
        {
            set {
                currentPossibilities = value;
            }
            get
            {
                return currentPossibilities;
            }
        }

        /// <summary>
        /// The player that this GameLogic represents (this.blue for blue, this.red for red)
        /// </summary>
        public int Player
        {
            get { return player; }
        }
        public int Opponent
        {
            get { return opponent; }
        }

        public int[,] Field
        {
            set { this.field = value; }
            get { return field; }
        }

        /// <summary>
        /// The size of the game field
        /// </summary>
        public int Dimension
        {
            set { this.dimension = value; }
            get { return this.dimension; }
        }

        public GameLogic(int player, int dimension, int[,] field)
        {
            this.player = player;
            this.opponent = (this.player == blue) ? red : blue;
            this.dimension = dimension;
            this.field = field;
            this.currentPossibilities = new bool[this.dimension, this.dimension];
            this.updateCurrentPossibilities();
        }

        /// <summary>
        /// Updates the currentPossibilities array based on the current game state
        /// </summary>
        public void updateCurrentPossibilities()
        {
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    this.x = x;
                    this.y = y;
                    this.lookForNeighbours();
                    this.currentPossibilities[x, y] =
                        field[x, y] == 0 && directions.Count != 0;
                }
            }
        }

        /// <summary>
        /// Checks the Possibilities array, if it contains at least one possibility
        /// </summary>
        /// <returns>Whether a player can move</returns>
        public bool canPlayerMove()
        {
            foreach (bool p in Possibilities)
            {
                if (p) return true;
            }
            return false;
        }

        /// <summary>
        /// Finds as many valid paths from (this.x, this.y), which would turn stones. 
        /// If after calling this this.Directions.Count is not zero, a move to (this.x, this.y) is valid.
        /// </summary>
        private void lookForNeighbours()
        {
            this.directions = new List<Vector>();
            for (int i = -1; i <= 1; i++)
            {
                for (int p = -1; p <= 1; p++)
                {
                    if (outOfReach(this.x, this.y, i, p)) continue;
                    if (field[x + i, y + p] == field[x, y]) continue;

                    if (field[x + i, y + p] == opponent)
                    {
                        int x = this.x;
                        int y = this.y;
                        while (!outOfReach(x, y, i, p) && field[x + i, y + p] == this.opponent)
                        {
                            x += i;
                            y += p;

                        }
                        if (!outOfReach(x, y, i, p) && field[x + i, y + p] == player)
                        {
                            directions.Add(new Vector(i, p));
                        }
                    }


                }
            }
        }

        private bool outOfReach(int x, int y, int i, int p)
        {
            return (x + i < 0 || x + i >= dimension) || (y + p < 0 || y + p >= dimension);
        }

        /// <summary>
        /// Flips the stones that are on a correct route calculated by this.LookForNeighbours from (this.x, this.y)
        /// </summary>
        private void continueOnRoute()
        {
            foreach (Vector v in this.directions)
            {
                int i = (int)v.X;
                int p = (int)v.Y;
                int x = this.x;
                int y = this.y;
                while (field[x + i, y + p] == this.opponent)
                {
                    x += i;
                    y += p;
                    field[x, y] = player;
                }

            }
        }

        /// <summary>
        /// Returns whether a move is valid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool checkMove(int x, int y)
        {
            this.x = x;
            this.y = y;
            if (this.field[x, y] == 0)
            {
                this.lookForNeighbours();
                if (directions.Count != 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        public int[,] makeMove(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.lookForNeighbours();
            this.continueOnRoute();
            this.field[x, y] = player;
            return this.field;
        }
    }
}
