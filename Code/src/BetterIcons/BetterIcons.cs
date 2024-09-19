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

    /*private void Awake()
    {
        Type[] types;
        try
        {
            types = Assembly.GetTypes();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Could not get types: ${ex.Message}");
            return;
        }

        Config = new Configuration(base.Config);

        foreach (var type in types)
        {
            if (type.IsAbstract || !type.IsSubclassOf(typeof(BaseFix)))
            {
                continue;
            }

            try
            {
                var isLoaded = LoadFix(type);
                Logger.LogInfo($"Fix {type.Name} is " + (isLoaded ? "enabled" : "disabled"));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error loading fix {type.FullName}: {ex}");
            }
        }

        Logger.LogInfo($"{ModName} finished loading.");
    }*/

    public override void OnInitialized()
    {
        //HarmonyInstance = new Harmony(GetType().FullName);
        //HarmonyInstance.PatchAll(typeof(OABPartPickerFix));
        Harmony.CreateAndPatchAll(typeof(OABPartPickerFix), (string)null);
        //foreach (var fix in _fixes)
        //{
        //  fix.OnInitialized();
        //}
    }

    /*private bool LoadFix(Type type)
    {
        if (!Config.IsFixEnabled(type))
        {
            return false;
        }

        var fix = gameObject.AddComponent(type) as BaseFix;
        if (fix == null)
        {
            throw new Exception($"Could not instantiate fix {type.Name}.");
        }

        fix.transform.parent = transform;
        _fixes.Add(fix);

        return true;
    }*/
}