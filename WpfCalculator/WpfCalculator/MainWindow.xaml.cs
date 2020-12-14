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

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // ------- 
    {
        // --- TO IMPROVE / FIX
            // Need to fix 3+ number calculations i.e. (12 * 6 - 14 + 40)
            // change functions to one function method, and get operator by button name
            // Add further calculator options i.e. brackets, clear screen/cancel, square, sqr rt, log etc....
        double temp = 0;
        double result = 0;
        bool screenNeedsClearing = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Operator_Function(object sender, RoutedEventArgs e)
        {
            if(DisplayTextBox.Text != "")
            {
                temp = double.Parse(DisplayTextBox.Text);
                Button btn = (Button)sender;
                switch (btn.Name) {
                    case "DivideButton":
                        FunctionTextBox.Text = "/";
                        break;
                    case "MultiplyButton":
                        FunctionTextBox.Text = "*";
                        break;
                    case "SubtractButton":
                        FunctionTextBox.Text = "-";
                        break;
                    case "AdditionButton":
                        FunctionTextBox.Text = "+";
                        break;
                }
                screenNeedsClearing = true;
            }
        }

        // ----> OLD CODE -> REPLACED BY THE CODE ABOVE
        //private void Divide_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    temp = double.Parse(DisplayTextBox.Text);
        //    FunctionTextBox.Text = "/";
        //    screenNeedsClearing = true;
        //}
        //private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    temp = double.Parse(DisplayTextBox.Text);
        //    FunctionTextBox.Text = "*";
        //    screenNeedsClearing = true;
        //}
        //private void Minus_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    temp = double.Parse(DisplayTextBox.Text);
        //    FunctionTextBox.Text = "-";
        //    screenNeedsClearing = true;
        //}
        //private void Plus_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    temp = double.Parse(DisplayTextBox.Text);
        //    FunctionTextBox.Text = "+";
        //    screenNeedsClearing = true;
        //}

        private void Equals_Button_Click(object sender, RoutedEventArgs e)
        {
            double temp2;
            if (DisplayTextBox.Text != "")
            {
                temp2 = double.Parse(DisplayTextBox.Text);
                switch (FunctionTextBox.Text)
                {
                    case "/":
                        result = temp / temp2;
                        break;

                    case "*":
                        result = temp * temp2;
                        break;

                    case "-":
                        result = temp - temp2;
                        break;

                    case "+":
                        result = temp + temp2;
                        break;

                    default:
                        result = temp2; // somehow none of these (or empty!)
                        break;
                }
                DisplayTextBox.Text = result.ToString();
                FunctionTextBox.Text = "="; 
                screenNeedsClearing = true;
            }
            
        }

        private void Number_Button_Click(object sender, RoutedEventArgs e)
        {
            if (screenNeedsClearing)
            {
                DisplayTextBox.Text = "";
                screenNeedsClearing = false;
            }
            Button btn = (Button)sender;
            string numberClicked = btn.Content.ToString();
            DisplayTextBox.Text += numberClicked;
        }
        private void Cls_Button_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            FunctionTextBox.Text = "";
            DisplayTextBox.Text = "";
        }

    }
}
