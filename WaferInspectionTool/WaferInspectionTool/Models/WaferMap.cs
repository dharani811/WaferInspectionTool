namespace WaferInspectionTool.Models
{
    // Represents the wafer map and provides die location validation
    public class WaferMap
    {
        // The number of dies along the X axis
        public int DiesX { get; }
        // The number of dies along the Y axis
        public int DiesY { get; }

        // Initializes a new wafer map with the given die grid size
        public WaferMap(int diesX, int diesY)
        {
            DiesX = diesX;
            DiesY = diesY;
        }

        // Validates if the given coordinates are within the wafer map
        public bool IsValidLocation(int x, int y)
        {
            return x >= 0 && x < DiesX && y >= 0 && y < DiesY;
        }
    }
}