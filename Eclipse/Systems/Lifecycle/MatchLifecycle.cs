using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;

namespace Eclipse.Systems.Lifecycle;

/// <summary>
/// Solo sirve para reglas de primera ronda: no es un token de red ni sincroniza disparos.
/// Una ronda empieza tras la introducción o al volver de una reunión.
/// </summary>

public static class MatchLifecycle
{
    public static int CurrentRound { get; private set; }
    
    [RegisterEvent(-1)]
    public static void OnRoundStart(RoundStartEvent @event)
    {
        CurrentRound = @event.TriggeredByIntro ? 1 : CurrentRound + 1;
    }

    [RegisterEvent]
    public static void OnGameEnd(GameEndEvent @event)
    {
        CurrentRound = 0;
    }
}
