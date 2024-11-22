using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class RGBColor : UserControl
    {
        public int rot { get; set; }
        public int grun { get; set; }
        public int blue { get; set; }
        public RGBColor()
        {
            InitializeComponent();
        }
        static bool Checknum(int num, int cifra)
        {
            if (num * 10 + cifra < 256)
                return true;
            else
                return false;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            if (checkBox1.Checked == true)
            {
                if (Checknum(int.Parse(textBox1.Text), int.Parse(e.KeyChar.ToString())))
                {
                    Validate();
                    rot = int.Parse(textBox1.Text);
                }
            }
            else
            {
                if (textBox1.Text.Length < 2)
                {
                    if (int.TryParse(e.KeyChar.ToString(), out i) || e.KeyChar == 'A' || e.KeyChar == 'B' || e.KeyChar == 'C' || e.KeyChar == 'D' || e.KeyChar == 'E' || e.KeyChar == 'F')
                    {
                        Validate();
                        rot = int.Parse(textBox1.Text);
                    }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            if (checkBox1.Checked == true)
            {
                if (Checknum(int.Parse(textBox2.Text), int.Parse(e.KeyChar.ToString())))
                {
                    Validate();
                    grun = int.Parse(textBox1.Text);
                }
            }
            else
            {
                if (textBox2.Text.Length < 2)
                {
                    if (int.TryParse(e.KeyChar.ToString(), out i) || e.KeyChar == 'A' || e.KeyChar == 'B' || e.KeyChar == 'C' || e.KeyChar == 'D' || e.KeyChar == 'E' || e.KeyChar == 'F')
                    {
                        Validate();
                        grun = int.Parse(textBox1.Text);
                    }
                }
            }
            changeColor();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            if (checkBox1.Checked == true)
            {
                if (Checknum(int.Parse(textBox3.Text), int.Parse(e.KeyChar.ToString())))
                {
                    Validate();
                    blue = int.Parse(textBox1.Text);
                }
            }
            else
            {
                if (textBox3.Text.Length < 2)
                {
                    if (int.TryParse(e.KeyChar.ToString(), out i) || e.KeyChar == 'A' || e.KeyChar == 'B' || e.KeyChar == 'C' || e.KeyChar == 'D' || e.KeyChar == 'E' || e.KeyChar == 'F')
                    {
                        Validate();
                        blue = int.Parse(textBox1.Text);
                    }
                }
            }
            changeColor();
        }
        public void changeColor()
        {
            if (checkBox1.Checked == true)
                pictureBox1.BackColor = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            else
                pictureBox1.BackColor = Color.FromArgb(Int32.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber), Int32.Parse(textBox2.Text, System.Globalization.NumberStyles.HexNumber), Int32.Parse(textBox3.Text, System.Globalization.NumberStyles.HexNumber));
        }
        public void TransformIn10()
        {
            int num = 0;
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                switch (textBox1.Text[i])
                {
                    case '1':
                        num = num * 16 + 1;
                        break;
                    case '2':
                        num = num * 16 + 2;
                        break;
                    case '3':
                        num = num * 16 + 3;
                        break;
                    case '4':
                        num = num * 16 + 4;
                        break;
                    case '5':
                        num = num * 16 + 5;
                        break;
                    case '6':
                        num = num * 16 + 6;
                        break;
                    case '7':
                        num = num * 16 + 7;
                        break;
                    case '8':
                        num = num * 16 + 8;
                        break;
                    case '9':
                        num = num * 16 + 9;
                        break;
                    case 'A':
                        num = num * 16 + 10;
                        break;
                    case 'B':
                        num = num * 16 + 11;
                        break;
                    case 'C':
                        num = num * 16 + 12;
                        break;
                    case 'D':
                        num = num * 16 + 13;
                        break;
                    case 'E':
                        num = num * 16 + 14;
                        break;
                    case 'F':
                        num = num * 16 + 15;
                        break;
                }
            }
            textBox1.Text = num.ToString();
            num = 0;
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                switch (textBox1.Text[i])
                {
                    case '1':
                        num = num * 16 + 1;
                        break;
                    case '2':
                        num = num * 16 + 2;
                        break;
                    case '3':
                        num = num * 16 + 3;
                        break;
                    case '4':
                        num = num * 16 + 4;
                        break;
                    case '5':
                        num = num * 16 + 5;
                        break;
                    case '6':
                        num = num * 16 + 6;
                        break;
                    case '7':
                        num = num * 16 + 7;
                        break;
                    case '8':
                        num = num * 16 + 8;
                        break;
                    case '9':
                        num = num * 16 + 9;
                        break;
                    case 'A':
                        num = num * 16 + 10;
                        break;
                    case 'B':
                        num = num * 16 + 11;
                        break;
                    case 'C':
                        num = num * 16 + 12;
                        break;
                    case 'D':
                        num = num * 16 + 13;
                        break;
                    case 'E':
                        num = num * 16 + 14;
                        break;
                    case 'F':
                        num = num * 16 + 15;
                        break;
                }
            }
            textBox2.Text = num.ToString();
            num = 0;
            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                switch (textBox3.Text[i])
                {
                    case '1':
                        num = num * 16 + 1;
                        break;
                    case '2':
                        num = num * 16 + 2;
                        break;
                    case '3':
                        num = num * 16 + 3;
                        break;
                    case '4':
                        num = num * 16 + 4;
                        break;
                    case '5':
                        num = num * 16 + 5;
                        break;
                    case '6':
                        num = num * 16 + 6;
                        break;
                    case '7':
                        num = num * 16 + 7;
                        break;
                    case '8':
                        num = num * 16 + 8;
                        break;
                    case '9':
                        num = num * 16 + 9;
                        break;
                    case 'A':
                        num = num * 16 + 10;
                        break;
                    case 'B':
                        num = num * 16 + 11;
                        break;
                    case 'C':
                        num = num * 16 + 12;
                        break;
                    case 'D':
                        num = num * 16 + 13;
                        break;
                    case 'E':
                        num = num * 16 + 14;
                        break;
                    case 'F':
                        num = num * 16 + 15;
                        break;
                }
            }
            textBox3.Text = num.ToString();
        }
        public void TransformIn16()
        {
            string text = "";
            int num = int.Parse(textBox1.Text);
            while (num > 0)
            {
                switch (num / 16)
                {
                    case 1:
                        text += "1";
                        break;
                    case 2:
                        text += "2";
                        break;
                    case 3:
                        text += "3";
                        break;
                    case 4:
                        text += "4";
                        break;
                    case 5:
                        text += "5";
                        break;
                    case 6:
                        text += "6";
                        break;
                    case 7:
                        text += "7";
                        break;
                    case 8:
                        text += "8";
                        break;
                    case 9:
                        text += "9";
                        break;
                    case 10:
                        text += "A";
                        break;
                    case 11:
                        text += "B";
                        break;
                    case 12:
                        text += "C";
                        break;
                    case 13:
                        text += "D";
                        break;
                    case 14:
                        text += "E";
                        break;
                    case 15:
                        text += "F";
                        break;
                }
                num = num % 16;
            }
            textBox1.Text = text;
            text = "";
            num = int.Parse(textBox2.Text);
            while (num > 0)
            {
                switch (num / 16)
                {
                    case 1:
                        text += "1";
                        break;
                    case 2:
                        text += "2";
                        break;
                    case 3:
                        text += "3";
                        break;
                    case 4:
                        text += "4";
                        break;
                    case 5:
                        text += "5";
                        break;
                    case 6:
                        text += "6";
                        break;
                    case 7:
                        text += "7";
                        break;
                    case 8:
                        text += "8";
                        break;
                    case 9:
                        text += "9";
                        break;
                    case 10:
                        text += "A";
                        break;
                    case 11:
                        text += "B";
                        break;
                    case 12:
                        text += "C";
                        break;
                    case 13:
                        text += "D";
                        break;
                    case 14:
                        text += "E";
                        break;
                    case 15:
                        text += "F";
                        break;
                }
                num = num % 16;
            }
            textBox2.Text = text;
            text = "";
            num = int.Parse(textBox3.Text);
            while (num > 0)
            {
                switch (num / 16)
                {
                    case 1:
                        text += "1";
                        break;
                    case 2:
                        text += "2";
                        break;
                    case 3:
                        text += "3";
                        break;
                    case 4:
                        text += "4";
                        break;
                    case 5:
                        text += "5";
                        break;
                    case 6:
                        text += "6";
                        break;
                    case 7:
                        text += "7";
                        break;
                    case 8:
                        text += "8";
                        break;
                    case 9:
                        text += "9";
                        break;
                    case 10:
                        text += "A";
                        break;
                    case 11:
                        text += "B";
                        break;
                    case 12:
                        text += "C";
                        break;
                    case 13:
                        text += "D";
                        break;
                    case 14:
                        text += "E";
                        break;
                    case 15:
                        text += "F";
                        break;
                }
                num = num % 16;
            }
            textBox3.Text = text;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
                TransformIn10();
            }
            else
            {
                checkBox2.Checked = true;
                TransformIn16();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
                TransformIn16();
            }
            else
            {
                checkBox1.Checked = true;
                TransformIn10();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
