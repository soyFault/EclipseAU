using Eclipse.Assets;
using Eclipse.Buttons;
using MiraAPI.GameOptions;
using MiraAPI.Networking;
using MiraAPI.Roles;
using Eclipse.Colors;
using Eclipse.Options;
using Eclipse.Roles.Universal;
using MiraAPI.Translation;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace Eclipse.Roles.Classic.Crewmate.Killing.Sheriff;

public sealed class SheriffShootButton : EclipseKillRoleButton<SheriffRole>
{
    public override string Name => "Eclipse.Sheriff.Button.Shoot";
    public override float Cooldown => Options.KillCooldown;
    public override Color TextOutlineColor => EclipseColors.Sheriff;
    public override LoadableAsset<Sprite> Sprite => EclipseAssets.Shoot;
    public override bool UsableFirstRound => Options.FirstRoundUse;
    
    private static SheriffOptions Options => OptionGroupSingleton<SheriffOptions>.Instance;

    public override bool CanUse()
    {
        if (PlayerControl.LocalPlayer?.Data?.Role is SheriffRole { HasMisfired: true })
        {
            SetOutline(false);
            Target = null;
            return false;
        }
        return base.CanUse();
    }

    protected override void OnClick()
    {
        var target = Target;
        if (target == null || target.Data?.Role == null || target.ProtectedByGa())
        {
            return;
        }

        var team = EclipseRoleMetadata.GetTeam(target.Data.Role);
        EclipseRoleAlignment? alignment = (target.Data.Role as IEclipseRole)?.Alignment;
        bool valid = SheriffRules.IsValidTarget(team == ModdedRoleTeams.Impostor,
            team == ModdedRoleTeams.Custom, alignment, Options.ShootNeutralBenign,
            Options.ShootNeutralEvil, Options.ShootNeutralKilling, Options.ShootNeutralOutlier);

        if (valid)
        {
            PlayerControl.LocalPlayer.RpcCustomMurder(target, MeetingCheck.OutsideMeeting);
        }
        else
        {
            Misfire(target);
        }
    }

    private void Misfire(PlayerControl target)
    {
        var sheriff = PlayerControl.LocalPlayer;
        SheriffRole.RpcSheriffMisfire(sheriff);
        var deaths = SheriffRules.GetMisfireDeaths(Options.MisfireType);
        if (deaths.KillTarget)
        {
            sheriff.RpcCustomMurder(target, MeetingCheck.OutsideMeeting);
        }
        if (deaths.KillSheriff)
        {
            sheriff.RpcCustomMurder(sheriff, MeetingCheck.OutsideMeeting);
        }

        Helpers.CreateAndShowNotification(MiraLocaleManager.Get("Eclipse.Sheriff.Misfire.Feedback"),
            Color.white, spr: EclipseAssets.RoleIcon.LoadAsset());
    }
}
