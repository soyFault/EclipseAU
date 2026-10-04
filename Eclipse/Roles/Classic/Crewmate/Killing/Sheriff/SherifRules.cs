using System;
using Eclipse.Roles.Universal;
using Eclipse.Options;

namespace Eclipse.Roles.Classic.Crewmate.Killing.Sheriff;

public enum MisfireOptions
{
    Sheriff,
    Target,
    Both,
    Nobody,
}

public static class SheriffRules
{
    public static bool IsValidTarget(bool isImpostor, bool isNeutral, EclipseRoleAlignment? alignment,
        bool shootBenign, bool shootEvil, bool shootKilling, bool shootOutlier)
    {
        if (isImpostor)
        {
            return true;
        }
        if (!isNeutral)
        {
            return false;
        }

        return alignment switch
        {
            EclipseRoleAlignment.NeutralBenign => shootBenign,
            EclipseRoleAlignment.NeutralEvil => shootEvil,
            EclipseRoleAlignment.NeutralKilling => shootKilling,
            EclipseRoleAlignment.NeutralOutlier => shootOutlier,
            _ => true,
        };
    }
    
    public static (bool KillTarget, bool KillSheriff) GetMisfireDeaths(MisfireOptions penalty) => penalty switch
    {
        MisfireOptions.Sheriff => (false, true),
        MisfireOptions.Target => (true, false),
        MisfireOptions.Both => (true, true),
        MisfireOptions.Nobody => (false, false),
        _ => throw new ArgumentOutOfRangeException(nameof(penalty)),
    };
}