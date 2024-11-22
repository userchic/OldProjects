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
    public partial class Form2 : Form
    {
        //public Stopwatch T;
        public string Alg, graf, lengt;
       
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            this.Text = Alg;
            label6.Text = graf;
            label7.Text = lengt;
        }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
