using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Project
{
    public class Queen : Piece
    {
       
        public Queen(int player)
        {
            base.Player = player;
            CaculateMove();
        }
        public override Piece CaculateMove()
        {
            availableMove = new Point[8][];
            availableMove[0] = GetMove(MaxDistance, Direction.Forwarf);
            availableMove[1] = GetMove(MaxDistance, Direction.Backward);
            availableMove[2] = GetMove(MaxDistance, Direction.Left);
            availableMove[3] = GetMove(MaxDistance, Direction.Right);

            availableMove[4] = GetDiganalMove(MaxDistance, DiagnalDirection.BackwardLeft);
            availableMove[5] = GetDiganalMove(MaxDistance, DiagnalDirection.BackwardRight);
            availableMove[6] = GetDiganalMove(MaxDistance, DiagnalDirection.ForwarfLeft);
            availableMove[7] = GetDiganalMove(MaxDistance, DiagnalDirection.ForwarfRight);

            availableAttack = availableMove;
            return this;
        }

    }
}
