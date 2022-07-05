using UnityEngine;

namespace Buddy;

internal static class SpriteUtils
{
    internal static Sprite buddyIcon;
    internal static Sprite buddyMoveSpeedIcon;
    internal static Sprite buddyRadiusIcon;
    internal static Sprite buddyTwoIcon;
    internal static Sprite[] buddyIdle;

    static SpriteUtils()
    {
        buddyIcon = CreateSprite(Properties.Resources.buddy);
        buddyMoveSpeedIcon = CreateSprite(Properties.Resources.buddy_move_speed);
        buddyRadiusIcon = CreateSprite(Properties.Resources.buddy_radius);
        buddyTwoIcon = CreateSprite(Properties.Resources.buddy_two);
        buddyIdle = new Sprite[6];

        foreach (var sprite in Resources.FindObjectsOfTypeAll<Sprite>())
        {
            switch (sprite.name)
            {
                case "GhostPetIdle_0":
                    buddyIdle[0] = sprite;
                    break;
                case "GhostPetIdle_1":
                    buddyIdle[1] = sprite;
                    break;
                case "GhostPetIdle_2":
                    buddyIdle[2] = sprite;
                    break;
                case "GhostPetIdle_3":
                    buddyIdle[3] = sprite;
                    break;
                case "GhostPetIdle_4":
                    buddyIdle[4] = sprite;
                    break;
                case "GhostPetIdle_5":
                    buddyIdle[5] = sprite;
                    break;
            }
        }
    }

    private static Sprite CreateSprite(byte[] bytes)
    {
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point;
        texture.LoadImage(bytes);
        return Sprite.Create(
            texture,
            new Rect
            {
                width = texture.width,
                height = texture.height,
            },
            new Vector2(0.5f, 0.5f),
            32
        );
    }
}
