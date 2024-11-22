using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintGraphics
{
    public partial class Form1 : Form
    {
        public  int x, y;
        public List<Line> lines = new List<Line>();
        public Bitmap bmp;
        public Bitmap bmp2;
        public Pen MainPen = new Pen(Brushes.Black, 10);
        public bool Changed = false;
        public Color basicPixel ;
        readonly List<Tool> tools = new List<Tool>();
        Tool tool;
        private int focusedLine;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(600, 600);
            bmp2 = new Bitmap(600, 600);
            DoubleBuffered = true;
            tools = new List<Tool>() { new LineCreate(this) ,new LineEdit(this),new LineDelete(this)};
            tool = tools[0];
            //toCreateLine();
            dataTable1.lines = lines;
            dataTable1.form = this;
            toolStripComboBox1.SelectedIndex = 0;
            basicPixel = bmp.GetPixel(0, 0);
            BuildBorder(bmp2.Width,bmp2.Height);
        }
        public void BuildBorder(int W,int H)
        {
            Graphics g = Graphics.FromImage(bmp2);
            g.DrawLine(MainPen, W, 0,W,H);
            g.DrawLine(MainPen, 0, H, W, H);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);
            e.Graphics.DrawImageUnscaled(bmp2, 0, 0);
        }
        public void Clear_Picture()
        {
            bmp = new Bitmap(bmp.Width, bmp.Height);
        }
        public void UpdateXY(int X, int Y)
        {
            x = X;
            y = Y;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tool = tools[toolStripComboBox1.SelectedIndex];
            tool.RewriteAll();
        }
        public void RewriteAll()
        {
            Clear_Picture();
            WritePicture();
        }
        public void WritePicture()
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < lines.Count; i++)
            {
                g.DrawLine(MainPen, lines[i].point1.X, lines[i].point1.Y, lines[i].point2.X, lines[i].point2.Y);
                Invalidate();
            }
            Refresh();
        }
        #region Фокус
        public void Focus(Line line)
        {
            Graphics g = CreateGraphics();
            Point point1 = new Point(line.point1.X, line.point1.Y);
            Point point2 = new Point(line.point2.X, line.point2.Y);
            g.DrawLine(new Pen(Brushes.Blue,MainPen.Width), point1, point2);
            ShowFormula(line);
        }

        private void ShowFormula(Line line)
        {
            int A, B, C,x,y;
            (A, B, C) = (line.A, line.B, line.C);
            toolStripLabel1.Text=A+"*x+"+B+"*y+"+C;
        }

        int line
        {
            get
            {
                return focusedLine;
            }
            set
            {
                if (focusedLine != value)
                    Refresh();
                focusedLine = value;
            }
        }
        private void FocusOnLine(int X,int Y)
        {
            try
            {
                if (bmp.GetPixel(X, Y) != basicPixel)
                {
                    line = FindClosestLine(X, Y);
                    Focus(lines[line]);
                }
                else
                {
                    line = -1;
                    toolStripLabel1.Text = "";
                }
            }
            catch { }
        }
        public int FindClosestLine(int X,int Y)
        {
            double min = (int)Math.Sqrt(bmp.Width * bmp.Width + bmp.Height * bmp.Height);
            int linenum = 1;
            for (int i = 0; i < lines.Count; i++)
            {
                double dist1 = dist(X, Y, lines[i].point1.X, lines[i].point1.Y);
                double dist2 = dist(X, Y, lines[i].point2.X, lines[i].point2.Y);
                if (isObtuseTriangle(i, dist1, dist2))
                {
                    if (Math.Min(dist1, dist2) < min)
                    {
                        min = Math.Min(dist1, dist2);
                        linenum = i;
                    }
                }
                else
                {
                    if (pointLineDist(X, Y, lines[i]) < min)
                    {
                        min = pointLineDist(X,Y, lines[i]);
                        linenum = i;
                    }
                }
            }
            return linenum;
        }
        public bool isObtuseTriangle(int i, double dist1, double dist2)
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
        private double pointLineDist(int X,int Y, Line line)
        {
            return Math.Abs(line.A * X + line.B * Y + line.C) / Math.Sqrt(line.A * line.A + line.B * line.B);
        }
#endregion
        #region реализация событий мыши
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            tool.MouseDown(e);
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            tool.MouseUp(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            tool.MouseMove(e);
            FocusOnLine(e.X, e.Y);
        }
        #endregion
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        public double dist(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
}
