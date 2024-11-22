using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class Rating : Form
    {
        static QuestionContext db = new QuestionContext();
        public Rating()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Rating_Shown(object sender, EventArgs e)
        {
            var tops=
            from Players in db.Players
            orderby Players.Result descending
            select Players;
            int i = 0;
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            foreach (Player p in tops)
            {
                dataGridView1.Rows[i].Cells[0].Value = p.Name;
                dataGridView1.Rows[i].Cells[1].Value = p.GoldenSum;
                dataGridView1.Rows[i].Cells[2].Value = p.Result;
                i++;
            }    
        }
    }
}
