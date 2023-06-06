using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    public class Pawn : Piece
    {
        public Pawn(int player)
        {
            base.Player = player;
            this.canMove2Cell = true;
            CaculateMove();
        }
        public Pawn(int player = 0, bool move2cell = true, bool AttackLeft = false, bool AttackRight = false)
        {
            base.Player = player;
            this.canMove2Cell = move2cell;
            this.attackLeft = AttackLeft;
            this.attackRight = AttackRight;
            CaculateMove();
        }
        
        public override Piece CaculateMove()
        {
            Direction forward;
            DiagnalDirection forwardLeft, forwardRight;
            if (base.Player == 1)
            {
                forward = Direction.Backward;
                forwardRight = DiagnalDirection.BackwardRight;
                forwardLeft = DiagnalDirection.BackwardLeft;
            }
            else
            {
                forward = Direction.Forwarf;
                forwardRight = DiagnalDirection.ForwarfRight;
                forwardLeft = DiagnalDirection.ForwarfLeft;
            }
            availableMove = new Point[1][];
            if (this.canMove2Cell)
                availableMove[0] = GetMove(2, forward);
            else
                availableMove[0] = GetMove(1, forward);

            availableAttack = new Point[2][];
            availableAttack[0] = GetDiganalMove(1, forwardLeft);
            availableAttack[1] = GetDiganalMove(1, forwardRight);
            
            return this;
        }
        public bool CanMove2Cell
        {
            get => this.canMove2Cell;
            set => this.canMove2Cell = value;
        }
        public bool AttackLeft
        {
            get => this.attackLeft;
            set => this.attackLeft = value;
        }
        public bool AttackRight
        {
            get => this.attackRight;
            set => this.attackRight = value;
        }

    }
}
