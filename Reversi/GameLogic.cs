using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace WindowsFormsApplication2
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


        public int[,] Field
        {
            get { return field; }
        }

        public int Dimensions
        {
            set
            {
                this.dimensions = value;
            }
            get { return this.dimensions; }
        }
        public GameLogic()
        {
            this.current = blue;
            this.opposite = red;
            this.dimensions = 6;
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
                        field[x, y] == 0 && lookForNeighbours(true).Count != 0;
                }
            }
        }

        private List<Vector> lookForNeighbours(bool onlyOneNeighbour)
        {
            List<Vector> directions = new List<Vector>();
            for (int i = -1; i <= 1; i++)
            {

                for (int p = -1; p <= 1; p++)
                {
                    try {
                        if (field[x + i, y + p] == field[x,y]) continue;
                        if (field[x + i, y + p] == opposite)
                        {
                            int x = this.x;
                            int y = this.y;
                            while (field[x + i, y + p] == this.opposite)
                            {
                                x += i;
                                y += p;
                                
                            }
                            if (field[x + i, y + p] == current)
                            {
                                directions.Add(new Vector(i, p));
                                if (onlyOneNeighbour) return directions;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    }
            }
            return directions;

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

        //private bool checkNeighbours(int x, int y)
        //{
        //    int count = 0;
        //    for (int i = -1; i <= 1; i++)
        //    {

        //        for (int p = -1; p <= 1; p++)
        //        {
        //            try
        //            {
        //                count++;
        //                if (field[x + p, y + i] == field[x, y]) continue;
        //                if ((current == blue) ? field[x + p, y + i] == 2 : field[x + p, y + i] == 1)
        //                {
        //                    Console.WriteLine("Count at finish  " + count.ToString());
        //                    while (field[x + p, y + i] == 2)
        //                    {
        //                        x += p;
        //                        y += i;
        //                        Console.WriteLine("                                         " + x.ToString() + "  " + y.ToString());
        //                    }
        //                    Console.WriteLine("THis whopn:  " + field[x, y].ToString());
        //                    return (field[x + p, y + i] == 1);

        //                }
        //                else if ((current == red) ? field[x + p, y + i] == 1 : field[x + p, y + i] == 2)
        //                {
        //                    Console.WriteLine("Count at finish  " + count.ToString());

        //                    while (field[x + p, y + i] == 1)
        //                    {
        //                        x += p;
        //                        y += i;
        //                        Console.WriteLine("                                         " + x.ToString() + "  " + y.ToString());
        //                    }
        //                    Console.WriteLine("THis whopn:  " + field[x, y].ToString());
        //                    return (field[x + p, y + i] == 2);
        //                };
        //                Console.WriteLine("Count at intermediate  " + count.ToString());
        //            }
        //            catch
        //            {
        //                continue;
        //            }

        //        }
        //    }
        //    return false;


        //}

        public void makeMove(int x, int y)
        {
            this.x = x;
            this.y = y;
            if (this.field[x, y] == 0)
            {
                List<Vector> vectorList = this.lookForNeighbours(false);
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
