using flanne.Pickups;
using HarmonyLib;
using UnityEngine;

namespace Buddy.Patches;

[HarmonyPatch]
internal static class XPPickup_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(XPPickup), nameof(XPPickup.UsePickup))]
    private static void UsePickup(ref GameObject pickupper)
    {
        if (pickupper.name.StartsWith("Buddy"))
        {
            var bc = pickupper.GetComponent<BuddyController>();
            pickupper = bc.playerController.gameObject;
        }
    }
}
