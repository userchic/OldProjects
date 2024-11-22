using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public char[] actions = new char[] {'+','-','*','/'};
        public int OpenBracketsNum=0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BClick(object sender, RoutedEventArgs e)
        {
            string button = (string)((Button)sender).Content;
            // проверяем последний символ в собранном выражении
            // чтобы знаки действия нельзя было множить 
            if (!actions.Contains(Expression.Text[Expression.Text.Length - 1]))
                Expression.Text += button;
            else
            {
                string line = Expression.Text.Substring(0, Expression.Text.Length - 1);
                line += button;
                Expression.Text = line;
            }
        }
        private void NClick (object sender, RoutedEventArgs e)
        {
            string button = (string)((Button)sender).Content;
            if (Expression.Text == "0")
                Expression.Text = button;
            else
                Expression.Text += button;
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (Expression.Text.Length > 1)
            {
                if (LastSymbolISClosingBracket())
                    OpenBracketsNum++;
                if (LastSymbolISOpenBracket())
                    OpenBracketsNum--;
                Expression.Text = Expression.Text.Substring(0, Expression.Text.Length - 1);
            }
            else
                Expression.Text = "0";
        }
        public void BracketClick(object sender, RoutedEventArgs e)
        {
            string button = (string)((Button)sender).Content;
            if (button =="(")
            {
                if (LastSymbolIsAction())
                {
                    Expression.Text += "(";
                    OpenBracketsNum++;
                }
                return;
            }
            if (button == ")")
            {
                if (OpenBracketsNum>0)
                if (LastSymbolIsNumber())
                {
                    Expression.Text += ")";
                        OpenBracketsNum--;
                }
            }
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal res = Convert.ToDecimal(new NCalc.Expression(Expression.Text).Evaluate());
                Expression.Text = res.ToString();
            }
            catch { MessageBox.Show("ошибочка вышла"); }
        }
        public bool LastSymbolIsAction() => actions.Contains(Expression.Text.Last());
        public bool LastSymbolIsNumber() => !actions.Contains(Expression.Text.Last());
        public bool LastSymbolISOpenBracket() => Expression.Text.Last() == '(';
        public bool LastSymbolISClosingBracket() => Expression.Text.Last() == ')';
    }
}
