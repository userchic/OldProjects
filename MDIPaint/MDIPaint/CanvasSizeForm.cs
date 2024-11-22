﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class CanvasSizeForm : Form
    {
        public int Width;
        public int Height;
        public CanvasSizeForm()
        {
            InitializeComponent();
        }

        private void CanvasSizeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Width = int.Parse(textBox1.Text);
            Height = int.Parse(textBox2.Text);
        }
    }
}
