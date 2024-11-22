using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        Mutex locker = new Mutex();
        Random rand = new Random();
        static Semaphore bulletsem = new Semaphore(3,3);
        public int hit = 0;
        public int miss = 0;
        string badchar = "-\\|/";
        public int x = 40;
        public int y = 24;
        delegate void Handler();
        event Handler Change;
        public Form1()
        {
            InitializeComponent();
            for (int i=0;i<80;i++)
            dataGridView1.Columns.Add("Column"+(i+1),"");
            for (int i = 0; i < 80; i++)
                dataGridView1.Columns[i].Width = 15;
            for (int i=0;i<25;i++)
                    dataGridView1.Rows.Add();
            dataGridView1[x, y].Value = '|';
            score();
            Thread thr = new Thread(badguys);
            thr.Start();
            Change += Changemethod;
        }
        public void Changemethod()
        {
            label2.Text = "Попадания: " + hit;
            label3.Text = "Ушедшие: " + miss;
        }
        public void writeat(int x,int y,char symbol)
        {
            locker.WaitOne(0xFFFFFFF);
                dataGridView1[x, y].Value = symbol;
            locker.ReleaseMutex();
        }
        private void bullet()
        {
            int xx, yy;
            xx = x;
            yy = y;
            if (dataGridView1[xx, yy].Value.ToString() == "*") return;
            if (bulletsem.WaitOne(0) == false) return;
            while (--yy>0)
            {
                //dataGridView1[xx, yy].Value = "*";
                writeat(xx, yy, '*');
                Thread.Sleep(100);
                writeat(xx, yy, ' ');
                //dataGridView1[xx, yy].Value = "";
            }
            bulletsem.Release();
        }
        private void badguys()
        {
            while(true)
            {
                if (rand.Next(0, 100) < (hit + miss) / 25 + 20)
                {
                    Thread thr = new Thread(badguy);
                    thr.Start();
                }
                Thread.Sleep(1000);
            }
        }

        private void badguy()
        {
            try {
            int y = rand.Next(1, 10);
            int dir;
            int x;
            x = y % 2 == 0 ? 0 : 79;
            dir = x != 0 ? -1 : 1;
            while ((dir == 1 && x != 79) || (dir == -1 && x != 0))
            {
                int dly;
                bool hitme = false;
                writeat(x, y, badchar[x % 4]);
                //dataGridView1[x, y].Value = badchar[x % 4];
                for (int i = 0; i < 15; i++)
                {
                    Thread.Sleep(40);
                    if (dataGridView1[x, y].Value.ToString() == "*")
                    {
                        hitme = true;
                        break;
                    }
                }
                writeat(x, y, ' ');
                //dataGridView1[x, y].Value = " ";
                if (hitme)
                {
                    throw new ThreadInterruptedException();
                }
                x += dir;
            }

        }
        catch
            {
                miss++;
                score();
            }
        }
        private void score()
        {
            Change?.Invoke();
            if (miss>=30)
            {
                MessageBox.Show("Игра окончена.  %%Война потоков%% ");
                Close();
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            writeat(x, y, ' ');
            //dataGridView1[x, y].Value = ' ';
            x--;
            writeat(x, y, '|');
            //dataGridView1[x, y].Value = '|';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(bullet);
            thr.Start();
            Thread.Sleep(100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeat(x, y, ' ');
            //dataGridView1[x, y].Value = ' ';
            x++;
            writeat(x, y, '|');
            //dataGridView1[x, y].Value = '|';
        }
    }
}
