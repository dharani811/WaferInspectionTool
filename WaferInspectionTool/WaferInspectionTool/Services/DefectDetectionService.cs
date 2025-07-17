using System;
using System.Collections.Generic;
using WaferInspectionTool.Models;

namespace WaferInspectionTool.Services
{
// Simulates the defect detection engine for the wafer inspection tool
public class DefectDetectionService
{
    private readonly WaferMap _waferMap;
    private readonly Random _rand = new Random();

    // Initializes the defect detection service with a wafer map
    public DefectDetectionService(WaferMap waferMap)
    {
        _waferMap = waferMap;
    }

    // Applies mock rules to find defects in the processed image frame
    public List<Defect> DetectDefects(ImageFrame frame)
    {
        var defects = new List<Defect>();
        // Simulate random defect detection (e.g., 0-2 defects per frame)
        int defectCount = _rand.Next(0, 3);
        for (int i = 0; i < defectCount; i++)
        {
            int x = _rand.Next(0, _waferMap.DiesX);
            int y = _rand.Next(0, _waferMap.DiesY);
            if (_waferMap.IsValidLocation(x, y))
            {
                defects.Add(new Defect
                {
                    X = x,
                    Y = y,
                    DieIndex = y * _waferMap.DiesX + x,
                    Type = (DefectType)_rand.Next(0, Enum.GetValues(typeof(DefectType)).Length),
                    Timestamp = DateTime.Now
                });
            }
        }
        return defects;
    }
}
} 