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


}


public class Compare
{
    public static bool Color3(Color a, Color b)
    {
        return a.r.Equals(b.r) && a.g.Equals(b.g) && a.b.Equals(b.b);
    }
}