using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Project
{
    class Board
    {
        Piece[,] board;
        int COLUMS = 8;
        int ROWS = 8;
        private Board SetupBoard()
        {
            board = new Piece[COLUMS, ROWS];

            for (int i = 0; i < COLUMS; i++)
            {
                board[i, 1] = new Pawn(0);
                board[i, ROWS - 2] = new Pawn(1);
            }
            board[0, 0] = new Rook(0);
            board[7, 0] = new Rook(0);
            board[0, 7] = new Rook(1);
            board[7, 7] = new Rook(1);

            board[1, 0] = new Knight(0);
            board[6, 0] = new Knight(0);
            board[1, 7] = new Knight(1);
            board[6, 7] = new Knight(1);

            board[2, 0] = new Bishop(0);
            board[5, 0] = new Bishop(0);
            board[2, 7] = new Bishop(1);
            board[5, 7] = new Bishop(1);

            board[3, 0] = new Queen(0);
            board[4, 0] = new King(0);
            board[4, 7] = new King(1);
            board[3, 7] = new Queen(1);

            return this;
        }

        public Board()
        {
            SetupBoard();
        }

        public Piece this[int x, int y]
        {
            get => board[x, y]; 
        }
        


        public List<Point> PieceActions(int x, int y, bool ignoreCheck = false, bool attackActions = true, bool moveActions = true, Piece[,] board = null)
        {
            if (board == null)
            {
                board = this.board;
            }
            bool[,] legalActions = new bool[board.GetLength(0), board.GetLength(1)];
            List<Point> availableActions = new List<Point>();
            Piece movingPiece = board[x, y];

            if (attackActions)
            {
                foreach (Point[] direction in movingPiece.AvailableAttack)
                {
                    foreach (Point attackPoint in direction)
                    {
                        Point adjustedPoint = new Point(attackPoint.x + x, attackPoint.y + y);
                        if (ValidatePoint(adjustedPoint))
                        {
                            if (board[adjustedPoint.x, adjustedPoint.y] != null && board[adjustedPoint.x, adjustedPoint.y].Player == movingPiece.Player)
                                break;
                            if (board[adjustedPoint.x, adjustedPoint.y] != null)
                            {
                                AddMove(availableActions, new Point(x, y), adjustedPoint, ignoreCheck);
                                break;
                            }

                        }
                    }
                }
            }

            if (moveActions)
            {
                foreach (Point[] direction in movingPiece.AvailableMove)
                {
                    foreach (Point movePoint in direction)
                    {
                        Point adjustedPoint = new Point(movePoint.x + x, movePoint.y + y);
                        if (ValidatePoint(adjustedPoint))
                        {
                            if (board[adjustedPoint.x, adjustedPoint.y] != null)
                                break;
                            AddMove(availableActions, new Point(x, y), adjustedPoint, ignoreCheck);
                        }
                    }
                }
            }

            if (movingPiece is King && ((King)movingPiece).CanCastle)
            {
                int rookX = 0;
                if (board[rookX, y] is Rook && ((Rook)board[rookX, y]).CanCastle)
                {
                    bool missedCondition = false;
                    foreach (int rangex in Enumerable.Range(rookX + 1, Math.Abs(rookX - x) - 1))
                    {
                        if (board[rangex, y] != null)
                            missedCondition = true;
                    }
                    missedCondition = missedCondition || KingInCheck(movingPiece.Player);
                    if (!missedCondition)
                    {
                        AddMove(availableActions, new Point(x, y), new Point(x - 2, y), ignoreCheck);
                        //AddMove(availableActions, new Point(x, y), new Point(x + 2, y), ignoreCheck);
                    }
                }
                rookX = COLUMS - 1;
                if (board[rookX, y] is Rook && ((Rook)board[rookX, y]).CanCastle)
                {
                    bool missedCondition = false;
                    foreach (int rangex in Enumerable.Range(x + 1, Math.Abs(rookX - x) - 1))
                    {
                        if (board[rangex, y] != null)
                            missedCondition = true;
                    }
                    missedCondition = missedCondition || KingInCheck(movingPiece.Player);
                    if (!missedCondition)
                    {
                        AddMove(availableActions, new Point(x, y), new Point(x + 2, y), ignoreCheck);
                    }
                }
            }

            if (movingPiece is Pawn)
            {
                Pawn pawn = (Pawn)movingPiece;
                int flipDirection = 1;

                if (pawn.Player == 1)
                    flipDirection = -1;
                if (pawn.AttackLeft)
                {
                    Point atackpoint;
                    atackpoint = Piece.GetDiganalMove(1,DiagnalDirection.ForwarfLeft)[0];
                    atackpoint.y *= flipDirection;
                    atackpoint.y += y;
                    atackpoint.x += x;
                    if (ValidatePoint(atackpoint))
                    {
                        AddMove(availableActions, new Point(x, y), atackpoint, ignoreCheck);
                    }
                }
                if (pawn.AttackRight)
                {
                    Point atackpoint;
                    atackpoint = Piece.GetDiganalMove(1, DiagnalDirection.ForwarfRight)[0];
                    atackpoint.y *= flipDirection;
                    atackpoint.y += y;
                    atackpoint.x += x;
                    if (ValidatePoint(atackpoint))
                    {
                         AddMove(availableActions, new Point(x, y), atackpoint, ignoreCheck);
                    }
                }
            }
            return availableActions;
        }
        private bool CheckSquareVulnerable(int squareX, int squareY, int player, Piece[,] board = null)
        {
            if (board == null)
            {
                board = this.board;
            }
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] != null && board[x, y].Player != player)
                    {
                        foreach (Point point in PieceActions(x, y, true, true, false, board))
                        {
                            if (point.x == squareX && point.y == squareY)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool KingInCheck(int player)
        {
            for (int x = 0; x < COLUMS; x++)
            {
                for (int y = 0; y < ROWS; y++)
                {
                    Piece piece = board[x, y];
                    if (piece != null && piece.Player == player && piece is King)
                    {
                        if (CheckSquareVulnerable(x, y, player))
                            return true;
                        else
                            return false;
                    }
                }
            }
            return false;
        }
        public List<Point> PieceActions(Point position, bool ignoreCheck = false, bool attackActions = true, bool moveActions = true, Piece[,] board = null)
        {
            return PieceActions(position.x, position.y, ignoreCheck, attackActions, moveActions, board);
        }

        public bool ActionPiece(int fromX, int fromY, int toX, int toY)
        {
            return ActionPiece(new Point(fromX, fromY), new Point(toX, toY));
        }

        public bool ActionPiece(Point from, Point to, bool bypassValidaiton = false)
        {
            if (bypassValidaiton || PieceActions(from).Contains(to))
            {
                Piece movingPiece = board[from.x, from.y];
                if (movingPiece is Pawn)
                {
                    Pawn pawn = (Pawn)movingPiece;
                    if (Math.Abs(from.x - from.y) == 2)
                    {
                        int adjasentX = to.x - 1;
                        if (adjasentX > -1 && board[adjasentX, to.y] != null && board[adjasentX, to.y].Player != movingPiece.Player && board[adjasentX, to.y] is Pawn)
                        {
                            if (!bypassValidaiton)
                                ((Pawn)board[adjasentX, to.y]).AttackRight = true;
                        }
                        adjasentX = adjasentX + 2;
                        if (adjasentX < COLUMS && board[adjasentX, to.y] != null && board[adjasentX, to.y].Player != movingPiece.Player && board[adjasentX, to.y] is Pawn)
                        {
                            if (!bypassValidaiton)
                                ((Pawn)board[adjasentX, to.y]).AttackLeft = true;
                        }
                    }
                    if (from.x != to.x && board[to.x, to.y] == null)
                    {
                        board[to.x, from.y] = null;
                    }
                    if (!bypassValidaiton)
                        pawn.CanMove2Cell = false;
                }
                if (movingPiece is CastlePiece)
                {
                    CastlePiece RookOrKing = (CastlePiece)movingPiece;
                    if (!bypassValidaiton)
                        RookOrKing.CanCastle = false;
                }
                if (movingPiece is King)
                {
                    King king = (King)movingPiece;
                    if (from.x - to.x == 2)
                    {
                        board[to.x + 1, from.y] = board[0, from.y];
                        board[0, from.y] = null;
                    }
                    if (from.x - to.x == -2)
                    {
                        board[to.x - 1, from.y] = board[COLUMS - 1, from.y];
                        board[COLUMS - 1, from.y] = null;
                    }

                }
                movingPiece.CaculateMove();
                board[from.x, from.y] = null;
                board[to.x, to.y] = movingPiece;
                return true;
            }
            return false;
        }
        private void AddMove(List<Point> availableActions, Point fromPoint, Point toPoint, bool ignoreCheck = false)
        {
            bool kingInCheck = false;
            if (!ignoreCheck)
            {
                Piece movingPiece = board[fromPoint.x, fromPoint.y];
                Piece[,] boardBackup = (Piece[,])board.Clone();
                ActionPiece(fromPoint, toPoint, true);
                kingInCheck = KingInCheck(movingPiece.Player);
                board = boardBackup;
            }
            if (ignoreCheck || !kingInCheck)
                availableActions.Add(toPoint);
        }

        private bool ValidateRange(int value, int high, int low = -1)
        {
            return value > low && value < high;
        }

        public bool ValidateX(int value)
        {
            return ValidateRange(value, board.GetLength(0));
        }

        public bool ValidateY(int value)
        {
            return ValidateRange(value, board.GetLength(1));
        }

        public bool ValidatePoint(Point point)
        {
            return ValidateX(point.x) && ValidateY(point.y);
        }
    }



}
