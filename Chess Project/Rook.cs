using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    class Rook : CastlePiece
    {
        public Rook(int player)
        {
            base.Player = player;
            this.canCastle = true;
            CaculateMove();
        }

        public override Piece CaculateMove()
        {
            availableMove = new Point[4][];
            availableMove[0] = GetMove(MaxDistance, Direction.Backward);
            availableMove[1] = GetMove(MaxDistance, Direction.Forwarf);
            availableMove[2] = GetMove(MaxDistance, Direction.Left);
            availableMove[3] = GetMove(MaxDistance, Direction.Right);
            availableAttack = availableMove;
            return this;
        }
        

    }
}
