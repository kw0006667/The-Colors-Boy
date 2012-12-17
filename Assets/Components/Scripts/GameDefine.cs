using UnityEngine;
using System.Collections;

public class GameDefine
{

    public enum RGBColors
    {
        Red = 1,
        Green = 2,
        Blue = 3,
        White = 4
    };

	public const string PLAYERNAME = "Player";

    public const string TUTORIALSCENE_1 = "TutorialScene-1";
    public const string TUTORIALSCENE_2 = "TutorialScene-2";
    public const string TUTORIALSCENE_3 = "TutorialScene-3";
    public const string SCENE_1 = "3_Scene";
    public const string SCENE_2 = "4_Scene";

    public enum ScenesName
    {
        TutorialScene_1 = 1,
        TutorialScene_2 = 2,
        TutorialScene_3 = 3,
        Scene_3 = 4,
        Scene_4 = 5
    };
}




public class Compare
{
    public static bool Color3(Color a, Color b)
    {
        return a.r.Equals(b.r) && a.g.Equals(b.g) && a.b.Equals(b.b);
    }
}