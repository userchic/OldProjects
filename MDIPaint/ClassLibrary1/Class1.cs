using MDIPaint;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPlugin = PluginInterface.IPlugin;

namespace ClassLibrary1
{
    public class Class1
    {
        [Version(1, 0)]
        public class ReverseTransform : IPlugin
        {
            public string Name
            {
                get
                {
                    return "Очень сложное нанесение надписи с датой на изображение";
                }
            }

            public string Author
            {
                get
                {
                    return "Me";
                }
            }

            public void Transform(PictureBox bitmap)
            {
                Graphics graph = bitmap.CreateGraphics();
                graph.DrawString(DateTime.Now.Date.ToString(), new Font("Arial", 14), Brushes.Green, 2, 2);
            }
        }

    }
}
