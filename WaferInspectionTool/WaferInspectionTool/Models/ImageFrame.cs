namespace WaferInspectionTool.Models
{
    // Represents a simulated image frame acquired from the wafer
    public class ImageFrame
    {
        // The frame data (could be a 2D array or byte array for simulation)
        public required int[,] Data { get; set; }
        // The frame index or ID
        public int FrameId { get; set; }
        // The timestamp when the frame was acquired
        public DateTime Timestamp { get; set; }
    }
}