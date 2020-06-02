using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lesson_1_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class Control
    {
        public Control()
        {
            Numbers = new List<string>();
            Operations = new List<char>();
            Results = new List<double>();
         //   Results.Add(0);
        }
        public List<string> Numbers { get; set; }
        public List<char> Operations { get; set; }
        public List<double> Results { get; set; }
        public double Operation(double result, char operation, string number)
        {
            switch (operation)
            {
                case '+':
                    result += double.Parse(number);
                    break;
                case '-':
                    result -= double.Parse(number);
                    break;
                case '*':
                    result *= double.Parse(number);
                    break;
                case '/':
		    if(double.Parse(number) == 0){
		    }
		    else{
                    result /= double.Parse(number);
		    }
                    break;
            }
            return result;
        }
        public double OperationFirst(string number_1, char operation, string number_2)
        {
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = double.Parse(number_1) +  double.Parse(number_2);
                    break;
                case '-':
                    result = double.Parse(number_1) - double.Parse(number_2);
                    break;
                case '*':
                    result = double.Parse(number_1) * double.Parse(number_2);
                    break;
                case '/':
                    result =(double.Parse(number_2) != 0)? double.Parse(number_1) / double.Parse(number_2):result;
                    break;
            }
            return result;
        }
        public void Calculation()
        {
            if (Operations.Count() > 0)
            {
                for (int i = 0; i < Operations.Count(); i++)
                {
                    if (i == 0)
                    {
                        Results.Add(OperationFirst(Numbers[i], Operations[i], Numbers[i + 1]));
                    }
                    else
                    {
                        Results.Add(Operation(Results[i - 1], Operations[i], Numbers[i + 1]));
                    }
                }
            }
        }
        public void ClearStacks()
        {
            Numbers.Clear();
            Operations.Clear();
            Results.Clear();
          //  Results.Add(0);
        }
    }

    public partial class MainWindow : Window
    {
        private Control control = null;
        public MainWindow()
        {
            InitializeComponent();
            control = new Control();
       }
        public bool CheckCorretEnter(string str)
        {
            bool result;
            Regex regex = new Regex(@"^0\d|,$|^,");// incorrect variants
            MatchCollection matches = regex.Matches(str);
            result = (matches.Count > 0 || str == "") ? false : true;
            // MessageBox.Show(result.ToString());
            // if result false - change color textBox2  textBox_2.Style.Resources.
            return result;
        }
        public string GetHistoryOperations(List<string> arrStr, List<char> arrChar)
        {
            string result = "";
            if (arrStr.Count() > arrChar.Count())
            {
                for (int i = 0; i < arrStr.Count(); i++)
                {
                    result += arrStr[i];
                    if (i == arrStr.Count() - 1) continue;
                    result += arrChar[i].ToString();
                }
            }
            else if (arrStr.Count() == arrChar.Count())
            {
                for (int i = 0; i < arrStr.Count(); i++)
                {
                    result += arrStr[i];
                    result += arrChar[i].ToString();
                }
            }
            return result;
        }
        private void ClearEnter()
        {
            textBox_2.Text = "";
        }
        private void ClearLastSymbol()
        {
            if(textBox_2.Text.Length > 0)
            {
                textBox_2.Foreground = Brushes.Black;
                textBox_2.Text = textBox_2.Text.Remove(textBox_2.Text.Count()-1);
            }
        }
        private void ShowResult()
        {
            textBox_2.Foreground = Brushes.Black;
            textBox_2.Text = (control.Results.Count() > 0)? control.Results.Last().ToString() : textBox_2.Text;
        }
        private void ShowHistoryoperations(List<string> arrStr, List<char> arrChar)
        {
            textBox_1.Text = GetHistoryOperations(arrStr, arrChar); 
        }
        private void CurrentOperation(char ch)
        {
            if (CheckCorretEnter(textBox_2.Text))
            {
                textBox_2.Foreground = Brushes.Black;
                control.Numbers.Add(textBox_2.Text);
                control.Operations.Add(ch);
                ClearEnter();
                ShowHistoryoperations(control.Numbers, control.Operations);
            }
            else
            {
                // show error
               // TextBlock TB = new TextBlock();
            //    Brush brush = new Brush();
               // TB.Text = textBox_2.Text;
              //  TB.Foreground = Brushes.Red; //doesn't work
              //  TB.Background = Brushes.Green; //doesn't work
              //  TB.FontSize = 8; //doesn't work
              //  textBox_2.Text = TB.Text;
                textBox_2.Foreground = Brushes.Red;
            }

        }
        private void ExecOperations()
        {
            if (CheckCorretEnter(textBox_2.Text))
            {
                textBox_2.Foreground = Brushes.Black;
                control.Numbers.Add(textBox_2.Text);
                ClearEnter();
                ShowHistoryoperations(control.Numbers, control.Operations);
                control.Calculation();
                ShowResult();
                control.ClearStacks();
                ShowHistoryoperations(control.Numbers, control.Operations);
            }
            else
            {
                // show error
                textBox_2.Foreground = Brushes.Red;
            }
        }
        private void AddNumber(string str)
        {
            textBox_2.Foreground = Brushes.Black;
            textBox_2.Text += str;
        }
        private void btn_2_1_Click(object sender, RoutedEventArgs e)
        {
           // textBox_2.Text += "7";
	    AddNumber("7");
        }
        private void btn_1_1_Click(object sender, RoutedEventArgs e)
        {
            // textBox_2.Text = "";
            //  LastOperation = "CE";
            ClearEnter();
        }
        private void btn_1_2_Click(object sender, RoutedEventArgs e)
        {
            /*  textBox_1.Text = "";
              textBox_2.Text = "";
              start = false;
              LastOperation = "C";
              */
            ClearEnter();
            control.ClearStacks();
            ShowHistoryoperations(control.Numbers, control.Operations);
        }
        private void btn_2_2_Click(object sender, RoutedEventArgs e)
        {
           // textBox_2.Text += "8";
	    AddNumber("8");
        }
        private void btn_2_3_Click(object sender, RoutedEventArgs e)
        {
          //  textBox_2.Text += "9";
	    AddNumber("9");
        }
        private void btn_4_4_Click(object sender, RoutedEventArgs e)
        {
            // button +
/*            if (CheckCorretEnter(textBox_2.Text))
            {
                control.Numbers.Add(textBox_2.Text);
                control.Operations.Add('+');
                ClearEnter();
                ShowHistoryoperations(control.Numbers, control.Operations);
            }
            else
            {
                // show error
            }
*/           
            CurrentOperation('+');
        }

        private void btn_5_3_Click(object sender, RoutedEventArgs e)
        {
            // button =
            //  ExecOperation();
/*            if (CheckCorretEnter(textBox_2.Text))
            {
                control.Numbers.Add(textBox_2.Text);
                ClearEnter();
                ShowHistoryoperations(control.Numbers, control.Operations);
                control.Calculation();
                ShowResult();
                control.ClearStacks();
                ShowHistoryoperations(control.Numbers, control.Operations);
            }
            else
            {
                // show error
            }
*/            // MessageBox.Show(control.Results.Last().ToString());
            ExecOperations();
        }

        private void btn_3_4_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperation('-');
        }

        private void btn_2_4_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperation('*');

        }

        private void btn_1_4_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperation('/');
        }

        private void btn_3_1_Click(object sender, RoutedEventArgs e)
        {
           // textBox_2.Text += "4";
            AddNumber("4");
        }

        private void btn_3_2_Click(object sender, RoutedEventArgs e)
        {
          //  textBox_2.Text += "5";
            AddNumber("5");
        }

        private void btn_3_3_Click(object sender, RoutedEventArgs e)
        {
           // textBox_2.Text += "6";
            AddNumber("6");
        }

        private void btn_4_1_Click(object sender, RoutedEventArgs e)
        {
            //textBox_2.Text += "1";
	    AddNumber("1");
        }

        private void btn_4_2_Click(object sender, RoutedEventArgs e)
        {
            //textBox_2.Text += "2";
	    AddNumber("2");
        }

        private void btn_4_3_Click(object sender, RoutedEventArgs e)
        {
            //textBox_2.Text += "3";
	    AddNumber("3");
        }

        private void btn_5_2_Click(object sender, RoutedEventArgs e)
        {
            //textBox_2.Text += "0";
	    AddNumber("0");
        }

        private void btn_5_1_Click(object sender, RoutedEventArgs e)
        {
            //textBox_2.Text += ",";
	    AddNumber(",");
        }

        private void btn_1_3_Click(object sender, RoutedEventArgs e)
        {
            // <
            ClearLastSymbol();
        }
    }
}
