using System;
using System.Collections.Generic;
using Eclipse.Colors;
using MiraAPI.Roles;
using UnityEngine;

namespace Eclipse.Roles.Universal;

public static class EclipseRoleGroups
{
    private static readonly Dictionary<EclipseRoleAlignment, RoleOptionsGroup> Groups = CreateGroups();
    public static RoleOptionsGroup For(EclipseRoleAlignment alignment) => Groups[alignment];
    private static Dictionary<EclipseRoleAlignment, RoleOptionsGroup> CreateGroups()
    {
        var groups = new Dictionary<EclipseRoleAlignment, RoleOptionsGroup>();
        foreach (var alignment in Enum.GetValues<EclipseRoleAlignment>())
        {
            Color color = alignment.GetTeam() switch
            {
                ModdedRoleTeams.Crewmate => EclipseColors.Crewmate,
                ModdedRoleTeams.Impostor => EclipseColors.ImpSoft,
                _ => EclipseColors.Neutral,
            };
            groups.Add(alignment, new RoleOptionsGroup(alignment.GetGroupKey(), color, (int)alignment));
        }
        return groups;
    }
}