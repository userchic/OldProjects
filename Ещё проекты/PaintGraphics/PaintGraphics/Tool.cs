using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintGraphics
{
    public abstract class Tool
    {
        public Form1 form;
        public bool Changed=false;
        public Tool(Form1 Form)
        {
            form = Form;
        }
        public abstract void MouseMove(MouseEventArgs e);
        public abstract void MouseDown(MouseEventArgs e);
        public abstract void MouseUp(MouseEventArgs e);
        public virtual void RewriteAll()
        {
            form.RewriteAll();
        }

        public double dist(int x1,int y1,int x2,int y2)
        {
            return form.dist(x1, y1, x2, y2);
        }
        public double pointLineDist(Tochka mouse, Line line)
        {
            return Math.Abs(line.A * mouse.X + line.B * mouse.Y + line.C) / Math.Sqrt(line.A * line.A + line.B * line.B);
        }
        public Pen MainPen
        {
            get
            {
                return form.MainPen;
            }
        }
        public void UpdateXY(int x,int y)
        {
            form.UpdateXY(x,y);
        }
        public List<Line> lines
        {
            get
            {
                return form.lines;
            }
        }
        public int x
        {
            get
            {
                return form.x;
            }
            set
            {
                form.x = value;
            }
        }
        public int y
        {
            get
            {
                return form.y;
            }
            set
            {
                form.y = value;
            }
        }
        public Bitmap bmp
        {
            get
            {
                return form.bmp;
            }
            set { form.bmp = value; }
        }
        public  void Invalidate()
        {
            form.Invalidate();
        }
        public void Clean_Picture()
        {
            form.Clear_Picture();
        }
        public void UpdateTable()
        {
            form.dataTable1.UpdateTable();
        }
        public void Refresh()
        {
            form.Refresh();
        }
        public int FindClosestLine(Tochka mouse)
        {
            double min = (int)Math.Sqrt(bmp.Width * bmp.Width + bmp.Height * bmp.Height);
            int linenum = 1;
            for (int i = 0; i < lines.Count; i++)
            {
                double dist1 = dist(mouse.X, mouse.Y, lines[i].point1.X, lines[i].point1.Y);
                double dist2 = dist(mouse.X, mouse.Y, lines[i].point2.X, lines[i].point2.Y);
                double Dist;
                Dist = isObtuseTriangle(i, mouse, dist1, dist2) ? Math.Min(dist1, dist2) : pointLineDist(mouse, lines[i]);
                if (Dist < min)
                {
                    min = Dist;
                    linenum = i;
                }
            }
            return linenum;
        }
        public bool isObtuseTriangle(int i, Tochka mouse, double dist1, double dist2)
        {
            double dist3 = lines[i].lenga;
            if (dist2 < dist1 & dist3 < dist1)
                if (CheckObtuse(dist2, dist3, dist1)) return true;
            if (dist1 < dist2 & dist3 < dist2)
                if (CheckObtuse(dist1, dist3, dist2)) return true;
            return false;
        }
        public bool CheckObtuse(double A, double B, double C)
        {
            if (A * A + B * B < C * C) return true;
            return false;
        }
    }
}
