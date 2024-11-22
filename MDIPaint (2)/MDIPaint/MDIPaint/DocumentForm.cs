using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class DocumentForm : Form
    {
        private int x, y;
        public Bitmap bmp;
        public bool IsSaved=false;
        public bool Changed=false;
        public string Path;
        public int ScaleCoefficient;
        public int SizeX, SizeY;
        public DocumentForm()
        {
            InitializeComponent();
            bmp = new Bitmap(300, 200);
            SizeX = 300;
            SizeY = 200;
            ScaleCoefficient = 100;
        }

        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        //private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Graphics g = Graphics.FromImage(bmp);
        //        g.ScaleTransform(ScaleCoefficient, ScaleCoefficient);
        //        g.DrawLine(new Pen(MainForm.Color, MainForm.Width), x, y, e.X, e.Y);
        //        Invalidate();
        //        x = e.X;
        //        y = e.Y;
        //        IsSaved = false;
        //    }
        //}
        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (((MainForm)MdiParent).NameofStick == "Линия")
                {
                    Refresh();
                    Graphics g = CreateGraphics();
                    g.DrawLine(new Pen(MainForm.Color, MainForm.Width*ScaleCoefficient/100), x, y, e.X, e.Y);
                    Changed = true;
                }
                if (((MainForm)MdiParent).NameofStick == "Кисть")
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawLine(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100), x, y, e.X, e.Y);
                    Invalidate();
                    x = e.X;
                    y = e.Y;
                    Changed = true;
                }
                if (((MainForm)MdiParent).NameofStick == "Эллипс")
                {
                    Refresh();
                    Graphics g = CreateGraphics();
                    g.DrawEllipse(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100),x, y, e.X-x, e.Y-y);
                    Changed = true;
                }
                if (((MainForm)MdiParent).NameofStick == "Ластик")
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawLine(new Pen(BackColor, MainForm.Width * ScaleCoefficient / 100), x, y, e.X, e.Y);
                    Invalidate();
                    x = e.X;
                    y = e.Y;
                    Changed = true;
                }
                if (((MainForm)MdiParent).NameofStick == "Звезда")
                {
                    Refresh();
                    Graphics g = CreateGraphics();
                    int n = 5;               // число вершин
                    double R = 25, r = 50;   // радиусы
                    double alpha = 0;        // поворот
                    //double x0 = 60, y0 = 60; // центр                    
                    PointF[] points = new PointF[2 * n + 1];
                    double a = alpha, da = Math.PI / n, l;
                    for (int k = 0; k < 2 * n + 1; k++)
                    {
                        l = k % 2 == 0 ? r : R;
                        points[k] = new PointF((float)(e.X + l * Math.Cos(a)), (float)(e.Y + l * Math.Sin(a)));
                        a += da;
                    }
                    //System.Drawing.Drawing2D.GraphicsPath Path = new System.Drawing.Drawing2D.GraphicsPath(points,new byte[points.Length-1]);
                    //Path.Transform(new System.Drawing.Drawing2D.Matrix())
                    //g.DrawPath(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100),Path);

                    g.DrawLines(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100), points);
                    Changed = true;
                }
            }
        }
        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            if (((MainForm)MdiParent).NameofStick == "Линия")
            {
                g.DrawLine(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100), x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
                Invalidate();
            }
            if (((MainForm)MdiParent).NameofStick == "Эллипс")
            {
                g.DrawEllipse(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100), x, y, e.X-x, e.Y-y);
                x = e.X;
                y = e.Y;
                Invalidate();
            }
            if (((MainForm)MdiParent).NameofStick == "Звезда")
            {
                int n = 5;               // число вершин
                double R = 25, r = 50;   // радиусы
                double alpha = 0;        // поворот
                                         //double x0 = 60, y0 = 60; // центр

                PointF[] points = new PointF[2 * n + 1];
                double a = alpha, da = Math.PI / n, l;
                for (int k = 0; k < 2 * n + 1; k++)
                {
                    l = k % 2 == 0 ? r : R;
                    points[k] = new PointF((float)(e.X + l * Math.Cos(a)), (float)(e.Y + l * Math.Sin(a)));
                    a += da;
                }
                g.DrawLines(new Pen(MainForm.Color, MainForm.Width * ScaleCoefficient / 100), points);
                Invalidate();
            }
        }


        private void IncOfScale_Click(object sender, EventArgs e)
        {
            string str = ScaleCoefTB.Text;
            str=str.Remove(str.Length-1,1);
            str = ((int.Parse(str))+10).ToString()+"%";
            ScaleCoefTB.Text = str;
            ScaleCoefficient += 10;
            bmp=new Bitmap(bmp,new Size(SizeX*ScaleCoefficient/100,SizeY*ScaleCoefficient/100));
            Invalidate();
        }

        private void DocumentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!((DocumentForm)ActiveMdiChild).IsSaved)
            {
                var msb = MessageBox.Show("Ваш рисунок " + Text + " не сохранён.\nСохранить?", "Сохранение", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == msb)
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.AddExtension = true;
                    dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";
                    ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ((DocumentForm)ActiveMdiChild).bmp.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
                        char[] space = new char[1];
                        space[0] = '\\';
                        string[] Adress = dlg.FileName.Split(space);
                        ActiveMdiChild.Text = Adress[Adress.Length - 1];
                        Path = dlg.FileName;
                        IsSaved = true;
                        Changed = false;
                        Close();
                    }
                    else
                        ((DocumentForm)ActiveMdiChild).Close();
                }
                else
                    ((DocumentForm)ActiveMdiChild).Close();
            }
            else
            if (((DocumentForm)ActiveMdiChild).Changed == true) 
            {
                var msb = MessageBox.Show("Ваш рисунок " + Text + " Сохранён, но был изменён.\nСохранить изменения?", "Сохранение", MessageBoxButtons.YesNo);
                if (msb == DialogResult.OK)
                {
                    bmp.Save(((DocumentForm)ActiveMdiChild).Path);
                    Changed = false;
                    Close();
                }
            }
        }

        private void Dec_of_Scale_Click(object sender, EventArgs e)
        {
            string str = ScaleCoefTB.Text;
            str = str.Remove(str.Length - 1, 1);
            str = ((int.Parse(str)) - 10).ToString() + "%";
            ScaleCoefTB.Text = str;
            ScaleCoefficient -= 10;
            bmp = new Bitmap(bmp, new Size(SizeX * ScaleCoefficient / 100, SizeY * ScaleCoefficient / 100));
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
