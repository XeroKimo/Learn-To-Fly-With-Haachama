using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.1

[System.Serializable]
public struct VehicleData
{
    public float maximumSpeed;
    public float weight;
    [Range(0, Constants.maxBoosterCount)]
    public int boosterSlots;

    public static VehicleData operator +(VehicleData lh, VehicleData rh)
    {
        VehicleData data;
        data.maximumSpeed = lh.maximumSpeed + rh.maximumSpeed;
        data.weight = lh.weight + rh.weight;
        data.boosterSlots = lh.boosterSlots + rh.boosterSlots;

        return data;
    }

    public static VehicleData operator -(VehicleData lh, VehicleData rh)
    {
        VehicleData data;
        data.maximumSpeed = lh.maximumSpeed - rh.maximumSpeed;
        data.weight = lh.weight - rh.weight;
        data.boosterSlots = lh.boosterSlots - rh.boosterSlots;

        return data;
    }
}
