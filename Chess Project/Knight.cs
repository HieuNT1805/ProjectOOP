using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    class Knight : Piece
    {
       
        public Knight(int player)
        {
            base.Player = player;
            CaculateMove();
        }
        public override Piece CaculateMove()
        {
            availableMove = new Point[8][]
            {
                new []{new Point(1,2)},
                new []{new Point(2,1)},
                new []{new Point(-1,-2)},
                new []{new Point(-2,-1)},
                new []{new Point(-1,2)},
                new []{new Point(-2,1)},
                new []{new Point(1,-2)},
                new []{new Point(2,-1)}
            };
            availableAttack = availableMove;
            return this;
        }
      
    }
}
