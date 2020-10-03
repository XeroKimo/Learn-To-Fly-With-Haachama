using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.15

public struct UserVehicleData
{
    public ShopVehicleData vehicle { get; private set; }
    public VehicleData currentStats { get; private set; }
    public int currentLevel { get; private set; }
    public int totalCost { get; private set; }
    public int nextLevelCost { get; private set; }
    public int previousLevelCost { get; private set; }

    public void SetVehicleData(ShopVehicleData vehicle)
    {
        this.vehicle = vehicle;
        currentStats = vehicle.baseStats;
        currentLevel = 0;
        totalCost = vehicle.baseCost;
        previousLevelCost = 0;
        nextLevelCost = vehicle.baseUpgradeCost;
    }

    public void Upgrade()
    {
        Debug.LogError("Not implemented");
    }

    public void Downgrade()
    {
        Debug.LogError("Not implemented");
    }

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

    public static bool operator ==(UserVehicleData lh, UserVehicleData rh)
    {
        return lh.vehicle == rh.vehicle &&
            lh.currentLevel == rh.currentLevel;
    }

    public static bool operator !=(UserVehicleData lh, UserVehicleData rh)
    {
        return !(lh == rh);
    }
}
