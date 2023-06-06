using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    public struct Point
    {
        public int x;
        public int y;
        
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return (String.Format("({0}, {1})", x, y));
        }
        
    }
 
}
