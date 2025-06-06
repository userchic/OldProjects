﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary2
{
    public partial class RGBColor : UserControl
    {
        public Color color;
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
            if (CheckSymbol(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
            changeColor();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckSymbol(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
            changeColor();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckSymbol(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
            changeColor();
            
        }
        public bool CheckSymbol(char sym)
        {
            int num;
            if (sym.ToString() != "-")
            {
                if (sym != 8)
                {
                    if (checkBox1.Checked == true)
                    {
                        if (int.TryParse(sym.ToString(), out num))
                            return true;
                        else
                            return false;
                    }
                    else
                        if (int.TryParse(sym.ToString(), out num) || sym == 'A' || sym == 'B' || sym == 'C' || sym == 'D' || sym == 'E' || sym == 'F')
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
        public void RepairResult(ref string text)
        {
            try
            {
                if (text != "")
                {
                    if (checkBox1.Checked == true)
                    {
                        if (int.Parse(text) >= 256)
                            text = "255";
                    }
                    else
                    {
                        if (text.Length > 2)
                            text = text[0].ToString() + text[1].ToString();
                    }
                    changeColor();
                }
                else
                    text = "0";
            }
            catch { }
        }
        public void changeColor()
        {
            try
            {
                dataGridView1.BackgroundColor = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                color = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            }
            catch { }
        }
        public void TransformIn10()
        {
            int num = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                switch (textBox1.Text[i])
                {
                    case '0':
                        num = num * 16;
                        break;
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
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                switch (textBox2.Text[i])
                {
                    case '0':
                        num = num * 16;
                        break;
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
            for (int i = 0; i <textBox3.Text.Length; i++)
            {
                switch (textBox3.Text[i])
                {
                    case '0':
                        num = num * 16;
                        break;
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
                switch (num / 16)
                {
                    case 0:
                        text += "0";
                        break;
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
            switch (num % 16)
            {
                case 0:
                    text += "0";
                    break;
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
            textBox1.Text = text;
            text = "";
            num = int.Parse(textBox2.Text);
            switch (num / 16)
            {
                case 0:
                    text += "0";
                    break;
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
            switch (num % 16)
            {
                case 0:
                    text += "0";
                    break;
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
            textBox2.Text = text;
            text = "";
            num = int.Parse(textBox3.Text);
            switch (num / 16)
            {
                case 0:
                    text += "0";
                    break;
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
            switch (num % 16)
            {
                case 0:
                    text += "0";
                    break;
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
            textBox3.Text = text;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void RGBColor_Load(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            color = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            RepairResult(ref text);
            textBox1.Text = text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            RepairResult(ref text);
            textBox2.Text = text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            RepairResult(ref text);
            textBox3.Text = text;
        }

        private void checkBox2_Click(object sender, EventArgs e)
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

        private void checkBox1_Click(object sender, EventArgs e)
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
    }
}
