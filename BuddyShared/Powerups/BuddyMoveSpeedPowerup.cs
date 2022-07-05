using flanne;
using UnityEngine;

namespace Buddy.Powerups;

public class BuddyMoveSpeedPowerup : Powerup
{
    public override void Apply(GameObject target)
    {
        BuddyController.moveSpeedMod.AddMultiplierBonus(0.5f);
    }
}
