using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsFormsApplication2
{
    class GameLogic
    {
        private int dimensions;
        private bool blue;
        private bool red;
        private int[,] field;

        public int[,] Field {
            get { return field; }
        }
        public bool Red
        {
            get { return this.red; }
            set { this.red = value; }
        }
        public bool Blue
        {
            get { return this.blue; }
            set { this.blue = value; }
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
            this.blue = true;
            this.red = false;
            this.dimensions = 6;
            this.buildField();


        }
        public void makeMove(Point p) {
            int x = (int)p.X / this.dimensions;
            int y = (int)p.Y / this.dimensions;
            if (this.field[x, y] == 0) {
                if(this.field[x,y] == 1)

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
            this.field[this.dimensions / 2 - 1, this.dimensions / 2 - 1] = 1;
            this.field[this.dimensions / 2 - 1, this.dimensions / 2 ] = 2;
            this.field[this.dimensions / 2 , this.dimensions / 2 -1] = 2;
            this.field[this.dimensions / 2 , this.dimensions / 2 ] = 1;
        }
    }
}
