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
using workshop.calculator;

namespace workshop.winui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Calculator _calculator;
    public MainWindow(Calculator calculator)
    {
        InitializeComponent();
        _calculator = calculator;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(TextBox1.Text, out int num1) &&
            int.TryParse(TextBox2.Text, out int num2))
        {
            int result = _calculator.Add(new[] { num1, num2 });
            ResultText.Text = $"Result: {result}";
        }
        else
        {
            ResultText.Text = "⚠️ Please enter valid integers.";
        }
    }

}