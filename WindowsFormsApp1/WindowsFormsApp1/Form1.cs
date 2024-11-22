using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        static List<int> Workers;
        static List<int> Works;
        public Form1()
        {
            Workers = new List<int>(1);
            Workers.Add(1);
            Works = new List<int>(1);
            Works.Add(3);
            InitializeComponent();
            dataGridView1.Rows[0].Cells[0].Value = 1;
            dataGridView2.Rows[0].Cells[0].Value = 3;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&e.ColumnIndex>=0)
            Workers[e.ColumnIndex] = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&e.ColumnIndex>=0)
            Works[e.ColumnIndex] = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void randomizeWorks_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows[0].Cells.Count; i++)
                dataGridView2.Rows[0].Cells[i].Value = rand.Next(10, 30);
        }

        private void randimizeWorkers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Rows[0].Cells[i].Value = rand.Next(1, 10);
        }

        private void ImplyWorksButton_Click(object sender, EventArgs e)
        {
            List<List<int>> GantaNums = new List<List<int>>();
            List<List<string>>Gant=Algoritm(new List<int>(Workers), new List<int>(Works),ref GantaNums);
            Form2 frm = new Form2();
            frm.Ganta = Gant;
            frm.Workers = GantaNums;
            frm.Show();
        }
        static List<List<string>> Algoritm(List<int> Workers,List<int>Works,ref List<List<int>>GantaNums)
        {
            int LeftWorks = Works.Count;
            List<int> NumsOfWorks = new List<int>();
            List<List<string>> Ganta = new List<List<string>>();
            for (int i = 0; i < Workers.Count; i++)
            {
                Ganta.Add(new List<string>());
                GantaNums.Add(new List<int>());
            }
            while (LeftWorks > 0)
            {
                int[] WentThrough = new int[Works.Count];
                int[] WorkersWentThrough = new int[Workers.Count];
                for (int i = 0; i < Workers.Count; i++)
                {
                    int max = -1;
                    int maxnum=-1;
                    if (LeftWorks > 0)
                    {
                        for (int j=0;j<Works.Count;j++)
                        {
                            if (WentThrough[j]!=1&&max < Works[j])
                            {
                                max = Works[j];
                                maxnum = j;
                            }
                        }
                    }
                    int maxworker = -1;
                    int maxworkernum=-1;
                    for (int j=0;j<Workers.Count;j++)
                    {
                        if (WorkersWentThrough[j]!=1&maxworker<Workers[j])
                        {
                            maxworker = Workers[j];
                            maxworkernum = j;
                        }
                    }
                    if (max != -1)
                    {
                        Ganta[maxworkernum].Add((maxnum+1).ToString());
                        if (Works[maxnum]<maxworker)
                        GantaNums[maxworkernum].Add(Works[maxnum]);
                        else
                        GantaNums[maxworkernum].Add(Workers[maxworkernum]);
                        WentThrough[maxnum] = 1;
                        WorkersWentThrough[maxworkernum] = 1;
                        if (Works[maxnum]>maxworker)
                        Works[maxnum] -= maxworker;
                        else
                        {
                            Works[maxnum] = 0;
                            LeftWorks--;
                        }
                    }
                    else
                        Ganta[maxworkernum].Add("-");
                }
            }
            return Ganta;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            while (numericUpDown1.Value != dataGridView1.Columns.Count)
            {
                if (numericUpDown1.Value < dataGridView1.Columns.Count)
                    dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                else
                    if (numericUpDown1.Value > dataGridView1.Columns.Count)
                {
                    dataGridView1.Columns.Add("Columna", "Рабочий" + (dataGridView1.Columns.Count+1));
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 70;
                    Workers.Add(1);
                    dataGridView1.Rows[0].Cells[dataGridView1.Rows[0].Cells.Count-1].Value=1;
                }
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            while (numericUpDown2.Value != dataGridView2.Columns.Count)
            {
                if (numericUpDown2.Value < dataGridView2.Columns.Count)
                    dataGridView2.Columns.RemoveAt(dataGridView2.Columns.Count - 1);
                else
                    if (numericUpDown2.Value > dataGridView2.Columns.Count)
                {
                    dataGridView2.Columns.Add("Columna", "Работа" + (dataGridView2.Columns.Count+1));
                    dataGridView2.Columns[dataGridView2.Columns.Count - 1].Width = 60;
                    Works.Add(1);
                    dataGridView2.Rows[0].Cells[dataGridView2.Rows[0].Cells.Count - 1].Value = 3;
                }
            }

        }
    }
}
