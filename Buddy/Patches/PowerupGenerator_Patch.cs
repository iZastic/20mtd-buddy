using flanne;
using HarmonyLib;
using System.Collections.Generic;

namespace Buddy.Patches;

[HarmonyPatch]
internal static class PowerupGenerator_Patch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(PowerupGenerator), nameof(PowerupGenerator.InitPowerupPool))]
    private static void InitPowerupPool(PowerupGenerator __instance)
    {
        __instance.AddToPool(new List<Powerup> {
            PowerupUtils.buddyPowerup,
            PowerupUtils.buddyTwoPowerup,
            PowerupUtils.buddyRadiusPowerup,
            PowerupUtils.buddyMoveSpeedPowerup,
        }, __instance._defaultNumTimesRepeatable);
    }
}
