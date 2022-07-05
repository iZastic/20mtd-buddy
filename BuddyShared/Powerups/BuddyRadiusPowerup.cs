using flanne;
using UnityEngine;

namespace Buddy.Powerups;

public class BuddyRadiusPowerup : Powerup
{
    public override void Apply(GameObject target)
    {
        BuddyController.radiusMod.AddMultiplierBonus(0.5f);
    }
}
