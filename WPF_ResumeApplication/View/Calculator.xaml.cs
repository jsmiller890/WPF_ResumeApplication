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
using System.Windows.Shapes;

namespace WPF_ResumeApplication.View
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        double dblValue = 0;
        double dblTemp = 0;
        string op = "";

        public Calculator()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Name)
            {
                case "_0Btn":
                    resultLbl.Content = resultLbl.Content + "0";
                    break;
                case "_1Btn":
                    resultLbl.Content = resultLbl.Content + "1";
                    break;
                case "_2Btn":
                    resultLbl.Content = resultLbl.Content + "2";
                    break;
                case "_3Btn":
                    resultLbl.Content = resultLbl.Content + "3";
                    break;
                case "_4Btn":
                    resultLbl.Content = resultLbl.Content + "4";
                    break;
                case "_5Btn":
                    resultLbl.Content = resultLbl.Content + "5";
                    break;
                case "_6Btn":
                    resultLbl.Content = resultLbl.Content + "6";
                    break;
                case "_7Btn":
                    resultLbl.Content = resultLbl.Content + "7";
                    break;
                case "_8Btn":
                    resultLbl.Content = resultLbl.Content + "8";
                    break;
                case "_9Btn":
                    resultLbl.Content = resultLbl.Content + "9";
                    break;
                case "_signBtn":
                    if (dblValue != 0)
                        dblValue *= -1;
                    resultLbl.Content = dblValue.ToString();
                    break;

                case "_clearBtn":
                    resultLbl.Content = "";
                    break;
                
                case "_enterBtn":
                    Solve();
                    break;

                case "_fibBtn":
                    dblTemp = Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = Fibonacci((int)dblTemp);
                    break;
                
                case "_addBtn":
                    op = "add";
                    dblTemp = Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = "";

                    break;
                
                case "_subBtn":
                    op = "sub";
                    dblTemp = Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = "";
                    break;
                
                case "_multiplyBtn":
                    op = "multiply";
                    dblTemp = Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = "";
                    break;
                
                case "_divideBtn":
                    op = "divide";
                    dblTemp = Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = "";
                    break;

                case "_squareBtn":
                    resultLbl.Content = Square(Int32.Parse(resultLbl.Content.ToString()));
                    break;

                case "_remainBtn":
                    op = "remain";
                    dblTemp = Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = "";
                    break;
                default:
                    break;
            }
        }
        private int Fibonacci(int i)
        {
            if (i <= 1)
                return 1;
            return Fibonacci(i - 1) + Fibonacci(i - 2);
        }

        private int Square(int dblValue)
        {
            return dblValue * dblValue;
        }

        private double Solve()
        {
            if(op == "add")
            {
                dblValue = Double.Parse(resultLbl.Content.ToString()) + dblTemp;
                resultLbl.Content = dblValue.ToString();
            }
            else if(op == "sub")
            {
                dblValue = dblTemp - Double.Parse(resultLbl.Content.ToString());
                resultLbl.Content = dblValue.ToString();
            }
            else if(op == "multiply")
            {
                dblValue = Double.Parse(resultLbl.Content.ToString()) * dblTemp;
                resultLbl.Content = dblValue.ToString();
            }

            else if(op == "divide")
            {
                if(dblValue == 0)
                {
                    MessageBox.Show("You can't divide by 0");
                }
                else
                {
                    dblValue = dblTemp / Double.Parse(resultLbl.Content.ToString());
                    resultLbl.Content = dblValue.ToString();
                }
            }
            else if(op == "remain")
            {
                dblValue = dblTemp % Double.Parse(resultLbl.Content.ToString());
                resultLbl.Content = dblValue.ToString();
            }
            return dblValue;
        }
    }
}
