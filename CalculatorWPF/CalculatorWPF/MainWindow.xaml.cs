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
        public char[] numbers = new char[] {'1','2','3','4', '5', '6', '7', '8','9','0' };
        public int OpenBracketsNum=0;
        
        public MainWindow()
        {
            InitializeComponent();
            ChangeStyle("light");
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
        private void CheckedChange(object sender,EventArgs e)
        {
            if ((bool)StyleCheckBox.IsChecked)
            {
                string style = "dark";
                ChangeStyle(style);
            }
            else
            {
                string style = "light";
                ChangeStyle(style);
            }

        }
        public void ChangeStyle(string style)
        {
            var uri = new Uri("/Styles/" + style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        public bool LastSymbolIsAction() => actions.Contains(Expression.Text.Last());
        public bool LastSymbolIsNumber() => numbers.Contains(Expression.Text.Last());
        public bool LastSymbolISOpenBracket() => Expression.Text.Last() == '(';
        public bool LastSymbolISClosingBracket() => Expression.Text.Last() == ')';
    }
}
