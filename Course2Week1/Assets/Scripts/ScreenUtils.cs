using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{

    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;
    static float screenMidX;
    static float screenMidY;

    public static float ScreenLeft
    {
        get { return screenLeft; }
    }

    public static float ScreenRight
    {
        get { return screenRight; }
    }

    public static float ScreenTop
    {
        get { return screenTop; }
    }

    public static float ScreenBotttom
    {
        get { return screenBottom; }
    }

    public static float ScreenMiddleX
    {
        get { return screenMidX; }
    }

    public static float ScreenMiddleY
    {
        get { return screenMidY; }
    }

    public static void Initialize()
    {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
        screenMidX = screenRight + screenLeft;
        screenMidY = screenTop + screenBottom;
    }
}
