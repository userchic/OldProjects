using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    [Version(1, 0)]
    public class ReverseTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Дата справа снизу";
            }
        }

        public string Author
        {
            get
            {
                return "Me";
            }
        }

        public void Transform(PictureBox pictura)
        {
            Graphics g = Graphics.FromImage(pictura.Image);
            g.DrawString(DateTime.Now.Date.ToString(), new Font("Courier New", 13.0F), new SolidBrush(Color.Black), pictura.Size.Width-120, pictura.Size.Height - 20);
            g.Dispose();
        }
    }
}
