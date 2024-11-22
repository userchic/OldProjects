using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Graph g1;
        public float lengK;
        public float FeromK;
        public int AntsNum;
        public int Iter;
        public int Feromon;
        public int FeromonDec;
        public float AntsFeromon;
        public List<int> AntsPoss;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1)
                numericUpDown1.Value = 1;
            if (numericUpDown1.Value > 10)
                numericUpDown1.Value = 10;
            if (dataGridView1.Rows.Count == 0)
                dataGridView1.Rows.Add();
            AntsNum = (int)numericUpDown1.Value;
            while (dataGridView1.Columns.Count!=AntsNum)
            {
                if (dataGridView1.Columns.Count<AntsNum)
                {
                    dataGridView1.Columns.Add("Column1", $"{AntsNum}");
                    dataGridView1[dataGridView1.Columns.Count - 1, 0].Value = 1;
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 30;
                }
                if (dataGridView1.Columns.Count>AntsNum)
                {
                    dataGridView1.Columns.RemoveAt(AntsNum);
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 30;
                }
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            numericUpDown1.Value = AntsNum;
            numericUpDown2.Value = Iter;
            textBox3.Text = lengK.ToString();
            textBox1.Text = FeromK.ToString();
            numericUpDown5.Value = Feromon;
            numericUpDown3.Value = FeromonDec;
            textBox2.Text = AntsFeromon.ToString();

            while (dataGridView1.Columns.Count!=AntsPoss.Count)
            {
                if (dataGridView1.Columns.Count < AntsPoss.Count)
                    dataGridView1.Columns.Add("Column",$"{dataGridView1.Columns.Count+1}");
                if (dataGridView1.Columns.Count > AntsPoss.Count)
                    dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
            }
            if (dataGridView1.Rows.Count == 0)
                dataGridView1.Rows.Add();
            for (int i=0;i<dataGridView1.Columns.Count;i++)
            {
                dataGridView1[i,0].Value = AntsPoss[i];
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value < 1)
                numericUpDown2.Value = 1;
            if (numericUpDown2.Value > 5)
                numericUpDown2.Value = 5;
            Iter = (int)numericUpDown2.Value;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool buf;
            int num;
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                buf = int.TryParse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), out num);
                if (!buf)
                {
                    MessageBox.Show($"Ошибка, позиция муравья не может содержать символы кроме цифр", "Изменение позиции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = 1;
                }
                else
                    if (int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()) <= 0 || (int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()) > g1.Points.Count))
                {
                    if (int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()) <= 0)
                    {
                        MessageBox.Show($"Ошибка, позиция муравья меньше 0. Позиция муравья - целое положительное число", "Изменение позиции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = 1;
                    }
                    if (int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()) > g1.Points.Count)
                    {
                        MessageBox.Show($"Ошибка, позиция муравья указывает на несуществующую вершину", "Изменение позиции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = g1.Points.Count;
                    }
                }
            }
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown5.Value < 1)
                numericUpDown5.Value = 0;
            Feromon = (int)numericUpDown5.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value > 99)
                numericUpDown3.Value = 99;
            FeromonDec = (int)numericUpDown3.Value;
        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar.ToString() == "," && textBox1.Text.IndexOf(',') == -1))
            {
                e.Handled = true;
                lengK = int.Parse(textBox3.Text);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar.ToString() == "," && textBox1.Text.IndexOf(',') == -1))
            {
                e.Handled = true;
                AntsFeromon = int.Parse(textBox2.Text);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar.ToString() == "," && textBox1.Text.IndexOf(',') == -1))
            {
                e.Handled = true;
                FeromK = int.Parse(textBox1.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            lengK = int.Parse(textBox3.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FeromK = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AntsFeromon = int.Parse(textBox2.Text);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<int> L = new List<int>(dataGridView1.Columns.Count);
            for (int i = 0; i < L.Capacity; i++)
            {
                int num = int.Parse(dataGridView1[i,0].Value.ToString());
                L.Add(num);
            }
            AntsPoss = new List<int>(L);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
