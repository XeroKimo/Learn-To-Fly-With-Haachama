using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.14

public struct UserVehicleData
{
    public ShopVehicleData vehicle;
    public VehicleData currentStats;
    public int currentLevel;
    public int totalCost;
    public int nextLevelCost;
    public int previousLevelCost;

    public override bool Equals(object obj)
    {
        return obj is UserVehicleData data &&
               EqualityComparer<ShopVehicleData>.Default.Equals(vehicle, data.vehicle) &&
               currentLevel == data.currentLevel;
    }

    public override int GetHashCode()
    {
        int hashCode = -318742529;
        hashCode = hashCode * -1521134295 + EqualityComparer<ShopVehicleData>.Default.GetHashCode(vehicle);
        hashCode = hashCode * -1521134295 + currentLevel.GetHashCode();
        return hashCode;
    }

    public static bool operator==(UserVehicleData lh, UserVehicleData rh)
    {
        return lh.vehicle == rh.vehicle &&
            lh.currentLevel == rh.currentLevel;
    }    
    
    public static bool operator!=(UserVehicleData lh, UserVehicleData rh)
    {
        return !(lh == rh);
    }
}
