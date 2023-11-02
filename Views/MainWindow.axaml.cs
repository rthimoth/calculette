using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Text;
using System;
using System.Data;


namespace CalculatorQuest.Views;

public partial class MainWindow : Window
{
    private TextBlock maTextBox;
    private TextBlock result;

    public MainWindow()
    {
        Width = 300;
        Height = 450;
        InitializeComponent();
        
        maTextBox = this.FindControl<TextBlock>("MaTextBox");
        result = this.FindControl<TextBlock>("Result");
    }

    private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            result.Text = "";
            string valeurDuBouton = button.Content.ToString();
            if (valeurDuBouton == "CE" || valeurDuBouton == "C")
            {
                maTextBox.Text = "";
                result.Text = "";
            } else if (valeurDuBouton == "\u2190")
            {
                if (result.Text != "")
                {
                    if (maTextBox.Text != "")
                    { 
                        maTextBox.Text = maTextBox.Text.Remove(maTextBox.Text.Length - 1);
                    } 
                }
                else
                {
                    result.Text = "";
                    maTextBox.Text = "";
                }
                
            } else if (valeurDuBouton == "=") {
                if (maTextBox.Text != "")
                {
                    try
                    {
                        DataTable table = new DataTable();
                        object a = table.Compute(maTextBox.Text, null);
                        double doubleResult = Convert.ToDouble(a);
                        string b = doubleResult.ToString();
                        result.Text = b;
                    }
                    catch (Exception ex)
                    {
                        result.Text = "ERREUR";
                    }
                }
            }
            else
            {
                maTextBox.Text = maTextBox.Text + valeurDuBouton;
            }
        }

    }
}