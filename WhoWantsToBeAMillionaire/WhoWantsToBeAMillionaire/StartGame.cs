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
    public partial class StartGame : Form
    {
        public string name;
        public int spSum;
        static QuestionContext db = new QuestionContext();
        public StartGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            spSum = int.Parse(comboBox1.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rating form = new Rating();
            form.ShowDialog();
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Items.Contains(comboBox1.Text))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Items.Contains(comboBox1.Text))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Items.Contains(comboBox1.Text))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
