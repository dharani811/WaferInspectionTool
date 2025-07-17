namespace WaferInspectionTool.Models
{
// Represents a detected defect on the wafer
public class Defect
{
    // The X coordinate of the defect on the wafer
    public int X { get; set; }
    // The Y coordinate of the defect on the wafer
    public int Y { get; set; }
    // The type of defect detected
    public DefectType Type { get; set; }
    // The timestamp when the defect was detected
    public DateTime Timestamp { get; set; }
    // The die index where the defect was found
    public int DieIndex { get; set; }
}
} 