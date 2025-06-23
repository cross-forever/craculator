using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace craculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // CALLBACKS

            // Operators
            AddButton.Click += (obj, args) => outputText.Text += "+";
            SubtractButton.Click += (obj, args) => outputText.Text += "-";
            DivideButton.Click += (obj, args) => outputText.Text += "/";
            MultiplyButton.Click += (obj, args) => outputText.Text += "*";
            ClearButton.Click += (obj, args) => outputText.Text = string.Empty;

            // currently mistaking decimal points for multiplication.
            PointButton.Click += (obj, args) => outputText.Text += ".";

            BackspaceButton.Click += (obj, args) =>
            {
                if (outputText.Text.Length == 0) return;

               outputText.Text = outputText.Text.Remove(outputText.Text.Length - 1);
            };

            // TODO: make a history window
            EqualsButton.Click += (obj, args) => outputText.Text = MathUtils.Evaluate(outputText.Text).ToString();

            // Numbers
            Number0.Click += (obj, args) => outputText.Text += "0";
            Number1.Click += (obj, args) => outputText.Text += "1";
            Number2.Click += (obj, args) => outputText.Text += "2";
            Number3.Click += (obj, args) => outputText.Text += "3";
            Number4.Click += (obj, args) => outputText.Text += "4";
            Number5.Click += (obj, args) => outputText.Text += "5";
            Number6.Click += (obj, args) => outputText.Text += "6";
            Number7.Click += (obj, args) => outputText.Text += "7";
            Number8.Click += (obj, args) => outputText.Text += "8";
            Number9.Click += (obj, args) => outputText.Text += "9";
        }
    }
}