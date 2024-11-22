using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class MainForm : Form
    {
        public static Color Color { get; set; }
        public static int Width { get; set; }
        public string NameofStick;


        public int BigR, SmallR, StarN;
        void FindPlugins()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");

                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }
        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform(((DocumentForm)this.ActiveMdiChild).pictureBox);
            ((DocumentForm)this.ActiveMdiChild).pictureBox.Refresh();
        }
        void CreatePluginsMenu()
        {
            foreach (IPlugin p in plugins.Values)
            {
                var menuItem = new ToolStripMenuItem(p.Name);
                menuItem.Click += OnPluginClick;

                плагиныToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }
        public MainForm()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();
            Color = Color.Black;
            Width = 3;
            TSL_of_Size.Text = Width.ToString();
            TSCB_of_pen.Text = TSCB_of_pen.Items[0].ToString();
            NameofStick = TSCB_of_pen.Text;
            BigR = int.Parse(BigRLabel.Text);
            SmallR = int.Parse(SmallRlabel.Text);
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            каскадомToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            слеваНаправоToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сверхуВнизToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            упорядочитьЗначкиToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmAbout = new AboutForm();
            frmAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DocumentForm();
            frm.MdiParent = this;
            frm.Show();
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            каскадомToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            слеваНаправоToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сверхуВнизToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            упорядочитьЗначкиToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void рисунокToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Blue;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Green;
        }

        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                Color = cd.Color;
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Canvasfrm = new CanvasSizeForm();
            Canvasfrm.ShowDialog();
            ((DocumentForm)ActiveMdiChild).bmp = new Bitmap(((DocumentForm)ActiveMdiChild).bmp,new Size(Canvasfrm.Width,Canvasfrm.Height));
            ActiveMdiChild.Size = new Size(Canvasfrm.Width, Canvasfrm.Height);
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((DocumentForm)ActiveMdiChild).IsSaved == false)
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
                    ((DocumentForm)ActiveMdiChild).Path = dlg.FileName;
                    ((DocumentForm)ActiveMdiChild).IsSaved = true;
                    ((DocumentForm)ActiveMdiChild).Changed = false;
                }
            }
            else
            {
                ((DocumentForm)ActiveMdiChild).Changed = false;
                ((DocumentForm)ActiveMdiChild).bmp.Save(((DocumentForm)ActiveMdiChild).Path);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
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
                ((DocumentForm)ActiveMdiChild).Path = dlg.FileName;
                ((DocumentForm)ActiveMdiChild).IsSaved = true;
                ((DocumentForm)ActiveMdiChild).Changed = false;
            }
        }
        public Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();

        private void окноToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            каскадомToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            слеваНаправоToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сверхуВнизToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            упорядочитьЗначкиToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void файлToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Все файлы ()*.*|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                {
                    var frm = new DocumentForm();
                    frm.MdiParent = this;
                    frm.bmp = new Bitmap(s);
                    frm.Show();
                    frm.Text = dlg.Title;
                    frm.Path = dlg.FileName;
                    char[] space = new char[1];
                    space[0] = '\\';
                    string[] Adress = dlg.FileName.Split(space);
                    ActiveMdiChild.Text = Adress[Adress.Length - 1];
                    ActiveMdiChild.Text=Adress[Adress.Length-1];
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void SizeDecButton_Click(object sender, EventArgs e)
        {
            if (Width > 1)
            {
                Width--;
                TSL_of_Size.Text = Width.ToString();
            }
        }

        private void SizeIncButton_Click(object sender, EventArgs e)
        {
            Width++;
            TSL_of_Size.Text = Width.ToString();
        }

        private void TSCB_of_pen_TextChanged(object sender, EventArgs e)
        {
            NameofStick = TSCB_of_pen.Text;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (!((DocumentForm)ActiveMdiChild).IsSaved)
                {
                    var msb = MessageBox.Show("Ваш рисунок " + ((DocumentForm)MdiChildren[i]).Text + " не сохранён.\nСохранить?", "Сохранение", MessageBoxButtons.YesNoCancel);
                    if (DialogResult.Cancel == msb)
                    {
                        i = MdiChildren.Length;
                        e.Cancel = true;
                    }
                    else
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
                            ((DocumentForm)MdiChildren[i]).Path = dlg.FileName;
                            ((DocumentForm)MdiChildren[i]).IsSaved = true;
                            ((DocumentForm)MdiChildren[i]).Changed = false;
                            ((DocumentForm)MdiChildren[i]).Close();
                        }
                        else
                            ((DocumentForm)ActiveMdiChild).Close();
                    }
                    else
                        ((DocumentForm)ActiveMdiChild).Close();
                }
                else
                if (((DocumentForm)MdiChildren[i]).Changed == true)
                {
                    var msb = MessageBox.Show("Ваш рисунок " + ((DocumentForm)MdiChildren[i]).Text + " Сохранён, но был изменён.\nСохранить изменения?", "Сохранение", MessageBoxButtons.YesNoCancel);
                    if (msb == DialogResult.OK)
                    {
                        ((DocumentForm)ActiveMdiChild).bmp.Save(((DocumentForm)ActiveMdiChild).Path);
                        ((DocumentForm)MdiChildren[i]).Changed = false;
                        ((DocumentForm)ActiveMdiChild).Close();
                    }
                    else
                    {
                        if (msb == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            i = MdiChildren.Length;
                        }
                        else
                        ((DocumentForm)ActiveMdiChild).Close();
                    }
                }
            }
        }

        private void DecN_Click(object sender, EventArgs e)
        {
            if (StarN > 2)
            {
                StarPiesNum.Text = (int.Parse(StarPiesNum.Text) - 1).ToString();
                StarN--;
            }
        }

        private void IncN_Click(object sender, EventArgs e)
        {
            StarPiesNum.Text = (int.Parse(StarPiesNum.Text) + 1).ToString();
            StarN++;
        }

        private void Incr_Click(object sender, EventArgs e)
        {
            if (SmallR < BigR - 1)
            {
                SmallRlabel.Text = (int.Parse(SmallRlabel.Text) + 1).ToString();
                SmallR++;
            }
        }

        private void Decr_Click(object sender, EventArgs e)
        {
            if (SmallR > 1)
            {
                SmallRlabel.Text = (int.Parse(SmallRlabel.Text) - 1).ToString();
                SmallR--;
            }
        }

        private void Inc_R_Click(object sender, EventArgs e)
        {
            BigRLabel.Text = (int.Parse(BigRLabel.Text) + 1).ToString();
            BigR++;
        }

        private void Dec_R_Click(object sender, EventArgs e)
        {
            if (BigR > SmallR + 1)
            {
                BigRLabel.Text = (int.Parse(BigRLabel.Text) - 1).ToString();
                BigR--;
            }
        }
    }
}
