using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.15
public struct UserLaunchPadData
{
    public ShopLaunchPadData launchPad { get; private set; }
    public LaunchPadData currentStats { get; private set; }
    public int currentLevel { get; private set; }
    public int totalCost { get; private set; }
    public int nextLevelCost { get; private set; }
    public int previousLevelCost { get; private set; }

    public void SetLaunchPad(ShopLaunchPadData launchPad)
    {
        this.launchPad = launchPad;
        currentStats = launchPad.baseStats;
        currentLevel = 0;
        totalCost = launchPad.baseCost;
        previousLevelCost = 0;
        nextLevelCost = launchPad.baseUpgradeCost;
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
        return obj is UserLaunchPadData data &&
               EqualityComparer<ShopLaunchPadData>.Default.Equals(launchPad, data.launchPad) &&
               currentLevel == data.currentLevel;
    }

    public override int GetHashCode()
    {
        int hashCode = 1492755735;
        hashCode = hashCode * -1521134295 + EqualityComparer<ShopLaunchPadData>.Default.GetHashCode(launchPad);
        hashCode = hashCode * -1521134295 + currentLevel.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(UserLaunchPadData lh, UserLaunchPadData rh)
    {
        return lh.launchPad == rh.launchPad &&
            lh.currentLevel == rh.currentLevel;
    }

    public static bool operator !=(UserLaunchPadData lh, UserLaunchPadData rh)
    {
        return !(lh == rh);
    }
}
