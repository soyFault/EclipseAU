
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using Eclipse.Roles.Classic.Crewmate.Killing.Sheriff;

namespace Eclipse.Options;

public sealed class SheriffOptions : AbstractRoleOptionGroup<SheriffRole>
{
    public override string GroupName => MiraLocaleManager.Get("Eclipse.Role.Sheriff");

    [ModdedNumberOption("Eclipse.Sheriff.Options.Cooldown", 5f, 120f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float KillCooldown { get; set; } = 25f;

    [ModdedToggleOption("Eclipse.Sheriff.Options.BodyReport")]
    public bool SheriffBodyReport { get; set; } = false;

    [ModdedToggleOption("Eclipse.Sheriff.Options.FirstRound")]
    public bool FirstRoundUse { get; set; } = false;

    [ModdedToggleOption("Eclipse.Sheriff.Options.NeutralBenign")]
    public bool ShootNeutralBenign { get; set; } = false;
    [ModdedToggleOption("Eclipse.Sheriff.Options.NeutralEvil")]
    public bool ShootNeutralEvil { get; set; } = true;
    [ModdedToggleOption("Eclipse.Sheriff.Options.NeutralKilling")]
    public bool ShootNeutralKilling { get; set; } = true;
    [ModdedToggleOption("Eclipse.Sheriff.Options.NeutralOutlier")]
    public bool ShootNeutralOutlier { get; set; } = true;

    [ModdedEnumOption("Eclipse.Sheriff.Options.Misfire", typeof(MisfireOptions), new[]
    {
        "Eclipse.Sheriff.Misfire.Sheriff", "Eclipse.Sheriff.Misfire.Target",
        "Eclipse.Sheriff.Misfire.Both", "Eclipse.Sheriff.Misfire.Nobody",
    })]
    public MisfireOptions MisfireType { get; set; } = MisfireOptions.Sheriff;
}
