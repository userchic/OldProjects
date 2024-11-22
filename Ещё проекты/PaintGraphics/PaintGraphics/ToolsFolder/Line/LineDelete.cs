using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintGraphics
{
    public class LineDelete : Tool
    {
        public LineDelete(Form1 Form) : base(Form) { }
        public override void MouseDown(MouseEventArgs e)  {  }
        public override void MouseMove(MouseEventArgs e)  {  }
        public override void MouseUp(MouseEventArgs e)
        {
            if (bmp.GetPixel(e.Location.X, e.Location.Y) != form.basicPixel)
            {
                int line = FindClosestLine((Tochka)e.Location);
                lines.RemoveAt(line);
                RewriteAll();
            }
        }

        public override void RewriteAll()
        {
            base.RewriteAll();
        }
    }
}
