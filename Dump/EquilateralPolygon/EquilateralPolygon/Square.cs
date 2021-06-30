using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace EquilateralPolygon
{
    class Square : EquilateralPolygon
    {
        int perimeter;
        int area;
        public Square(int sides, int sideLength, int perimeter, int area)
            : base(sides, sideLength)
        {
            this.perimeter = perimeter;
            this.area = area;
        }
        public override string ToString()
        {
            return "The square has 
        }
    }
}
