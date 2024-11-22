using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class Form1 : Form
    {
        List<Question> questions = new List<Question>();
        private Random rnd = new Random();
        int level = 0;
        Question currentQuestion;
        int mistakes = 1;
        static QuestionContext db = new QuestionContext();
        public string PName="";
        public int GoldenSum = 0;
        public int Result=0;
        public Form1()
        {
            InitializeComponent();
            Database.SetInitializer(new QuestionDbInitializer());
            ReadFile();
            startGame();
        }

        private void ReadFile()
        {
            string path = @"Вопросы.txt";
            if (db.Questions.Select(x=>x).Count()==0)
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    questions.Add(new Question(line.Split('\t')));
                        db.Questions.Add(new Question(line.Split('\t')));
                }
                    db.SaveChanges();
            }
            else
            {
                var quests= db.Questions.Select(x => x);
                foreach (Question q in quests)
                questions.Add(q);
            }
        }
        private void ShowQuestion(Question q)
        {
            lblQuestion.Text = q.Text;
            btnAnswerA.Text = q.Answers[0];
            btnAnswerB.Text = q.Answers[1];
            btnAnswerC.Text = q.Answers[2];
            btnAnswerD.Text = q.Answers[3];
        }
        private Question GetQuestion(int level)
        {
            var questionsWithLevel = questions.Where(q => q.Level == level).ToList();
            return questionsWithLevel[rnd.Next(questionsWithLevel.Count)];
        }
        private void NextStep()
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
btnAnswerC, btnAnswerD };

            foreach (Button btn in btns)
                btn.Enabled = true;

            level++;
            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
            mistakes = 1;
            Result = int.Parse(lstLevel.Items[lstLevel.Items.Count - level].ToString());
        }
        private void startGame()
        {
            StartGame form = new StartGame();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                GoldenSum = form.spSum;
                PName = form.name;
                level = 0;
                NextStep();
                groupBox1.Visible = false;
                button1.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
                bntFiftyFifty.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                Close();
            }

        }
        private void finishGame()
        {
            Player currentpPlayer = new Player();
            currentpPlayer.GoldenSum = GoldenSum;
            currentpPlayer.Name = PName;
            if (Result > GoldenSum)
                currentpPlayer.Result = GoldenSum;
            else
                currentpPlayer.Result = 0;
            db.Players.Add(currentpPlayer);
            db.SaveChanges();
            startGame();
        }

        private void btnAnswerA_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                if (mistakes == 1)
                {
                    MessageBox.Show("Неверный ответ!");
                    finishGame();
                }
                else
                {
                    mistakes = 1;
                    button.Enabled = false;
                }
            }
            groupBox1.Visible = false;
        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                if (mistakes == 1)
                {
                    MessageBox.Show("Неверный ответ!");
                    finishGame();
                }
                else
                {
                    mistakes = 1;
                    button.Enabled = false;
                }
            }
            groupBox1.Visible = false;

        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                if (mistakes == 1)
                {
                    MessageBox.Show("Неверный ответ!");
                    finishGame();
                }
                else
                {
                    mistakes = 1;
                    button.Enabled = false;
                }
            }
            groupBox1.Visible = false;

        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                if (mistakes == 1)
                {
                    MessageBox.Show("Неверный ответ!");
                    finishGame();
                }
                else
                {
                    mistakes = 1;
                    button.Enabled = false;
                }
            }
            groupBox1.Visible = false;
        }

        private void bntFiftyFifty_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
                btnAnswerC, btnAnswerC };

            int count = 0;
            while (count < 2)
            {
                int n = rnd.Next(4);
                int answer = int.Parse(btns[n].Tag.ToString());

                if (answer != currentQuestion.RightAnswer && btns[n].Enabled)
                {
                    btns[n].Enabled = false;
                    count++;
                }
            }
            bntFiftyFifty.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)//право на ошибку
        {
            mistakes = 2;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)//зал вам в помощь
        {
            button1.Enabled = false;
            label5.Text = "Вопрос " + currentQuestion.Level;
            progressBar1.Value = RandomGolos(1);
            label1.Text = progressBar1.Value.ToString();
            progressBar2.Value = RandomGolos(2);
            label2.Text = progressBar2.Value.ToString();
            progressBar3.Value = RandomGolos(3);
            label3.Text = progressBar3.Value.ToString();
            progressBar4.Value = RandomGolos(4);
            label4.Text = progressBar4.Value.ToString();
            groupBox1.Visible = true;
            label6.Text ="Не проголосовали: "+ (100 - (progressBar1.Value + progressBar2.Value + progressBar3.Value + progressBar4.Value)).ToString();
        }
        public int RandomGolos(int num)
        {
            if (num == currentQuestion.RightAnswer)
                return rnd.Next(40 - currentQuestion.Level);
            else
                return rnd.Next(20);
        }

        private void button3_Click(object sender, EventArgs e)//замена вопроса
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
btnAnswerC, btnAnswerC };

            foreach (Button btn in btns)
                btn.Enabled = true;

            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
            button3.Enabled = false;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            FriendsCall form = new FriendsCall();
            form.Level = level;
            form.RightAnswer = currentQuestion.RightAnswer;
            button4.Enabled = false;
            form.ShowDialog();
        }
    }
}
