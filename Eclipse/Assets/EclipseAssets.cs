using UnityEngine;

namespace Eclipse.Assets;

public static class EclipseAssets
{
    internal const string ResourcePath = "Eclipse.Resources";
    private const string RoleIcons = "Eclipse.Resources.RoleIcons";
    private const string RoleButtonIcons = "Eclipse.Resources.Buttons";
    // Sheriff
    public static readonly LoadableAsset<Sprite> Shoot = new LoadableResourceAsset(RoleButtonIcons + ".SheriffShootButton.png");

    public static readonly LoadableAsset<Sprite> RoleIcon = new LoadableResourceAsset(RoleIcons + ".Sheriff.png");
    
    
}