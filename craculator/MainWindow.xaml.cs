using System.Diagnostics;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

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
            Style = (Style)FindResource(typeof(Window));
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            HwndSource hwndSource = HwndSource.FromHwnd(hwnd);
            hwndSource.AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 0xa4)
            {
                // show our context menu
                ShowContextMenu();

                handled = true;
            }

            return IntPtr.Zero;
        }

        private void ShowContextMenu()
        {
            var contextMenu = Resources["contextMenu"] as ContextMenu;

            if (contextMenu == null) return;

            contextMenu.IsOpen = true;
        }

        private void OnClickContextMenuItem(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as MenuItem;

            switch (item?.Header)
            {
                case "Repository":
                    Process.Start("explorer", "https://github.com/cross-forever/craculator");
                    break;
                case "Quit":
                    Application.Current.Shutdown(0);
                    break;
            }
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