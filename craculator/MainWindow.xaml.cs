using System.Windows;
using System.Windows.Controls;

namespace craculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string lastAction = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickCalculatorButton(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Clicked button (Last action {lastAction})");

            switch (((Button)sender).Content)
            {
                case "0":
                    if (lastAction == "=") { outputText.Text = "0"; break; }
                    outputText.Text += "0";
                    break;
                case "1":
                    if (lastAction == "=") { outputText.Text = "1"; break; }
                    outputText.Text += "1";
                    break;
                case "2":
                    if (lastAction == "=") { outputText.Text = "2"; break; }
                    outputText.Text += "2";
                    break;
                case "3":
                    if (lastAction == "=") { outputText.Text = "3"; break; }
                    outputText.Text += "3";
                    break;
                case "4":
                    if (lastAction == "=") { outputText.Text = "4"; break; }
                    outputText.Text += "4";
                    break;
                case "5":
                    if (lastAction == "=") { outputText.Text = "5"; break; }
                    outputText.Text += "5";
                    break;
                case "6":
                    if (lastAction == "=") { outputText.Text = "6"; break; }
                    outputText.Text += "6";
                    break;
                case "7":
                    if (lastAction == "=") { outputText.Text = "7"; break; }
                    outputText.Text += "7";
                    break;
                case "8":
                    if (lastAction == "=") { outputText.Text = "8"; break; }
                    outputText.Text += "8";
                    break;
                case "9":
                    if (lastAction == "=") { outputText.Text = "9"; break; }
                    outputText.Text += "9";
                    break;
                case "DEL":
                    {
                        if (outputText.Text.Length == 0) return;

                        int currentCharIndex = outputText.Text.Length - 1;

                        if (char.IsDigit(outputText.Text[currentCharIndex]))
                        {
                            outputText.Text = outputText.Text.Remove(currentCharIndex);
                        }

                        else if (char.IsWhiteSpace(outputText.Text[currentCharIndex]))
                        {
                            int index = currentCharIndex;

                            while (index > 0 && !char.IsDigit(outputText.Text[index]))
                            {
                                index--;
                            }

                            outputText.Text = outputText.Text.Remove(index);
                        }
                    }
                    break;
                case "CE":
                    outputText.Text = string.Empty;
                    break;
                case "/":
                    outputText.Text += " / ";
                    break;
                case "*":
                    outputText.Text += " * ";
                    break;
                case "-":
                    outputText.Text += " - ";
                    break;
                case "+":
                    outputText.Text += " + ";
                    break;
                case ".":
                    outputText.Text += ".";
                    break;
                case "=":
                    {
                        outputText.Text = MathUtils.Evaluate(outputText.Text).ToString();
                    }
                    break;
            }

            lastAction = (string)((Button)sender).Content;
        }
    }
}