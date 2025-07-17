using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WaferInspectionTool.Models;

namespace WaferInspectionTool.ViewModels
{
    // Converts DefectType to a Brush for DataGrid row background coloring
    public class DefectTypeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DefectType type)
            {
                switch (type)
                {
                    case DefectType.Particle:
                        return Brushes.LightBlue;
                    case DefectType.Scratch:
                        return Brushes.LightCoral;
                    case DefectType.PatternMismatch:
                        return Brushes.Khaki;
                    case DefectType.MissingPattern:
                        return Brushes.MediumPurple;
                    default:
                        return Brushes.White;
                }
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 