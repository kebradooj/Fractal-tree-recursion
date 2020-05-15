using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalTreeReacursion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void drawFractal(int x, int y, int len, double angle, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            double x1, y1;

            x1 = x + len * Math.Sin(angle * Math.PI * 2 / 360.0);
            y1 = y + len * Math.Cos(angle * Math.PI * 2 / 360.0);
            g.DrawLine(new Pen(Color.Black, len / 24), x, panel1.Height - y, (int)x1, panel1.Height - (int)y1);
            if (len > 20)
            {
                drawFractal((int)x1, (int)y1, (int)(len / 1.4), angle + 20, e);
                drawFractal((int)x1, (int)y1, (int)(len / 1.5), angle - 40, e);
                drawFractal((int)x1, (int)y1, (int)(len / 1.7), angle + 30, e);
                drawFractal((int)x1, (int)y1, (int)(len / 1.7), angle + 95, e);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawFractal(panel1.Width / 2, 0, 280, 0, e);
        }
    }
}
