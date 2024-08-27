using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sys._Prog._Task_1_Task_Manager;

public partial class ShowBlackListedProcessesWindow : Window
{
    private ObservableCollection<Process> processList;

    public ObservableCollection<Process> ProcessList { get => processList; set { processList = value; OnPropertyChanged(); } }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public ShowBlackListedProcessesWindow(List<string> BlackList)
    {
        ProcessList = new();
        DataGrid ProcessesDataGrid = new DataGrid();
        ProcessesDataGrid.AutoGenerateColumns = false;
        ProcessesDataGrid.CanUserAddRows = false;
        ProcessesDataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
        ProcessesDataGrid.ItemsSource = new List<string>();
        ProcessesDataGrid.ItemsSource = BlackList;

        MainGrid.Children.Add(ProcessesDataGrid);
        

        InitializeComponent();
        DataContext = this;
    }
}
