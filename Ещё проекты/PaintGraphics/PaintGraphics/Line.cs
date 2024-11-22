using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PaintGraphics
{
    [Serializable]
    public class Line
    {
        public Tochka point1;
        public Tochka point2;
        [NonSerialized]
        public System.Drawing.Pen pen;
        public int A, B, C;
        public double lenga;
        [NonSerialized]
        public DataGridViewRow Row;
        public Line(int x1, int x2, int y1, int y2, Pen pen) : this(x1, x2, y1, y2)
        {
            this.pen = pen;
        }
        public Line(int x1,int x2,int y1, int y2)
        {
            point1 = new Tochka(x1, y1);
            point2 = new Tochka(x2, y2);
            UpdateLenga();

            UpdateABC();
        }
        public int X1
        {
            get
            {
                return point1.X;
            }
            set
            {
                point1.X = value;
                if (HasRow())
                    Row.Cells[0].Value = X1;
                UpdateABC();
            }
        }
        public int Y1
        {
            get
            {
                return point1.Y;
            }
            set
            {
                point1.Y = value;
                if (HasRow())
                    Row.Cells[1].Value = Y1;
                UpdateABC();
            }
        }
        public double OK1
        {
            get
            {
                return point1.OK;
            }
            set
            {
                point1.OK = value;
                if (HasRow())
                {
                    Row.Cells[2].Value = OK1;
                    ResetPoint1();
                }
                UpdateABC();
            }
        }
        public void ResetPoint1()
        {
            Row.Cells[0].Value = point1.X;
            Row.Cells[1].Value = point1.Y;
        }
        public int X2
        {
            get
            {
                return point2.X;
            }
            set
            {
                point2.X = value;
                if (HasRow())
                    Row.Cells[3].Value = X2;
                UpdateABC();
            }
        }
        public int Y2
        {
            get
            {
                return point2.Y;
            }
            set
            {
                point2.Y = value;
                if (HasRow())
                    Row.Cells[4].Value = Y2;
                UpdateABC();
            }
        }

        public double OK2
        {
            get
            {
                return point2.OK;
            }
            set
            {
                point2.OK = value;
                if (HasRow())
                {
                    Row.Cells[5].Value = OK2;
                    ResetPoint2();
                }
                UpdateABC();
            }
        }
        public void ResetPoint2()
        {
            Row.Cells[3].Value = point2.X;
            Row.Cells[4].Value = point2.Y;
        }
        public bool HasRow()
        {
            if (Row != null)
                return true;
            else 
                return false;
        }
        public void UpdateABC()
        {
            A = point1.Y - point2.Y;
            B = point2.X - point1.X;
            C = point1.X * point2.Y - point2.X * point1.Y;
        }
        private void UpdateLenga()
        {
            lenga = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

        public void changePoint1(int x, int y, double ok)
        {
            point1.ChangePoint (x,y,ok);
            UpdateABC();
            point1.UpdateBackGround();
        }
        public void changePoint2(int x, int y, double ok)
        {
            point2.ChangePoint (x,y,ok);
            UpdateABC();
            point2.UpdateBackGround();
        }
        public void ChangeParam(int index, string str)
        {
            double value;
            if (double.TryParse(str, out value))
                switch (index)
                {
                    case 0:
                        X1 = (int)value;
                        break;
                    case 1:
                        Y1 = (int)value;
                        break;
                    case 2:
                        OK1 = value;
                        break;
                    case 3:
                        X2 = (int)value;
                        break;
                    case 4:
                        Y2 = (int)value;
                        break;
                    case 5:
                        OK2 = value;
                        break;
                    default:
                        break;
                }
            else
                ChangeParam(index, getParam(index).ToString());
            UpdateABC();
        }

        public object getParam(int Index)
        {
            switch (Index)
            {
                case 0:
                    return point1.X;
                case 1:
                    return point1.Y;
                case 2:
                    return point1.OK;
                case 3:
                    return point2.X;
                case 4:
                    return point2.Y;
                case 5:
                    return point2.OK;

                default: return new object();
            }
        }
    }
}
