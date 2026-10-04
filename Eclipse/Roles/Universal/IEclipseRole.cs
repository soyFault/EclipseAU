using MiraAPI.Roles;


namespace Eclipse.Roles.Universal;


public interface IEclipseRole : ICustomRole
{
    EclipseRoleAlignment Alignment { get; }

    string ICustomRole.IdPrefix => "Eclipse.Role";

    ModdedRoleTeams ICustomRole.Team => Alignment.GetTeam();
    
    RoleOptionsGroup ICustomRole.RoleOptionsGroup => EclipseRoleGroups.For(Alignment);
    
    string ICustomRole.RoleFactionTitle => MiraLocaleManager.Get(Alignment.GetAlignmentKey());
    
    bool ICustomRole.CanLocalPlayerSeeRole(PlayerControl player) => player.AmOwner;
}