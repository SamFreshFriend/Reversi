using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Reversi
{
    class GameLogic
    {
        private int dimensions;
        private const int blue = 1;
        private const int red = 2;
        private int current;
        private int opposite;
        private int[,] field;
        private int x;
        private int y;
        private bool[,] currentPossibilities;

        public bool[,] Possibilities
        {
            get
            {
                return currentPossibilities;
            }
        }

        public int Current
        {
            get { return current; }
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
        public int Blue
        {
            get { return blue; }
        }
        public int Red
        {
            get { return red; }
        }
        public int[,] Field
        {
            get { return field; }
        }

        public int Dimensions
        {
            set { this.dimensions = value; }
            get { return this.dimensions; }
        }
        public GameLogic(int dimensions)
        {
            this.current = blue;
            this.opposite = red;
            this.dimensions = dimensions;
            this.buildField();
            this.updateCurrentPossibilities();
        }
        public void changeCurrent()
        {
            int cu = this.current;
            this.current = opposite;
            this.opposite = cu;
        }

        private void updateCurrentPossibilities()
        {
            for (int x = 0; x < dimensions; x++)
            {
                for (int y = 0; y < dimensions; y++)
                {
                    this.x = x;
                    this.y = y;
                    currentPossibilities[x, y] =
                        field[x, y] == 0 && lookForNeighbours().Count != 0;
                }
            }
        }

        private List<Vector> lookForNeighbours()
        {
            List<Vector> directions = new List<Vector>();
            for (int i = -1; i <= 1; i++)
            {
                for (int p = -1; p <= 1; p++)
                {
                    if (outOfReach(x, y, i, p)) continue;
                    if (p == 0 && i == 0) continue;

                    if (field[x + i, y + p] == opposite)
                    {
                        int x = this.x;
                        int y = this.y;

                        while (!outOfReach(x, y, i, p) && field[x + i, y + p] == this.opposite)
                        {
                            x += i;
                            y += p;
                        }
                        if (!outOfReach(x, y, i, p) && field[x + i, y + p] == current)
                        {
                            directions.Add(new Vector(i, p));
                        }
                    }
                }
            }
            return directions;

        }

        private bool outOfReach(int x, int y, int i, int p)
        {
            return ((x + i) < 0 || (x + i) >= dimensions) || ((y + p) < 0 || (y + p) >= dimensions);
        }
        private void continueOnRoute(List<Vector> vectorList)
        {
            foreach (Vector v in vectorList)
            {
                Console.WriteLine(v);
                int i = (int)v.X;
                int p = (int)v.Y;
                int x = this.x;
                int y = this.y;
                while (field[x + i, y + p] == this.opposite)
                {
                    x += i;
                    y += p;
                    field[x, y] = current;
                }

            }
        }


        public void makeMove(int x, int y)
        {
            this.x = x;
            this.y = y;
            if (this.field[x, y] == 0)
            {
                List<Vector> vectorList = this.lookForNeighbours();
                if (vectorList.Count != 0)
                {
                    this.continueOnRoute(vectorList);
                    Console.WriteLine("hoi");
                    if (current == red) this.field[x, y] = red;
                    else if (current == blue) this.field[x, y] = blue;
                    this.changeCurrent();
                    this.updateCurrentPossibilities();

                }
                else field[x, y] = 0;
            }
        }
        private void buildField()
        {
            this.field = new int[this.dimensions, this.dimensions];
            this.currentPossibilities = new bool[this.dimensions, this.dimensions];
            for (int x = 0; x < this.dimensions; x++)
            {
                for (int y = 0; y < this.dimensions; y++)
                {
                    this.field[x, y] = 0;
                }
            }
            this.field[this.dimensions / 2 - 1, this.dimensions / 2 - 1] = blue;
            this.field[this.dimensions / 2 - 1, this.dimensions / 2] = red;
            this.field[this.dimensions / 2, this.dimensions / 2 - 1] = red;
            this.field[this.dimensions / 2, this.dimensions / 2] = blue;
        }
    }
}
