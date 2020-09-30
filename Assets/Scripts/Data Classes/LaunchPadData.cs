using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.1

[System.Serializable]
public struct LaunchPadData
{
    public float power;

    public static LaunchPadData operator +(LaunchPadData lh, LaunchPadData rh)
    {
        LaunchPadData data;
        data.power = lh.power + rh.power;

        return data;
    }

    public static LaunchPadData operator -(LaunchPadData lh, LaunchPadData rh)
    {
        LaunchPadData data;
        data.power = lh.power - rh.power;

        return data;
    }
}
