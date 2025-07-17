using System;
using System.ComponentModel;
using WaferInspectionTool.Models;

namespace WaferInspectionTool.ViewModels
{
// ViewModel for a single defect, used for UI binding
public class DefectViewModel : INotifyPropertyChanged
{
    private Defect _defect;

    // The underlying defect model
    public Defect Defect => _defect;

    public int X => _defect.X;
    public int Y => _defect.Y;
    public DefectType Type => _defect.Type;
    public DateTime Timestamp => _defect.Timestamp;
    public int DieIndex => _defect.DieIndex;

    public DefectViewModel(Defect defect)
    {
        _defect = defect;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
} 