using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Random rond = new Random();
        Graph g;
        int MaxPoints = 10;
        int MinPoints = 3;
        int CellWidth=30;
        float lengK ;
        float FeromK;
        int AntsNum;
        int Iters;
        int Feromon;
        float AntsFeromon;
        int FeromonDec;
        List<int> AntsPoss = new List<int>(3);
        public Form1()
        {
            InitializeComponent();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= MinPoints)
            {
                if (numericUpDown1.Value > MaxPoints)
                {
                    MessageBox.Show($"Ошибка, кол-во вершин не может быть больше {MaxPoints}", "Создание графа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numericUpDown1.Value = MaxPoints;
                }
            }
            else
            {
                MessageBox.Show($"Ошибка, кол-во вершин не может быть меньше {MinPoints}", "Создание графа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Value = MinPoints;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = 1;
            g = new Graph((int)numericUpDown1.Value);
            g.ChangedGraph += g.RepairNames;
            MessageBox.Show("Граф создан", "Создание графа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateTables();
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            AntsPoss.Add(1);
            AntsPoss.Add(2);
            AntsPoss.Add(3);
            lengK = 1;
            FeromK = 1;
            AntsNum = 3;
            Iters = 3;
            Feromon = 1;
            AntsFeromon = 1;
            FeromonDec = 5;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox1.Text))
            {
                if (comboBox1.Text == "с заданным массивом расстояний")
                    dataGridView1.Enabled = true;
                if (comboBox1.Text == "с расстояниями 1")
                    dataGridView1.Enabled = false;
                if (comboBox1.Text == "с массивом расстояний заполненным ДСЧ")
                    dataGridView1.Enabled = false;
            }
            else
            {
                button2.Enabled = false;
                dataGridView1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g.Points.Count < MaxPoints)
            {
                if (comboBox1.Text == "с заданным массивом расстояний")
                {
                    List<int> Dist = new List<int>(g.Points.Count + 1);
                    for (int i = 0; i < g.Points.Count + 1; i++)
                    {
                        int number = 0;
                        if (dataGridView1[i, 0].Value != "-")
                        {
                            number = int.Parse(dataGridView1[i, 0].Value.ToString());
                            Dist.Add(number);
                        }
                        else
                            Dist.Add(0);
                    }
                    g.AddPoint(Dist);
                }
                if (comboBox1.Text == "с расстояниями 1")
                {
                    g.AddPoint();
                }
                if (comboBox1.Text == "с массивом расстояний из ДСЧ")
                {
                    List<int> Dist = new List<int>(g.Points.Count + 1);
                    for (int i = 0; i < g.Points.Count; i++)
                    {
                        Dist.Add(rond.Next(1, 50));
                    }
                    Dist.Add(0);
                    g.AddPoint(Dist);
                }
                UpdateTables();
            }
            else
                MessageBox.Show("Добавление не выполнено, достигнуто максимальное кол-во вершин", "Добавление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool buf;
            int num;
            if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = "-";
            else
            {
                buf = int.TryParse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), out num);
                if (!buf)
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = 1;
                }
                else
                {
                        num = int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
                        if (num < 0)
                            num = -num;
                        if (num == 0)
                            num = 1;
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = num;
                }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void UpdateTables()
        {
            while ((dataGridView1.Columns.Count != g.Points.Count + 1) || (dataGridView2.Columns.Count != g.Points.Count))
            {
                if (dataGridView1.Columns.Count < g.Points.Count + 1)
                {
                    dataGridView1.Columns.Add($"Column{dataGridView1.Columns.Count + 1}", (dataGridView1.Columns.Count + 1).ToString());
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = CellWidth;
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].ReadOnly = false;
                    if (dataGridView1.Rows.Count == 0)
                        dataGridView1.Rows.Add();
                    dataGridView1[dataGridView1.Columns.Count - 1, 0].Value = "1";
                }
                if (dataGridView2.Columns.Count < g.Points.Count)
                {
                    dataGridView2.Columns.Add($"Column{dataGridView2.Columns.Count + 1}", (dataGridView2.Columns.Count + 1).ToString());
                    dataGridView2.Columns[dataGridView2.Columns.Count - 1].Width = CellWidth;
                    dataGridView2.Columns[dataGridView2.Columns.Count - 1].ReadOnly = false;
                    if (dataGridView2.Rows.Count == 0)
                        dataGridView2.Rows.Add();
                    dataGridView2[dataGridView2.Columns.Count - 1, 0].Value = 1.ToString();
                }
                if (dataGridView1.Columns.Count > g.Points.Count + 1)
                {
                    dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                }
                if (dataGridView2.Columns.Count > g.Points.Count)
                {
                    dataGridView2.Columns.RemoveAt(dataGridView2.Columns.Count - 1);
                }
            }
            dataGridView1[dataGridView1.Columns.Count - 1, dataGridView1.Rows.Count - 1].Value = "-";
            dataGridView2[dataGridView2.Columns.Count - 1, dataGridView2.Rows.Count - 1].Value = "-";
            while (dataGridView3.Rows.Count != g.Points.Count)
            {
                if (dataGridView3.Rows.Count < g.Points.Count)
                {
                    dataGridView3.Columns.Add($"Column{(dataGridView3.Columns.Count)}", (dataGridView3.Columns.Count).ToString());
                    dataGridView3.Columns[dataGridView3.Columns.Count - 1].ReadOnly = false;
                    dataGridView3.Rows.Add();
                    dataGridView3.Columns[dataGridView3.Columns.Count - 1].Width = CellWidth;
                }
                if (dataGridView3.Rows.Count > g.Points.Count)
                {
                    dataGridView3.Rows.RemoveAt(dataGridView3.Rows.Count - 1);
                    dataGridView3.Columns.RemoveAt(dataGridView3.Columns.Count - 1);
                }
            }
            for (int i = 0; i < g.Points.Count; i++)
            {
                dataGridView3[0, i].Value = i + 1;
                for (int j = 0; j < g.Points.Count; j++)
                {
                    if (i != j)
                        dataGridView3[i + 1, j].Value = g.Points[i].Distance[j];
                    else
                        dataGridView3[i + 1, j].Value = "-";
                }
            }
            label7.Text = $"Вершин:{g.Points.Count}";
            for (int i=0;i<g.Points.Count+1;i++)
            {
                if (dataGridView1[i, 0].Value == "-" && i != g.Points.Count)
                    dataGridView1[i, 0].Value = 1;
            }
            for (int i=0;i<g.Points.Count;i++)
            {
                if (dataGridView2[i, 0].Value == "-" && i != g.Points.Count-1)
                    dataGridView2[i, 0].Value = 1;
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value >0 )
            {
                if (numericUpDown2.Value > g.Points.Count)
                {
                    MessageBox.Show($"Ошибка, номер вершины не может быть больше кол-ва вершин", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numericUpDown2.Value = g.Points.Count;
                }
            }
            else
            {
                MessageBox.Show($"Ошибка, номер вершины не может быть 0 и меньше 0", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown2.Value = 1;
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool buf;
            int num;
            if (dataGridView2[e.ColumnIndex, e.RowIndex].Value != "")
            {
                buf = int.TryParse(dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString(), out num);
                if (!buf)
                {
                    string Line = (string)dataGridView2[e.ColumnIndex, e.RowIndex].Value;
                    if (Line != "-")
                        dataGridView2[e.ColumnIndex, e.RowIndex].Value = 1;
                }
                else
                {
                    num = int.Parse(dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString());
                    if (num < 0)
                        num = -num;
                    if (num == 0)
                        num = 1;
                    dataGridView2[e.ColumnIndex, e.RowIndex].Value = num;
                }
            }
            else
                dataGridView2[e.ColumnIndex, e.RowIndex].Value = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (g.Points.Count > MinPoints)
            {
                if (comboBox2.Text == "По номеру")
                {
                    g.DeletePoint((int)numericUpDown2.Value);
                    UpdateTables();
                    if ((int)numericUpDown2.Value>dataGridView2.ColumnCount)
                    {
                        numericUpDown2.Value = dataGridView2.ColumnCount;
                    }
                }
                if (comboBox2.Text == "По массиву расстояний")
                {
                    bool buf;
                    List<int> l = new List<int>(dataGridView2.Rows.Count);
                    int num = 0;
                    int flag = 0;
                    int pointnum=0;
                    int FlagOfScrum = 0;
                    List<int> ScrummedPoints = new List<int>();
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        if (int.TryParse(dataGridView2[i, 0].Value.ToString(), out num))
                        {
                            num = int.Parse(dataGridView2[i, 0].Value.ToString());
                            l.Add(num);
                        }
                        else
                        if (dataGridView2[i, 0].Value.ToString() == "-")
                        {
                            l.Add(0);
                            flag++;
                            pointnum = i + 1;
                        }
                        else
                        {
                            FlagOfScrum=1;
                            ScrummedPoints.Add(i + 1);
                        }
                    }
                    if (FlagOfScrum == 1)
                    {
                        MessageBox.Show($"Ошибка, в массиве расстояний не может быть других символов кроме цифр", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        for (int i = 0; i < ScrummedPoints.Count; i++)
                        {
                            dataGridView2[ScrummedPoints[i]-1, 0].Value = 1;
                        }
                    }
                    else
                    if (flag == 1)
                    {
                        l = new List<int>(l);
                        GraphPoint gp = new GraphPoint(pointnum, l);
                        buf = g.DeletePoint(gp);
                        if (buf == false)
                        {
                            MessageBox.Show($"Ошибка, такая вершина не найдена", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (flag == 0)
                            MessageBox.Show($"Ошибка, отсутствует символ '-' обозначающий расстояние от точки до неё самой", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (flag > 1)
                            MessageBox.Show($"Ошибка, нельзя указывать более одного символа '-' , расстояние от вершины до неё самой существует только 1", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                UpdateTables();
            }
            else
                MessageBox.Show($"Ошибка, кол-во вершин равно минимальному {MinPoints}, удаление невозможно", "Удаление вершины", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox2.Items.Contains(comboBox2.Text))
            {
                if (comboBox2.Text == "По номеру")
                {
                    dataGridView2.Enabled = false;
                    numericUpDown2.Enabled = true;
                    button3.Enabled = true;
                }
                if (comboBox2.Text == "По массиву расстояний")
                {
                    dataGridView2.Enabled = true;
                    numericUpDown2.Enabled = false;
                    button3.Enabled = true;
                }
            }
            else
            {
                button3.Enabled = false;
                dataGridView2.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Contains(comboBox2.Text))
            {
                if (comboBox2.Text == "По номеру")
                {
                    dataGridView2.Enabled = false;
                    numericUpDown2.Enabled = true;
                    button3.Enabled = true;
                }
                if (comboBox2.Text == "По массиву расстояний")
                {
                    dataGridView2.Enabled = true;
                    numericUpDown2.Enabled = false;
                    button3.Enabled = true;
                }
            }
            else
            {
                button3.Enabled = false;
                dataGridView2.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex-1 == e.RowIndex)
                    dataGridView3[e.ColumnIndex, e.RowIndex].Value = "-";
                else
                { 
                    int num;
                    bool buf = int.TryParse(dataGridView3[e.ColumnIndex, e.RowIndex].Value.ToString(), out num);
                    if (num > 0)
                    {
                        if (buf)
                        {
                            g.ChangeDistance(e.ColumnIndex - 1, e.RowIndex, num);
                            dataGridView3[e.RowIndex + 1, e.ColumnIndex - 1].Value = dataGridView3[e.ColumnIndex, e.RowIndex].Value;
                        }
                        else
                        {
                            MessageBox.Show($"Ошибка, ячейки матрицы расстояний могут содержать только целые числа", "Изменение расстояния", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            g.ChangeDistance(e.ColumnIndex - 1, e.RowIndex, 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка, ячейки матрицы расстояний могут содержать только целые положительные числа", "Изменение расстояния", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView3[e.RowIndex+1, e.ColumnIndex-1].Value = 1;
                        dataGridView3[e.ColumnIndex, e.RowIndex].Value = 1;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> result;
            g.AntsAlgoritmSolve(out result,Iters,AntsNum,AntsPoss,Feromon,AntsFeromon,FeromonDec/100,FeromK,lengK);
            Form2 form2 = new Form2();
            form2.Alg = "Муравьиный алгоритм";
            string resultat="";
            foreach (int elem in result)
                resultat += elem.ToString()+" ";
            form2.graf = resultat.ToString();
            form2.lengt = g.EstimateLength(result).ToString();
            form2.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.lengK = lengK;
            form3.FeromK = FeromK;
            form3.AntsNum = AntsNum;
            form3.Iter = Iters;
            form3.Feromon = Feromon;
            form3.FeromonDec = FeromonDec;
            form3.AntsFeromon = AntsFeromon;
            form3.AntsPoss = AntsPoss;
            form3.g1 = g;
            form3.ShowDialog();
            lengK=form3.lengK;
            FeromK=form3.FeromK;
            AntsNum=form3.AntsNum;
            Iters=form3.Iter;
            Feromon=form3.Feromon;
            FeromonDec=form3.FeromonDec;
            AntsFeromon=form3.AntsFeromon;
            AntsPoss=new List<int>(form3.AntsPoss);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> result=g.EnumerationSolve();
            Form2 form2 = new Form2();
            form2.Alg = "Полный перебор";
            string resultat="";
            foreach (int elem in result)
                resultat += elem.ToString() + " ";
            form2.graf = resultat;
            form2.lengt = g.EstimateLength(result).ToString();
            form2.ShowDialog();
        }
    }
}