using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class GameLogic
    {
        private int dimensions;
        private const int blue = 1;
        private const int red = 2;
        private int current;
        private int[,] field;
        private int x;
        private int y;


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
            this.current = 1;
            this.dimensions = 6;
            this.buildField();


        }

        //private int[] continueOnRoute(int current, int p, int i) {
        //    while (field[x + p, y + i] == 2)
        //    {
        //        x += p;
        //        y += i;
        //        Console.WriteLine("                                         " + x.ToString() + "  " + y.ToString());
        //    }
        //}

        private bool checkNeighbours(int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {

                for (int p = -1; p <= 1; p++)
                {
                    try
                    {
                        count++;
                        if (field[x + p, y + i] == field[x, y]) continue;
                        if ((current == blue) ? field[x + p, y + i] == 2 : field[x + p, y + i] == 1)
                        {
                            Console.WriteLine("Count at finish  " + count.ToString());
                            while (field[x + p, y + i] == 2)
                            {
                                x += p;
                                y += i;
                                Console.WriteLine("                                         " + x.ToString() + "  " + y.ToString());
                            }
                            Console.WriteLine("THis whopn:  " + field[x, y].ToString());
                            return (field[x + p, y + i] == 1);

                        }
                        else if ((current == red) ? field[x + p, y + i] == 1 : field[x + p, y + i] == 2)
                        {
                            Console.WriteLine("Count at finish  " + count.ToString());

                            while (field[x + p, y + i] == 1)
                            {
                                x += p;
                                y += i;
                                Console.WriteLine("                                         " + x.ToString() + "  " + y.ToString());
                            }
                            Console.WriteLine("THis whopn:  " + field[x, y].ToString());
                            return (field[x + p, y + i] == 2);
                        };
                        Console.WriteLine("Count at intermediate  " + count.ToString());
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
            return false;


        }
        public void changeCurrent() {
            if (this.current == blue) this.current = red;
            else this.current = blue;
        }
        public void makeMove(int x, int y)
        {
            //Console.WriteLine("Blue:    " + this.blue.ToString() + "   Red:    " + this.red.ToString());
            ////Console.WriteLine(x.ToString() + "      " + y.ToString());
            //Console.WriteLine(x.ToString() + "   " + y.ToString() + "   " + this.field[x, y].ToString());
            //Console.WriteLine(x.ToString() + "   " + y.ToString() + "   " + this.checkNeighbours(x, y));

            if (this.field[x, y] == 0)
            {
                if (this.checkNeighbours(x, y))
                {
                    changeCurrent();
                    Console.WriteLine("hoi");
                    if (current == red) this.field[x, y] = blue;
                    else if (current == blue) this.field[x, y] = red;

                }
                else field[x, y] = 0;
            }
        }
        private void buildField()
        {
            this.field = new int[this.dimensions, this.dimensions];
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
