using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;


namespace Sys._Prog._Task_1_Task_Manager;

public partial class RunNewTaskWindow : Window
{
    List<string> blackList = new();
    public RunNewTaskWindow(List<string> BlackList)
    {
        InitializeComponent();
        this.blackList = BlackList;
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OKButtonClick(object sender, RoutedEventArgs e)
    {

        bool isCheck = false;
        foreach (var item in blackList)
        {
            int id = -1;
            if (item == TxtBox.Text)
            {
                isCheck = true;
                Process.Start(TxtBox.Text);
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName == TxtBox.Text)
                        id = process.Id;
                }
                Thread.Sleep(1000);
                Process.GetProcessById(id).Kill();
            }
        }
        if(!isCheck) 
        Process.Start(TxtBox.Text);
    }

    private void BrowseButtonClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.ShowDialog();
        TxtBox.Text = openFileDialog.FileName;
    }
}
