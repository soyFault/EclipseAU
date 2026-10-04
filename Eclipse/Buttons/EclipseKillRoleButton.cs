using Eclipse.Systems.Lifecycle;
using MiraAPI.Hud;
using MiraAPI.PluginLoading;
using MiraAPI.Utilities;
using UnityEngine;

namespace Eclipse.Buttons;


[MiraIgnore] 
public abstract class EclipseKillRoleButton<TRole> : CustomActionButton<PlayerControl>
    where TRole : RoleBehaviour
{

    protected TRole Role => (TRole)PlayerControl.LocalPlayer.Data.Role;

    public override BaseKeybind Keybind => VanillaKeybinding<KillButton>.Instance;
    public override ButtonLocation Location { get; set; } = ButtonLocation.BottomRight;
    public override float InitialCooldown => 10f;
    public override bool PauseTimerInVent => true;
    public virtual bool UsableFirstRound => true;

    private static readonly LoadableAsset<Sprite> RoundLock = new LoadableResourceAsset(
        "Eclipse.Resources.Misc.RoundOneLock.png");
    private SpriteRenderer? roundLockRenderer;

    protected bool FirstRoundLocked => !UsableFirstRound &&
        MatchLifecycle.CurrentRound == 1 && !TutorialManager.InstanceExists;

    public override bool Enabled(RoleBehaviour? role) => role is TRole;

    public override bool CanUse()
    {
        var player = PlayerControl.LocalPlayer;
        if (player == null || player.Data == null || !Enabled(player.Data.Role) ||
            player.Data.IsDead || player.Data.Disconnected || !player.CanMove || player.inVent ||
            MeetingHud.Instance || ExileController.Instance || FirstRoundLocked ||
            HudManager.Instance.Chat.IsOpenOrOpening)
        {
            SetOutline(false);
            Target = null;
            return false;
        }
        return base.CanUse();
    }

    public override PlayerControl? GetTarget() => PlayerControl.LocalPlayer.GetClosestPlayer(
        includeImpostors: true, distance: Distance,
        predicate: player => !player.inVent);

    public override bool IsTargetValid(PlayerControl? target) => target != null &&
        target.Data != null && !target.Data.IsDead && !target.Data.Disconnected && !target.inVent;

    public override void SetOutline(bool active)
    {
 if (Target != null)
 {
     Target.cosmetics.currentBodySprite.BodySprite.UpdateOutline(active ? TextOutlineColor : (Color?)null);
 }
    }

    public override void SetActive(bool visible, RoleBehaviour role)
    {
        base.SetActive(visible && !role.Player.Data.IsDead, role);
    }

    public override void CreateButton(Transform parent)
    {
        base.CreateButton(parent);
        if (Button == null || roundLockRenderer != null)
        {
            return;
        }
        var overlay = new GameObject("Eclipse.RoundOneLock");
        overlay.transform.SetParent(Button.transform, false);
        overlay.transform.localPosition = new Vector3(0f, 0f, -10f);
        overlay.layer = Button.gameObject.layer;
        roundLockRenderer = overlay.AddComponent<SpriteRenderer>();
        roundLockRenderer.sprite = RoundLock.LoadAsset();
        overlay.SetActive(false);
    }

    protected override void FixedUpdate(PlayerControl playerControl)
    {
        if (roundLockRenderer != null)
        {
            roundLockRenderer.gameObject.SetActive(FirstRoundLocked);
        }
    }
}
