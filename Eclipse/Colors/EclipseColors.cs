using MiraAPI.Utilities;
using UnityEngine;

namespace Eclipse.Colors;

public static class EclipseColors
{
    public static bool UseBasic { get; set; } = false;
    // Main Colors
    public static Color Crewmate => Palette.CrewmateRoleBlue;
    public static Color Impostor => Palette.ImpostorRed;
    public static Color Neutral => Color.gray;
    public static Color Other => Color.gray.DarkenColor();
    public static Color ImpSoft => new Color32(214, 64, 66, 255);
    // Role Colors
    // Crewmate Role Colors
    public static Color Sheriff => UseBasic ? Palette.CrewmateBlue : new Color32(255, 255, 0, 255);
}