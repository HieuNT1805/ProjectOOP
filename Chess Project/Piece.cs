using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    public abstract class Piece
    {
        protected int MaxDistance = 7;
        protected bool attackLeft;
        protected bool attackRight;
        protected bool canMove2Cell;
        protected bool canCastle;
        protected Point[][] availableMove;
        protected Point[][] availableAttack;
        int player;
        public Point[][] AvailableAttack
        {
            get => availableAttack;
        }
        public Point[][] AvailableMove
        {
            get => availableMove;
        }
        public int Player
        {
            get => player;
            set => player = value;
        }

        public static Point[] GetMove(int distance, Direction direction)
        {
            Point[] move = new Point[distance];
            int x = 0;
            int y = 0;
            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case Direction.Forwarf:
                        y++;
                        break;
                    case Direction.Backward:
                        y--;
                        break;
                    case Direction.Left:
                        x--;
                        break;
                    case Direction.Right:
                        x++;
                        break;
                }
                move[i] = new Point(x, y);
            }
            return move;
        }
        public static Point[] GetDiganalMove(int distance, DiagnalDirection direction)
        {
            Point[] attack = new Point[distance];
            int x = 0;
            int y = 0;
            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case DiagnalDirection.BackwardLeft:
                        y--;
                        x--;
                        break;
                    case DiagnalDirection.BackwardRight:
                        y--;
                        x++;
                        break;
                    case DiagnalDirection.ForwarfLeft:
                        y++;
                        x--;
                        break;
                    case DiagnalDirection.ForwarfRight:
                        y++;
                        x++;
                        break;
                }
                attack[i] = new Point(x, y);
            }
            return attack;
        }
        public abstract Piece CaculateMove();
    }
}
