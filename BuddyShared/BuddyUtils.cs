using flanne;
using UnityEngine;

namespace Buddy;

internal static class BuddyUtils
{
    private static GameObject _BuddyParent;
    internal static GameObject BuddyParent
    {
        get
        {
            if (_BuddyParent == null)
                _BuddyParent = new GameObject("BuddyParent");
            return _BuddyParent;
        }
    }


    private static GameObject _BuddyPrefab;
    internal static GameObject BuddyPrefab
    {
        get
        {
            if (_BuddyPrefab == null)
                _BuddyPrefab = CreateBuddyPrefab();
            return _BuddyPrefab;
        }
    }

    private static GameObject CreateBuddyPrefab()
    {
        var prefab = new GameObject("Buddy");
        prefab.tag = "Pickupper";
        prefab.AddComponent<BuddyController>();
        prefab.SetActive(false);

        var rb = prefab.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;

        var col = prefab.AddComponent<CircleCollider2D>();
        col.radius = 0.25f;

        var sr = prefab.AddComponent<SpriteRenderer>();
        sr.color = Color.cyan;
        sr.sprite = SpriteUtils.buddyIdle[0];

        var sfx = prefab.AddComponent<SpriteFX>();
        sfx.sprites = SpriteUtils.buddyIdle;
        sfx.spriteRenderer = sr;
        sfx.secPerFrame = 0.1f;
        sfx.loop = true;


        return prefab;
    }
}
