using Eclipse.Options;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameOptions;
using UnityEngine;

namespace Eclipse.Roles.Classic.Crewmate.Killing.Sheriff;

public static class SheriffEvents
{
    [RegisterEvent]
    public static void OnRoundStart(RoundStartEvent @event)
    {
        if (!@event.TriggeredByIntro)
        {
            return; 
        }
        foreach (var player in PlayerControl.AllPlayerControls)
        {
            if (player.Data?.Role is SheriffRole sheriff)
            {
                sheriff.ResetMisfire();
            }
        }
    }

    [RegisterEvent]
    public static void OnAfterMurder(AfterMurderEvent @event)
    {
        if (!@event.Source.AmOwner || @event.Source.Data?.Role is not SheriffRole ||
            @event.Source.PlayerId == @event.Target.PlayerId || @event.DeadBody == null ||
            OptionGroupSingleton<SheriffOptions>.Instance.SheriffBodyReport)
        {
            return;
        }
        @event.DeadBody.gameObject.layer = LayerMask.NameToLayer("Ship");
        @event.DeadBody.Reported = true;
    }
}