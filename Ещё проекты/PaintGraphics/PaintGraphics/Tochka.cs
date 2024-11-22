using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintGraphics
{
    public class Tochka
    {
        int x, y;
        double ok;
        public Rectangle backGround;
        public Tochka(int X, int Y)
        {
            (x, y, ok) = (X, Y, 1);
        }
        public Tochka(int X, int Y, double OK)
        {
            (x, y, ok) = (X, Y, OK);
            Normalize();
        }
        public void Normalize()
        {
            x = (int)(x / ok);
            y = (int)(y / ok);
            ok = 1;
        }
        public static explicit operator Tochka(Point v)
        {
            return new Tochka(v.X, v.Y);
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double OK
        {
            get
            {
                return ok;
            }
            set
            {
                if (value == 0)
                    ok = 1;
                else
                if (value != 1)
                {
                    ok = value;
                    Normalize();
                }
            }
        }
        public void ChangePoint(int X, int Y, double OK)
        {
            (x, y, ok) = (X, Y, OK);
            Normalize();
            UpdateBackGround();
        }
        public void UpdateBackGround()
        {
            backGround.X = X - 10;
            backGround.Y = Y - 10;
        }
    }
}
