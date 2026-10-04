using System;
using Eclipse.Colors;
using Eclipse.Networking;
using Il2CppInterop.Runtime.Attributes;
using MiraAPI.Roles;
using Reactor.Networking.Attributes;
using Reactor.Networking.Rpc;
using UnityEngine;
using Eclipse.Roles.Universal;


namespace Eclipse.Roles.Classic.Crewmate.Killing.Sheriff;

public sealed class SheriffRole : CrewmateRole, IEclipseRole
{
    public SheriffRole(IntPtr ptr) : base(ptr) { }

    public string IdPart => "Sheriff";
    public EclipseRoleAlignment Alignment => EclipseRoleAlignment.CrewmateKilling;
    public Color RoleColor => EclipseColors.Sheriff;

    public bool HasMisfired { get; private set; }

    [HideFromIl2Cpp]
    public CustomRoleConfiguration Configuration => new(this)
    {
        UseVanillaKillButton = false, 
        CanUseVent = false,
        CanUseSabotage = false,
        CanGetKilled = true,
        TasksCountForProgress = true,
        DefaultRoleCount = 1,
        DefaultChance = 0,
        Icon = Assets.EclipseAssets.Shoot,
    };

    [HideFromIl2Cpp]
    public void ResetMisfire() => HasMisfired = false;

    [MethodRpc((uint)EclipseRpc.SheriffMisfire, LocalHandling = RpcLocalHandling.Before)]
    public static void RpcSheriffMisfire(PlayerControl sheriff)
    {
        if (LobbyBehaviour.Instance || sheriff.Data?.Role is not SheriffRole role)
        {
            return;
        }
        role.HasMisfired = true;
    }
}
