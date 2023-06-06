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
    public partial class MySecondCustmControl : UserControl
    {
        public MySecondCustmControl()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chess chess = new Chess();
            chess.Mode(90, 30);
            chess.setlabel();
            chess.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chess chess = new Chess();
            chess.Mode(15, 10);
            chess.setlabel();
            chess.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chess chess = new Chess();
            chess.Mode(3, 2);
            chess.setlabel();
            chess.Show();
        }
    }
}
