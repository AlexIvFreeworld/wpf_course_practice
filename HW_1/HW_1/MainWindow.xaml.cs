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
    public partial class MainWindow : Window
    {
        private double Result { get; set; }
        private string LastOperation { set; get; }
        private double LastNumber { set; get; }
        private bool start = false;
        
        public MainWindow()
        {
            InitializeComponent();
       }
        private bool CheckCorretEnter()
        {
            bool result;
            Regex regex = new Regex(@"^0\d|,$|^,");// incorrect variants
            MatchCollection matches = regex.Matches(textBox_2.Text);
            result = (matches.Count > 0 || textBox_2.Text == "") ? false : true;
           // MessageBox.Show(result.ToString());
           // if result false - change color textBox2  textBox_2.Style.Resources.
            return result;
        }
        private void ExecOperation()
        {
            // string operation = textBox_2.Text;
            // Check entered number
            if (CheckCorretEnter())
            {
                start = true;
                LastNumber = double.Parse(textBox_2.Text);
                switch (LastOperation)
                {
                    case "+":
                        Result += LastNumber;
                        //  textBox_1.Text = Result.ToString();
                        textBox_2.Text = Result.ToString();
                        break;
                    case "-":
                        Result -= double.Parse(textBox_2.Text);
                        //  textBox_1.Text = Result.ToString();
                        textBox_2.Text = Result.ToString();
                        break;
                    case "*":
                        Result *= double.Parse(textBox_2.Text);
                        //   textBox_1.Text = Result.ToString();
                        textBox_2.Text = Result.ToString();
                        break;
                    case "/":
                        // if(textBox_2.Text == '0')
                        Result /= double.Parse(textBox_2.Text);
                        //    textBox_1.Text = Result.ToString();
                        textBox_2.Text = Result.ToString();
                        break;
                }
                LastOperation = "=";
            }

        }
        private void btn_2_1_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "7";
            textBox_2.Text += "7";
        }

        private void btn_1_1_Click(object sender, RoutedEventArgs e)
        {
            textBox_2.Text = "";
            LastOperation = "CE";
        }

        private void btn_1_2_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text = "";
            textBox_2.Text = "";
            start = false;
            LastOperation = "C";
        }

        private void btn_2_2_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "8";
            textBox_2.Text += "8";
        }

        private void btn_2_3_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "9";
            textBox_2.Text += "9";
        }

        private void btn_4_4_Click(object sender, RoutedEventArgs e)
        {
            // Check entered number
            if (CheckCorretEnter())
            {
                Result = (start == false) ? double.Parse(textBox_1.Text) : Result;
                textBox_1.Text += "+";
                textBox_2.Text = "";
                LastOperation = "+";
            }
            else
            {
                //textBox_2.Text = "";
                //clear textBox1 the same symbols 
                MessageBox.Show("Некорректное значение");
            }
         //  if(start == true) ExecOperation();
        }

        private void btn_5_3_Click(object sender, RoutedEventArgs e)
        {
            ExecOperation();
        }

        private void btn_3_4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCorretEnter())
            {
                Result = (start == false) ? double.Parse(textBox_1.Text) : Result;
                textBox_1.Text += "-";
                textBox_2.Text = "";
                LastOperation = "-";
            }
            else
            {
                MessageBox.Show("Некорректное значение");
            }

        }

        private void btn_2_4_Click(object sender, RoutedEventArgs e)
        {

            if (CheckCorretEnter())
            {
                Result = (start == false) ? double.Parse(textBox_1.Text) : Result;
                textBox_1.Text += "*";
                textBox_2.Text = "";
                LastOperation = "*";
            }
            else
            {
                MessageBox.Show("Некорректное значение");
            }
        }

        private void btn_1_4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCorretEnter())
            {
                Result = (start == false) ? double.Parse(textBox_1.Text) : Result;
                textBox_1.Text += "/";
                textBox_2.Text = "";
                LastOperation = "/";
            }
            else
            {
                MessageBox.Show("Некорректное значение");
            }
        }

        private void btn_3_1_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "4";
            textBox_2.Text += "4";
        }

        private void btn_3_2_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "5";
            textBox_2.Text += "5";
        }

        private void btn_3_3_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "6";
            textBox_2.Text += "6";
        }

        private void btn_4_1_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "1";
            textBox_2.Text += "1";
        }

        private void btn_4_2_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "2";
            textBox_2.Text += "2";
        }

        private void btn_4_3_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "3";
            textBox_2.Text += "3";
        }

        private void btn_5_2_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += "0";
            textBox_2.Text += "0";
        }

        private void btn_5_1_Click(object sender, RoutedEventArgs e)
        {
            textBox_1.Text += ",";
            textBox_2.Text += ",";
        }

        private void btn_1_3_Click(object sender, RoutedEventArgs e)
        {
           // string temp = textBox_2.Text;
          //  MessageBox.Show(temp.Count().ToString());
            if(textBox_2.Text.Count() > 0 && LastOperation != "=")
            {
                textBox_2.Text = textBox_2.Text.Remove(textBox_2.Text.Count() - 1);
                textBox_1.Text = textBox_1.Text.Remove(textBox_1.Text.Count() - 1);
            }
        }
    }
}
