using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintGraphics
{
    public class LineCreate: Tool
    {
        public LineCreate(Form1 Form) : base(Form) { }
        public override void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateXY(e.X, e.Y);
            }
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                form.Refresh();
                Graphics g = form.CreateGraphics();
                g.DrawLine(MainPen, x, y, e.X, e.Y);
            }
        }
        public override void MouseUp(MouseEventArgs e) 
        {
            int X1 = x;
            int X2 = e.X;
            int Y1 = y;
            int Y2 = e.Y;
            if (form.dist(X1, Y1, X2, Y2) > 10)
            {
                form.Changed = true;
                CreateLine(X1, Y1, X2, Y2);
            }
            Invalidate();
        }
        public void CreateLine(int x1, int y1, int x2, int y2)
        {
            Line line = new Line(x1, x2, y1, y2);
            line.point1.backGround = new Rectangle(line.point1.X - 10, line.point1.Y - 10, 20, 20);
            line.point2.backGround = new Rectangle(line.point2.X - 10, line.point2.Y - 10, 20, 20);

            lines.Add(line);
            form.dataTable1.AddLine(line);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(MainPen, x1, y1, x2, y2);
            Invalidate();
        }
    }
}
