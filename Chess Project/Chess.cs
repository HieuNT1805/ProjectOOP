using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chess_Project
{
    public partial class Chess : Form
    {
        int size = 8;
        Board chessBoard = new Board();
        Point selectedPiece = new Point();
        int selectedPlayer = -1;
        int playingPlayer = 1;
        public Chess()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.tableLayoutPanel2.ColumnCount = size;
            this.tableLayoutPanel2.RowCount = size;
            this.tableLayoutPanel2.ColumnStyles.Clear();
            this.tableLayoutPanel2.RowStyles.Clear();
            for (int x = 0; x <size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / size));
                    this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / size));
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    if ((x + y) % 2 == 1)   
                        button.BackColor = Color.LightYellow;
                    else 
                        button.BackColor = Color.DarkGreen;

                    tableLayoutPanel2.Controls.Add(button,x,y);
                    button.Click += Click_Board;
                }
            }
            DrawPieces(chessBoard);
        }
        private void Click_Board(object s, EventArgs e)
        {
            DrawPieces(chessBoard);
            Button button = (Button)s;
            button.FlatStyle = FlatStyle.Standard;
            TableLayoutPanelCellPosition a = tableLayoutPanel2.GetPositionFromControl((Control)s);


            if (!(button.Tag is Piece))
            {
                if (selectedPlayer > -1)
                {
                    
                    chessBoard.ActionPiece(selectedPiece.x+1, selectedPiece.y+1, a.Column , a.Row );
                    selectedPlayer = -1;
                    DrawPieces(chessBoard);
                }
                return;
            }

            Piece chessPiece = (Piece)button.Tag;


            if (selectedPlayer > -1 && selectedPlayer != chessPiece.Player)
            {
                chessBoard.ActionPiece(selectedPiece.x + 1, selectedPiece.y + 1, a.Column, a.Row);
                selectedPlayer = -1;
                DrawPieces(chessBoard);
            }
            else
            {
                if (playingPlayer == 1 & chessPiece.Player == 1)
                {
                    selectedPlayer = chessPiece.Player;
                    selectedPiece.x = a.Column - 1;
                    selectedPiece.y = a.Row - 1;
                    foreach (Point point in chessBoard.PieceActions(a.Column, a.Row))
                    {
                        Button actionButton = (Button)tableLayoutPanel2.GetControlFromPosition(point.x, point.y);
                        actionButton.FlatStyle = FlatStyle.Standard;

                    }
                }

            }

            if (selectedPlayer > -1 && selectedPlayer != chessPiece.Player)
            {
                chessBoard.ActionPiece(selectedPiece.x + 1, selectedPiece.y + 1, a.Column, a.Row);
                selectedPlayer = -1;
                DrawPieces(chessBoard);
            }
            else
            {
                if (playingPlayer == 0 & chessPiece.Player == 0)
                {
                    selectedPlayer = chessPiece.Player;
                    selectedPiece.x = a.Column - 1;
                    selectedPiece.y = a.Row - 1;
                    foreach (Point point in chessBoard.PieceActions(a.Column, a.Row))
                    {
                        Button actionButton = (Button)tableLayoutPanel2.GetControlFromPosition(point.x, point.y);
                        actionButton.FlatStyle = FlatStyle.Standard;

                    }
                }
            }
            
        }
        private void DrawPieces(Board board)
        {
            for (int x = 0; x < size; x++)
            {   
                for (int y = 0; y < size; y++)
                {
                    Button button = (Button)tableLayoutPanel2.GetControlFromPosition(x , y);
                    button.FlatStyle = FlatStyle.Flat;  
                    if (board[x, y] != null)
                    {
                        Piece chessPiece = board[x, y];
                        button.Tag = chessPiece;
                        
                        if(board[x,y] is Pawn)
                        {
                            if(chessPiece.Player==1)
                            {
                                button.Image = Properties.Resources.Pawn_White;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                button.Image = Properties.Resources.Pawn_Black;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                        }

                        if (board[x, y] is Knight)
                        {
                            if (chessPiece.Player == 1)
                            {
                                button.Image = Properties.Resources.Knight_White;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                button.Image = Properties.Resources.Knight_Black;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                        }
                        if (board[x, y] is Rook)
                        {
                            if (chessPiece.Player == 1)
                            {
                                button.Image = Properties.Resources.Rook_White;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                button.Image = Properties.Resources.Rook_Black;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                        }
                        if (board[x, y] is Bishop)
                        {
                            if (chessPiece.Player == 1)
                            {
                                button.Image = Properties.Resources.Bishop_White;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                button.Image = Properties.Resources.Bishop_Black;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                        }
                        if (board[x, y] is Queen)
                        {
                            if (chessPiece.Player == 1)
                            {
                                button.Image = Properties.Resources.Qeen_White;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                button.Image = Properties.Resources.Qeen_Black;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                        }
                        if (board[x, y] is King)
                        {
                            if (chessPiece.Player == 1)
                            {
                                button.Image = Properties.Resources.King_White;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                button.Image = Properties.Resources.King_Black;
                                button.ImageAlign = ContentAlignment.MiddleCenter;
                            }
                        }
                    }
                    else
                    {
                        button.Image = null;
                        button.Tag = null;
                    }
                    
                }
            }
        }
        int m1 = 30;
        int s1 = 0;
        int m2 = 30;
        int s2 = 0;
        int sPlus = 0;
        public void Mode(int m,int splus)
        {
            m1 = m;
            m2 = m;
            sPlus = splus;
        }
        
        public void setlabel()
        {
            label2.Text = string.Format("{0}:{1}", m1.ToString(), s1.ToString()); 
            label3.Text = string.Format("{0}:{1}", m1.ToString(), s1.ToString());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {


            s1--;
            if (s1 < 0)
            {
                s1 = 59;
                m1--;
            }
            if (m1 < 0)
            {
                timer1.Stop();
                MessageBox.Show("Player 2 win");
                s1 = 0;
                m1 = 0;

            }
            
            label2.Text = string.Format("{0}:{1}", m1.ToString(), s1.ToString());
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {


            s2--;
            if (s2 < 0)
            {
                s2 = 59;
                m2--;
            }
            if (m2 < 0)
            {
                timer1.Stop();
                MessageBox.Show("Player 1 win");
                s2 = 0;
                m2 = 0;
            }
           
            label3.Text = string.Format("{0}:{1}", m2.ToString(), s2.ToString());
        }
        private void P1Win(object sender, EventArgs e)
        {
            MessageBox.Show("Player 1 win");
            
        }
        private void P2Win(object sender, EventArgs e)
        {
            MessageBox.Show("Player 2 win");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            s2 = s2 + sPlus;
            if (!timer1.Enabled)
            {
                timer2.Stop();
                timer1.Start();
            }
            playingPlayer = 1;
            if (s2 > 60)
            {
                s2 = s2 - 60;
                m2++;
            }
            label3.Text = string.Format("{0}:{1}", m2.ToString(), s2.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            s1 = s1 + sPlus;
            if (!timer2.Enabled)
            {
                timer1.Stop();
                timer2.Start();
            }
            playingPlayer = 0;
            if (s1 > 60)
            {
                s1 = s1 - 60;
                m1++;
            }
            label2.Text = string.Format("{0}:{1}", m1.ToString(), s1.ToString());
        }

      
    }
}
