using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalApplicationData
{
    private static bool isFirstLaunch;
    public static bool IsFirstLaunch => isFirstLaunch;

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        isFirstLaunch = ES3.Load("IsFirstLaunch", true);

        if(isFirstLaunch)
        {
            ES3.Save("IsFirstLaunch", false);
        }
    }
}
