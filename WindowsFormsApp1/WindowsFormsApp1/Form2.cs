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
    public partial class Form2 : Form
    {
        static string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
        public List<List<string>> Ganta;
        public List<List<int>> Workers;
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            for (int j = 1; j < Ganta[0].Count; j++)
                dataGridView1.Columns.Add("columna", (j + 1) + " Шаг");
            for (int i = 1; i < Ganta.Count; i++)
                dataGridView1.Rows.Add();
            for (int i = 0; i < Ganta.Count; i++)
            {
                for (int j = 0; j < Ganta[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = letters[int.Parse(Ganta[i][j])-1]+"="+Workers[i][j];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
