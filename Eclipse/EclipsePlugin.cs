using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using MiraAPI;
using MiraAPI.PluginLoading;
using Reactor;

namespace Eclipse;

[BepInPlugin(Id, Name, Version)]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
public sealed class EclipsePlugin : BasePlugin, IMiraPlugin
{
    public const string Id = "fault.eclipse";
    public const string Name = "Eclipse";
    public const string Version = "0.1.0";

    public string OptionsTitleText => Name;
    
    public bool DisplayOnOptionsMenu => false;

    public ConfigFile GetConfigFile() => Config;

    public override void Load()
    {
        Log.LogInfo($"{Name} {Version} cargado.");
    }
}