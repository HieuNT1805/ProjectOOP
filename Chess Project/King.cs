using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    class King : CastlePiece
    {
      

        public King(int player)
        {
            base.Player = player;
            this.canCastle = true;
            CaculateMove();
        }

        public King(bool castle)
        {
            this.canCastle = castle;
            CaculateMove();
        }
        public override Piece CaculateMove()
        {
            if (this.canCastle && false)
            {
                availableMove = new Point[10][];
                availableMove[8] = new[] { new Point(2, 0) };
                availableMove[9] = new[] { new Point(-2, 0) };
            }
            else
                availableMove = new Point[8][];

            availableMove[0] = GetMove(1, Direction.Forwarf);
            availableMove[1] = GetMove(1, Direction.Backward);
            availableMove[2] = GetMove(1, Direction.Left);
            availableMove[3] = GetMove(1, Direction.Right);
            availableMove[4] = GetDiganalMove(1, DiagnalDirection.BackwardLeft);
            availableMove[5] = GetDiganalMove(1, DiagnalDirection.BackwardRight);
            availableMove[6] = GetDiganalMove(1, DiagnalDirection.ForwarfLeft);
            availableMove[7] = GetDiganalMove(1, DiagnalDirection.ForwarfRight);

            availableAttack = new Point[8][];
            Array.Copy(availableMove, 0, availableAttack, 0, 8);
            return this;
        }
       
    }
}
