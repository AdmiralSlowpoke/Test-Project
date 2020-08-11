using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenSizeInfo
{
    public static float ScreenHeight=Camera.main.orthographicSize;
    public static float ScreenWidth=ScreenHeight*Camera.main.aspect;
}
