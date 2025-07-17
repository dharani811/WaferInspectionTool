namespace WaferInspectionTool.Models
{
    // Enumerates possible types of defects detected on the wafer
    public enum DefectType
    {
        // A particle defect
        Particle,
        // A scratch defect
        Scratch,
        // A pattern mismatch defect
        PatternMismatch,
        // A missing pattern defect
        MissingPattern
    }
}