﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Square
    {
        

        private int side;
        public int Side { get => side; set => side = value == 0 ? 1 : value; }


        public Square()
        {
        }

        

        public double Diagonal(int side) => Math.Sqrt(2 * Side * Side);


        public int Perimeter(int side) => 4 * Side;


        public int Area(int side) => Side * Side;        


        public override string ToString()
        {
            return "\nSide: " + Side + "\nArea: " + Area(Side) + "\nPerimeter: " + Perimeter(Side) + "\nDiagonal: " + Diagonal(Side);
        }
    }
}
