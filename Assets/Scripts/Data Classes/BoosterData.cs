using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.1

[System.Serializable]
public struct BoosterData
{
    public float power;
    public float fuel;
    public float weight;

    public static BoosterData operator +(BoosterData lh, BoosterData rh)
    {
        BoosterData data;
        data.power = lh.power + rh.power;
        data.fuel = lh.fuel + rh.fuel;
        data.weight = lh.weight + rh.weight;

        return data;
    }

    public static BoosterData operator -(BoosterData lh, BoosterData rh)
    {
        BoosterData data;
        data.power = lh.power - rh.power;
        data.fuel = lh.fuel - rh.fuel;
        data.weight = lh.weight - rh.weight;

        return data;
    }
}
