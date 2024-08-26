using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;


namespace Sys._Prog._Task_1_Task_Manager;

public partial class RunNewTaskWindow : Window
{
    public RunNewTaskWindow()
    {
        InitializeComponent();
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OKButtonClick(object sender, RoutedEventArgs e)
    {
        Process.Start(TxtBox.Text);
    }

    private void BrowseButtonClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.ShowDialog();
        TxtBox.Text = openFileDialog.FileName;
    }
}
