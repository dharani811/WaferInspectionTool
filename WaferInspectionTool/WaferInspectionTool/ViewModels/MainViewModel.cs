using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WaferInspectionTool.Models;
using WaferInspectionTool.Services;

namespace WaferInspectionTool.ViewModels
{
// Main ViewModel for the wafer inspection tool UI
public class MainViewModel : INotifyPropertyChanged
{
    // Collection of detected defects for UI binding
    public ObservableCollection<DefectViewModel> Defects { get; } = new ObservableCollection<DefectViewModel>();

    // Command to start inspection
    public ICommand StartCommand { get; }
    // Command to stop inspection
    public ICommand StopCommand { get; }

    private readonly ImageAcquisitionService _acquisitionService;
    private readonly ImageProcessingService _processingService;
    private readonly DefectDetectionService _detectionService;
    private readonly CalibrationService _calibrationService;
    private bool _isRunning;

    public event PropertyChangedEventHandler PropertyChanged;

    // Indicates if the inspection is running
    public bool IsRunning
    {
        get => _isRunning;
        set
        {
            if (_isRunning != value)
            {
                _isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
            }
        }
    }

    // Initializes the MainViewModel and services
    public MainViewModel()
    {
        var waferMap = new WaferMap(10, 10);
        _acquisitionService = new ImageAcquisitionService();
        _processingService = new ImageProcessingService();
        _detectionService = new DefectDetectionService(waferMap);
        _calibrationService = new CalibrationService();

        StartCommand = new RelayCommand(_ => StartInspection(), _ => !IsRunning);
        StopCommand = new RelayCommand(_ => StopInspection(), _ => IsRunning);

        _acquisitionService.FrameAcquired += OnFrameAcquired;
    }

    // Starts the inspection simulation
    public void StartInspection()
    {
        Defects.Clear();
        IsRunning = true;
        _calibrationService.Calibrate();
        _calibrationService.Align();
        _acquisitionService.Start();
    }

    // Stops the inspection simulation
    public void StopInspection()
    {
        IsRunning = false;
        _acquisitionService.Stop();
    }

    // Handles new image frames, processes and detects defects
    private void OnFrameAcquired(ImageFrame frame)
    {
        if (!IsRunning) return;
        var processed = _processingService.PreProcess(frame);
        var defects = _detectionService.DetectDefects(processed);
        foreach (var defect in defects)
        {
            // Log defect to console
            Console.WriteLine($"Defect: Type={defect.Type}, X={defect.X}, Y={defect.Y}, Die={defect.DieIndex}, Time={defect.Timestamp}");
            App.Current.Dispatcher.Invoke(() => Defects.Add(new DefectViewModel(defect)));
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// RelayCommand implementation for MVVM command binding
public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    // Event to re-evaluate command executability
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    // Initializes a new RelayCommand
    public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
    public void Execute(object parameter) => _execute(parameter);
}
} 