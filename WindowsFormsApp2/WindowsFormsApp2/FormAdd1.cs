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
    public partial class FormAdd1 : Form
    {
        public string Label;
        public FormAdd1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label = textBox1.Text;
            DialogResult=DialogResult.OK;
            Close();
        }

        private void FormAdd1_Shown(object sender, EventArgs e)
        {
            label1.Text = Label;
        }
    }
}
