using flanne;
using flanne.Pickups;
using System.Collections.Generic;
using UnityEngine;

namespace Buddy;

public class BuddyController : MonoBehaviour
{
    internal static StatMod moveSpeedMod;
    internal static StatMod radiusMod;

    private static List<GameObject> targets;
    private static bool initialized = false;

    internal PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    private Pickup targetPickup;

    private readonly string smallXPTag = "SmallXP";
    private readonly string largeXPTag = "LargeXP";
    private readonly float moveSpeed = 3.5f;
    private readonly float radius = 6f;
    private int targetIndex;

    private void Awake()
    {
        if (!initialized)
        {
            initialized = true;
            targets = new List<GameObject>();
            moveSpeedMod = new();
            radiusMod = new();
        }

        playerController = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.position = playerController.transform.position;
    }

    private void Start()
    {
        targetIndex = targets.Count;
        targets.Add(ObjectPooler.SharedInstance.GetPooledObject(smallXPTag));
        targetPickup = targets[targetIndex].GetComponent<XPPickup>();
    }

    private void Update()
    {
        if (!targets[targetIndex].activeSelf || targetPickup.pickUpCoroutine != null)
        {
            foreach (var xp in ObjectPooler.SharedInstance.GetAllPooledObjects(smallXPTag))
                FindTarget(xp);

            foreach (var xp in ObjectPooler.SharedInstance.GetAllPooledObjects(largeXPTag))
                FindTarget(xp);
        }

        float speed;
        Vector3 direction;
        if (targets[targetIndex].activeSelf)
        {
            speed = moveSpeedMod.Modify(moveSpeed);
            direction = (targets[targetIndex].transform.position - transform.position).normalized;
        }
        else
        {
            speed = moveSpeed + playerController.stats[StatType.MoveSpeed].Modify(playerController.movementSpeed) * playerController.moveSpeedMultiplier;
            direction = (playerController.transform.position - transform.position).normalized;
        }

        var distanceToPlayer = Vector3.Distance(transform.position, playerController.transform.position);
        if (targets[targetIndex].activeSelf || distanceToPlayer > 2f)
            transform.Translate(direction * (speed * Time.deltaTime));

        spriteRenderer.flipX = direction.x < 0f;
    }

    private void OnDestroy()
    {
        initialized = false;
    }

    private void FindTarget(GameObject xp)
    {
        var pickup = xp.GetComponent<XPPickup>();

        // Skip if xp is inactive or being picked up
        if (!xp.activeSelf || pickup.pickUpCoroutine != null || targets.Contains(xp)) return;

        // Check to see if xp is within range of player
        var xpDistanceToPlayer = Vector3.Distance(xp.transform.position, playerController.transform.position);
        if (xpDistanceToPlayer > radiusMod.Modify(radius)) return;

        // If target is inactive or being picked up use this xp
        if (!targets[targetIndex].activeSelf || targetPickup.pickUpCoroutine != null)
        {
            targets[targetIndex] = xp;
            targetPickup = pickup;
            return;
        }

        // If this xp is closer than the current target choose this xp
        var distanceToTarget = Vector3.Distance(transform.position, targets[targetIndex].transform.position);
        var distanceToXp = Vector3.Distance(transform.position, xp.transform.position);
        if (distanceToXp < distanceToTarget)
        {
            targets[targetIndex] = xp;
            targetPickup = pickup;
        }
    }
}
