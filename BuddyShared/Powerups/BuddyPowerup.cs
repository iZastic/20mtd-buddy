using flanne;
using UnityEngine;

namespace Buddy.Powerups;

public class BuddyPowerup : Powerup
{
    public override void Apply(GameObject target)
    {
        Instantiate(BuddyUtils.BuddyPrefab, BuddyUtils.BuddyParent.transform).SetActive(true);
    }
}
