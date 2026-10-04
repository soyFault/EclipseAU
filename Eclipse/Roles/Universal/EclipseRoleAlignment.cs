using System;

namespace Eclipse.Roles.Universal;

public enum EclipseRoleAlignment
{
    //Cyrrently using TOU alignments but will change later for mine.
    
    CrewmateInvestigative,
    CrewmateKilling, //added
    CrewmateProtective,
    CrewmatePower,
    CrewmateSupport,
    ImpostorConcealing,
    ImpostorKilling,
    ImpostorPower,
    ImpostorSupport,
    NeutralBenign,
    NeutralEvil,
    NeutralKilling,
    NeutralOutlier,
}

public static class EclipseRoleAlignmentExtensions
{
    public static string GetAlignmentKey(this EclipseRoleAlignment alignment)
    {
        Validate(alignment);
        return "Eclipse.Alignment." + alignment;
    }

    public static string GetGroupKey(this EclipseRoleAlignment alignment)
    {
        Validate(alignment);
        return "Eclipse.RoleGroup." + alignment;
    }

    public static void Validate(EclipseRoleAlignment alignment)
    {
        if (!Enum.IsDefined(typeof(EclipseRoleAlignment), alignment))
        {
            throw new ArgumentOutOfRangeException(nameof(alignment));
        }
    }
}
