using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    class Bishop : Piece
    {
        
        public Bishop(int player)
        {
            base.Player = player;
            CaculateMove();
        }
        public override Piece CaculateMove()
        {
            availableMove = new Point[4][];
            availableMove[0] = GetDiganalMove(MaxDistance, DiagnalDirection.ForwarfLeft);
            availableMove[1] = GetDiganalMove(MaxDistance, DiagnalDirection.ForwarfRight);
            availableMove[2] = GetDiganalMove(MaxDistance, DiagnalDirection.BackwardLeft);
            availableMove[3] = GetDiganalMove(MaxDistance, DiagnalDirection.BackwardRight);
            availableAttack = availableMove;
            return this;
        }
    }
}
