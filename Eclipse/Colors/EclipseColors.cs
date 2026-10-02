using MiraAPI.Utilities;
using UnityEngine;

namespace Eclipse.Colors;

public static class EclipseColors
{
    public static bool UseBasic { get; set; } = false;
    
    public static Color Sheriff => UseBasic ? Palette.CrewmateBlue : new Color32(255, 255, 0, 255);
}