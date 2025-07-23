using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace YogurtCommercial_EnsureSpeedHat;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class FirstHatOverridePlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    internal static ConfigEntry<int> configHatIndex;
    internal static ConfigEntry<int> configOccurrenceIndex;

    internal static int occurrences = 0;

    private void Awake()
    {
        Logger = base.Logger;

        configHatIndex = Config.Bind("Hat", "HatIndex", 4, "Hat index to spawn. Default value is the index of the speed hat.");
        configOccurrenceIndex = Config.Bind("Hat", "OccurrenceIndex", 0, "How many random npc occurrences until we get our confirmed hat.");

        Harmony harmony = new Harmony("com.yourname.firsthatoverride");
        harmony.PatchAll();

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }

    [HarmonyPatch(typeof(GameManager), "NewGame")]
    public static class NewGamePatch
    {
        [HarmonyPrefix]
        public static void ResetOccurrencesPostfix()
        {
            Logger.LogInfo("New Game: Resetting occurrences to 0.");
            occurrences = 0;
        }
    }

    [HarmonyPatch(typeof(PersonRandomizer), "LateUpdate")]
    public static class FirstHatSimplifierPatch
    {
        [HarmonyPrefix]
        public static void ForceFirstHatPrefix(PersonRandomizer __instance)
        {
            if (configOccurrenceIndex.Value > occurrences)
                return;

            if (__instance.randomHats == null)
                return;

            if (__instance.randomHats.Count <= configHatIndex.Value)
                return;

            if (configOccurrenceIndex.Value == occurrences)
            {
                __instance.randomHatProbability = 1.0f;
                __instance.randomHats = new List<Hat> { __instance.randomHats[configHatIndex.Value] };
                Logger.LogInfo($"Set hat index {configHatIndex.Value} on occurrence index {configOccurrenceIndex.Value}");
            }

            occurrences++;
        }
    }
}
