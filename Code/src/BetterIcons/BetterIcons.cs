using System.Reflection;
using BepInEx;
using BetterIcons.Fix;
using BetterIcons.Fix.OABPartPickerFix;
using JetBrains.Annotations;
using SpaceWarp;
using SpaceWarp.API.Mods;
using HarmonyLib;

namespace BetterIcons;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
public class BetterIcons : BaseSpaceWarpPlugin
{
    [PublicAPI] public const string ModGuid = MyPluginInfo.PLUGIN_GUID;
    [PublicAPI] public const string ModName = MyPluginInfo.PLUGIN_NAME;
    [PublicAPI] public const string ModVer = MyPluginInfo.PLUGIN_VERSION;

    private static readonly Assembly Assembly = typeof(BetterIcons).Assembly;
    internal new static Configuration Config;

    private readonly List<BaseFix> _fixes = new();

    protected Harmony HarmonyInstance { get; }

    public override void OnInitialized()
    {
        Harmony.CreateAndPatchAll(typeof(OABPartPickerFix), (string)null);
    }

}