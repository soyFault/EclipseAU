using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using MiraAPI.Translation;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;

namespace Eclipse;

[BepInPlugin(Id, Name, Version)]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public sealed class EclipsePlugin : BasePlugin, IMiraPlugin
{
    public const string Id = "fault.eclipse";
    public const string Name = "Eclipse";
    public const string Version = "0.1.0";
    
    public Harmony Harmony { get; } = new(Id);
    
    public static BepInEx.Logging.ManualLogSource Logger { get; private set; } = null!;

    public EclipsePlugin()
    {
        MiraLocaleManager.Register(Id, "Eclipse");
    }
    public string OptionsTitleText => Name;
    
    public bool DisplayOnOptionsMenu => true;

    public ConfigFile GetConfigFile() => Config;

    public override void Load()
    {
        Logger = Log;
        Harmony.PatchAll();
        Log.LogInfo($"{Name} {Version} cargado.");
    }
}