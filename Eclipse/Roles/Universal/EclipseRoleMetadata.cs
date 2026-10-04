using System;
using MiraAPI.Roles;

namespace Eclipse.Roles.Universal;

public static class EclipseRoleMetadata
{
    public static ModdedRoleTeams GetTeam(this EclipseRoleAlignment alignment) => alignment switch
    {
        EclipseRoleAlignment.CrewmateInvestigative or EclipseRoleAlignment.CrewmateKilling or
            EclipseRoleAlignment.CrewmateProtective or EclipseRoleAlignment.CrewmatePower or
            EclipseRoleAlignment.CrewmateSupport => ModdedRoleTeams.Crewmate,
        EclipseRoleAlignment.ImpostorConcealing or EclipseRoleAlignment.ImpostorKilling or
            EclipseRoleAlignment.ImpostorPower or EclipseRoleAlignment.ImpostorSupport => ModdedRoleTeams.Impostor,
        EclipseRoleAlignment.NeutralBenign or EclipseRoleAlignment.NeutralEvil or
            EclipseRoleAlignment.NeutralKilling or EclipseRoleAlignment.NeutralOutlier => ModdedRoleTeams.Custom,
        _ => throw new ArgumentOutOfRangeException(nameof(alignment)),
    };
    
    public static ModdedRoleTeams GetTeam(RoleBehaviour role)
    {
        if (role is ICustomRole customRole)
        {
            return customRole.Team;
        }
        return role.IsImpostor ? ModdedRoleTeams.Impostor : ModdedRoleTeams.Crewmate;
    }
    
    public static string GetIdentity(ICustomRole role) => role.IdPrefix + "." + role.IdPart;
}
