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
    public partial class FriendsCall : Form
    {
        static Random rnd = new Random();
        public int RightAnswer,Level;
        public FriendsCall()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Мяу "+ label1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ведущий промолчал, он явно что-то знает но не хочет говорить!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int guess1 = RandomGolos(1);
            int guess2 = RandomGolos(2);
            int guess3 = RandomGolos(3);
            int guess4 = RandomGolos(4);
            if (guess1 > guess2)
            {
                if (guess3 > guess4)
                {
                    if (guess1 > guess3)
                        MessageBox.Show("Попробуй 1");
                    else
                        MessageBox.Show("Попробуй 3");
                }
                else
                {
                    if (guess1 > guess4)
                        MessageBox.Show("Попробуй 1");
                    else
                        MessageBox.Show("Попробуй 4");
                }
            }
            else
            {
                if (guess3 > guess4)
                {
                    if (guess2 > guess3)
                        MessageBox.Show("Попробуй 2");
                    else
                        MessageBox.Show("Попробуй 3");
                }
                else
                {
                    if (guess2 > guess4)
                        MessageBox.Show("Попробуй 2");
                    else
                        MessageBox.Show("Попробуй 4");
                }
            }
            Close();
        }
        public int RandomGolos(int num)
        {
            if (num == RightAnswer)
                return rnd.Next(40 - Level);
            else
                return rnd.Next(20);
        }
    }
}
