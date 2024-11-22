using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintGraphics
{
    public class LineEdit : Tool
    {
        private int editedLineNum=-1;
        private int editedPoint=-1;
        private Line SpLine;
        public bool DragPoint = false;
        public LineEdit(Form1 Form) : base(Form) { }
        public override void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (bmp.GetPixel(e.Location.X, e.Location.Y) != form.basicPixel)
                {
                    editedLineNum = 0;
                    editedPoint = 0;
                    bool stopFlag = false;
                    DragPoint = false;
                    SpLine = null;
                    FindCircle(e.Location, ref stopFlag, ref editedPoint, ref editedLineNum);
                    Clean_Picture();
                    if (stopFlag)
                    {
                        Tochka point;
                        DragPoint = true;
                        Graphics g = Graphics.FromImage(bmp);
                        for (int i = 0; i < lines.Count; i++)
                        {
                            if (i != editedLineNum)
                            {
                                g.DrawLine(form.MainPen, lines[i].point1.X, lines[i].point1.Y, lines[i].point2.X, lines[i].point2.Y);
                                g.FillEllipse(Brushes.Black, lines[i].point1.X - 10, lines[i].point1.Y - 10, 20, 20);
                                g.FillEllipse(Brushes.Black, lines[i].point2.X - 10, lines[i].point2.Y - 10, 20, 20);
                            }
                            else
                            {
                                if (editedPoint != 1)
                                    point = lines[i].point1;
                                else
                                    point = lines[i].point2;
                                UpdateXY(point.X, point.Y);
                                g.FillEllipse(Brushes.Black, point.X - 10, point.Y - 10, 20, 20);
                            }
                            lines[i].point1.UpdateBackGround();
                            lines[i].point2.UpdateBackGround();
                            Invalidate();
                        }
                        Refresh();
                    }
                    else
                    {
                        DragPoint = false;
                        editedLineNum = FindClosestLine(new Tochka(e.Location.X, e.Location.Y));
                        Graphics g = Graphics.FromImage(bmp);
                        for (int i = 0; i < lines.Count; i++)
                        {
                            if (i != editedLineNum)
                            {
                                g.DrawLine(MainPen, lines[i].point1.X, lines[i].point1.Y, lines[i].point2.X, lines[i].point2.Y);
                                g.FillEllipse(Brushes.Black, lines[i].point1.X - 10, lines[i].point1.Y - 10, 20, 20);
                                g.FillEllipse(Brushes.Black, lines[i].point2.X - 10, lines[i].point2.Y - 10, 20, 20);

                                lines[i].point1.UpdateBackGround();
                                lines[i].point2.UpdateBackGround();
                            }
                        }
                        Invalidate();
                        int x1, x2, y1, y2;
                        x1 = lines[editedLineNum].point1.X - e.X;
                        x2 = lines[editedLineNum].point2.X - e.X;
                        y1 = lines[editedLineNum].point1.Y - e.Y;
                        y2 = lines[editedLineNum].point2.Y - e.Y;
                        SpLine = new Line(x1, x2, y1, y2, MainPen);
                    }
                }
                else
                {
                    editedLineNum = -1;
                    editedPoint = -1;
                }
            }
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (editedLineNum < lines.Count & editedLineNum >= 0)
                {
                    if (DragPoint)
                    {
                        Refresh();
                        Graphics g = form.CreateGraphics();
                        g.DrawLine(form.MainPen, x, y, e.X, e.Y);
                        g.FillEllipse(Brushes.Black, e.X - 10, e.Y - 10, 20, 20);
                    }
                    else
                    {
                        int x1, x2, y1, y2;
                        x1 = SpLine.point1.X + e.X;
                        x2 = SpLine.point2.X + e.X;
                        y1 = SpLine.point1.Y + e.Y;
                        y2 = SpLine.point2.Y + e.Y;

                        Refresh();
                        Graphics g = form.CreateGraphics();
                        g.DrawLine(MainPen, x1, y1, x2, y2);
                        g.FillEllipse(Brushes.Black, x1 - 10, y1 - 10, 20, 20);
                        g.FillEllipse(Brushes.Black, x2 - 10, y2 - 10, 20, 20);
                    }
                }
            }
        }
        public override void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (editedLineNum < lines.Count & editedLineNum >= 0)
                {

                    if (!DragPoint)
                    {
                        int x1, x2, y1, y2;
                        x1 = SpLine.point1.X + e.X;
                        x2 = SpLine.point2.X + e.X;
                        y1 = SpLine.point1.Y + e.Y;
                        y2 = SpLine.point2.Y + e.Y;
                        lines[editedLineNum].changePoint1(x1, y1, 1);
                        lines[editedLineNum].changePoint2(x2, y2, 1);
                    }
                    else
                    {
                        Tochka point;
                        if (editedPoint != 1)
                            point = lines[editedLineNum].point2;
                        else
                            point = lines[editedLineNum].point1;
                        point.ChangePoint(e.X, e.Y, 1);
                        UpdateTable();
                    }
                    RewriteAll();
                    Changed = true;
                    UpdateTable();
                }
            }
        }

        public void FindCircle(Point mouse, ref bool stopFlag, ref int point, ref int line)
        {
            while (!stopFlag & editedLineNum < lines.Count)
            {
                if (lines[editedLineNum].point1.backGround.Contains(mouse))
                {
                    stopFlag = true;
                    editedPoint = 1;
                }
                else if (lines[editedLineNum].point2.backGround.Contains(mouse))
                {
                    stopFlag = true;
                    editedPoint = 2;
                }
                else editedLineNum++;
            }
        }
        public override void RewriteAll() 
        {
            base.RewriteAll();
            Write_Circles();
            Refresh();
        }
        public void Write_Circles()
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < lines.Count; i++)
            {
                g.FillEllipse(Brushes.Black, lines[i].point1.X - 10, lines[i].point1.Y - 10, 20, 20);
                g.FillEllipse(Brushes.Black, lines[i].point2.X - 10, lines[i].point2.Y - 10, 20, 20);
            }
        }
    }
}
