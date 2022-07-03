using Buddy.Powerups;
using flanne;
using System.Collections.Generic;
using UnityEngine;

namespace Buddy;

internal static class PowerupUtils
{
    internal static Powerup buddyPowerup;
    internal static Powerup buddyRadiusPowerup;
    internal static Powerup buddyMoveSpeedPowerup;
    internal static Powerup buddyTwoPowerup;
    internal static PowerupTreeUIData powerupTreeUIData;

    static PowerupUtils()
    {
        powerupTreeUIData = ScriptableObject.CreateInstance<PowerupTreeUIData>();

        CreateBuddyPowerup();
        CreateBuddyRadiusPowerup();
        CreateBuddyMoveSpeedPowerup();
        CreateBuddyTwoPowerup();

        powerupTreeUIData.startingPowerup = buddyPowerup;
        powerupTreeUIData.leftPowerup = buddyRadiusPowerup;
        powerupTreeUIData.rightPowerup = buddyMoveSpeedPowerup;
        powerupTreeUIData.finalPowerup = buddyTwoPowerup;
    }

    private static void CreateBuddyPowerup()
    {
        buddyPowerup = ScriptableObject.CreateInstance<BuddyPowerup>();
        buddyPowerup.prereqs = new List<Powerup>();
        buddyPowerup.icon = SpriteUtils.buddyIcon;
        buddyPowerup.powerupTreeUIData = powerupTreeUIData;

        buddyPowerup.nameStringID = "buddy_name";
        LocalizationUtils.AddKey("buddy_name", new LocalizationUtils.LocalizationValues
        {
            EN = "Buddy",
            JP = "バディ",
            CH = "伙伴",
            BR = "Companheiro",
            TC = "夥伴",
            RU = "Приятель",
            SP = "Compañero",
            GR = "Kumpel",
            PL = "Kumpel",
            IT = "Compagno",
            TR = "Ahbap",
            FR = "Copain",
        });

        buddyPowerup.descriptionStringID = "buddy_description";
        LocalizationUtils.AddKey("buddy_description", new LocalizationUtils.LocalizationValues
        {
            EN = "Summon a buddy to collect experience for you.",
            JP = "バディを召喚して経験値を集めましょう",
            CH = "召唤小伙伴为你积累经验",
            BR = "Convoque um amigo para coletar experiência para você.",
            TC = "召喚小伙伴為你積累經驗",
            RU = "Призвать друга, чтобы он собирал для вас опыт.",
            SP = "Convoca a un amigo para recopilar experiencia para ti.",
            GR = "Rufe einen Kumpel herbei, um Erfahrung für dich zu sammeln.",
            PL = "Wezwij kumpla, aby zebrać dla ciebie doświadczenie.",
            IT = "Evoca un amico per raccogliere esperienza per te.",
            TR = "Sizin için deneyim toplaması için bir arkadaş çağırın.",
            FR = "Invoquez un copain pour accumuler de l'expérience pour vous.",
        });
    }

    private static void CreateBuddyRadiusPowerup()
    {
        buddyRadiusPowerup = ScriptableObject.CreateInstance<BuddyRadiusPowerup>();
        buddyRadiusPowerup.prereqs = new List<Powerup> { buddyPowerup };
        buddyRadiusPowerup.icon = SpriteUtils.buddyRadiusIcon;
        buddyRadiusPowerup.powerupTreeUIData = powerupTreeUIData;

        buddyRadiusPowerup.nameStringID = "buddy_radius_name";
        LocalizationUtils.AddKey("buddy_radius_name", new LocalizationUtils.LocalizationValues
        {
            EN = "Buddy Collection Radius",
            JP = "バディコレクション半径",
            CH = "好友集合半径",
            BR = "Raio de Coleta de Amigos",
            TC = "好友收集半徑",
            RU = "Радиус коллекции друзей",
            SP = "Radio de colección de amigos",
            GR = "Kumpel Sammelradius",
            PL = "Promień kolekcji znajomych",
            IT = "Raggio di raccolta Buddy",
            TR = "Arkadaş Koleksiyonu Yarıçapı",
            FR = "Rayon de collecte des amis",
        });

        buddyRadiusPowerup.descriptionStringID = "buddy_radius_description";
        LocalizationUtils.AddKey("buddy_radius_description", new LocalizationUtils.LocalizationValues
        {
            EN = "Increases the radius that buddy can collect experience.",
            JP = "バディが経験値を収集できる半径を増やします",
            CH = "增加好友可以收集经验的范围",
            BR = "Aumenta o raio que o amigo pode coletar experiência.",
            TC = "增加好友可以收集經驗的範圍",
            RU = "Увеличивает радиус, в котором приятель может собирать опыт.",
            SP = "Aumenta el radio en el que el amigo puede acumular experiencia.",
            GR = "Erhöht den Radius, in dem der Kumpel Erfahrung sammeln kann.",
            PL = "Zwiększa promień, w jakim kumpel może zbierać doświadczenie.",
            IT = "Aumenta il raggio che un amico può raccogliere esperienza.",
            TR = "Arkadaşın deneyim toplayabileceği yarıçapı artırır.",
            FR = "Augmente le rayon que le copain peut accumuler de l'expérience.",
        });
    }

    private static void CreateBuddyMoveSpeedPowerup()
    {
        buddyMoveSpeedPowerup = ScriptableObject.CreateInstance<BuddyMoveSpeedPowerup>();
        buddyMoveSpeedPowerup.prereqs = new List<Powerup> { buddyPowerup };
        buddyMoveSpeedPowerup.icon = SpriteUtils.buddyMoveSpeedIcon;
        buddyMoveSpeedPowerup.powerupTreeUIData = powerupTreeUIData;

        buddyMoveSpeedPowerup.nameStringID = "buddy_move_speed_name";
        LocalizationUtils.AddKey("buddy_move_speed_name", new LocalizationUtils.LocalizationValues
        {
            EN = "Buddy Move Speed",
            JP = "バディ移動速度",
            CH = "伙伴移动速度",
            BR = "Velocidade de Movimento do Companheiro",
            TC = "夥伴移動速度",
            RU = "Скорость движения приятеля",
            SP = "Velocidad de movimiento del compañero",
            GR = "Kumpel Bewegungsgeschwindigkeit",
            PL = "Szybkość ruchu kumpla",
            IT = "Velocità di movimento del compagno",
            TR = "Dostum Hareket Hızı",
            FR = "Vitesse de déplacement du copain",
        });

        buddyMoveSpeedPowerup.descriptionStringID = "buddy_move_speed_description";
        LocalizationUtils.AddKey("buddy_move_speed_description", new LocalizationUtils.LocalizationValues
        {
            EN = "Increases the speed that buddy moves at.",
            JP = "バディが移動する速度を上げます",
            CH = "增加伙伴移动的速度",
            BR = "Aumenta a velocidade com que o amigo se move.",
            TC = "增加夥伴移動的速度",
            RU = "Увеличивает скорость, с которой движется приятель",
            SP = "Aumenta la velocidad a la que se mueve el amigo",
            GR = "Erhöht die Geschwindigkeit, mit der sich der Kumpel bewegt.",
            PL = "Zwiększa prędkość poruszania się kumpla.",
            IT = "Aumenta la velocità a cui si muove il compagno.",
            TR = "Arkadaşın hareket ettiği hızı artırır.",
            FR = "Augmente la vitesse à laquelle le copain se déplace.",
        });
    }

    private static void CreateBuddyTwoPowerup()
    {
        buddyTwoPowerup = ScriptableObject.CreateInstance<BuddyPowerup>();
        buddyTwoPowerup.prereqs = new List<Powerup> { buddyRadiusPowerup, buddyMoveSpeedPowerup };
        buddyTwoPowerup.anyPrereqFulfill = true;
        buddyTwoPowerup.icon = SpriteUtils.buddyTwoIcon;
        buddyTwoPowerup.powerupTreeUIData = powerupTreeUIData;

        buddyTwoPowerup.nameStringID = "buddy_two_name";
        LocalizationUtils.AddKey("buddy_two_name", new LocalizationUtils.LocalizationValues
        {
            EN = "Another Buddy",
            JP = "別の相棒",
            CH = "另一个好友",
            BR = "Outro amigo",
            TC = "另一個好友",
            RU = "Другой приятель",
            SP = "otro amigo",
            GR = "Noch ein Kumpel",
            PL = "Inny kumpel",
            IT = "Un altro amico",
            TR = "başka bir arkadaş",
            FR = "Un autre copain",
        });

        buddyTwoPowerup.descriptionStringID = "buddy_two_description";
        LocalizationUtils.AddKey("buddy_two_description", new LocalizationUtils.LocalizationValues
        {
            EN = "Summons a second buddy to help collect experience.",
            JP = "経験値を集めるのを助けるために2番目の仲間を召喚します",
            CH = "召唤第二个伙伴帮助收集经验",
            BR = "Convoca um segundo amigo para ajudar a coletar experiência.",
            TC = "召喚第二個夥伴幫助收集經驗",
            RU = "Призывает второго напарника для сбора опыта.",
            SP = "Invoca a un segundo compañero para que te ayude a acumular experiencia.",
            GR = "Ruft einen zweiten Kumpel herbei, um beim Sammeln von Erfahrung zu helfen.",
            PL = "Przyzywa drugiego kumpla, aby pomógł zebrać doświadczenie.",
            IT = "Evoca un secondo amico per raccogliere esperienza.",
            TR = "Deneyim toplamaya yardımcı olması için ikinci bir arkadaş çağırır.",
            FR = "Invoque un deuxième copain pour l'aider à accumuler de l'expérience.",
        });
    }
}
