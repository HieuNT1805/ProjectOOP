using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Project
{
    abstract class CastlePiece : Piece
    {
        public bool CanCastle
        {
            get => this.canCastle;
            set => this.canCastle = value;
        }
    }
}
