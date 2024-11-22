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
    public partial class FormChange2 : Form
    {
        public string Label;
        public FormChange2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormChange2_Shown(object sender, EventArgs e)
        {

        }
    }
}
