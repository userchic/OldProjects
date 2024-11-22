using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormChange3 : Form
    {
        public string Studnam, Surname,Label;

        private void FormChange3_Shown(object sender, EventArgs e)
        {
            label4.Text = Label;
        }

        public FormChange3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Studnam = textBox1.Text;
            Surname = textBox2.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
