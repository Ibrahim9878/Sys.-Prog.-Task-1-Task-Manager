using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Sys._Prog._Task_1_Task_Manager;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ObservableCollection<Process> processList;

    DispatcherTimer _timer;
    private void StartAutoRefresh()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(5);
        _timer.Tick += (sender, e)=> { ProcessList = new(Process.GetProcesses().ToList()); };
        _timer.Start();
    }

    public ObservableCollection<Process> ProcessList { get => processList; set { processList = value; OnPropertyChanged(); }}

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public MainWindow()
    {
        ProcessList = new (Process.GetProcesses().ToList());
        foreach (Process process in ProcessList)
        {
            process.
        }
        
        InitializeComponent();
        StartAutoRefresh();
        DataContext = this;
    }
}