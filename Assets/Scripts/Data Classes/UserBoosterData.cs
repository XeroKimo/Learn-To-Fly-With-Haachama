using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.15
public struct UserBoosterData
{
    public ShopBoosterData booster { get; private set; }
    public BoosterData currentStats { get; private set; }
    public int currentLevel { get; private set; }
    public int totalCost { get; private set; }
    public int nextLevelCost { get; private set; }
    public int previousLevelCost { get; private set; }

    public void SetBooster(ShopBoosterData booster)
    {
        this.booster = booster;
        currentStats = booster.baseStats;
        currentLevel = 0;
        totalCost = booster.baseCost;
        previousLevelCost = 0;
        nextLevelCost = booster.baseUpgradeCost;
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
        return obj is UserBoosterData data &&
               EqualityComparer<ShopBoosterData>.Default.Equals(booster, data.booster) &&
               currentLevel == data.currentLevel;
    }

    public override int GetHashCode()
    {
        int hashCode = 2031585675;
        hashCode = hashCode * -1521134295 + EqualityComparer<ShopBoosterData>.Default.GetHashCode(booster);
        hashCode = hashCode * -1521134295 + currentLevel.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(UserBoosterData lh, UserBoosterData rh)
    {
        return lh.booster == rh.booster &&
            lh.currentLevel == rh.currentLevel;
    }

    public static bool operator !=(UserBoosterData lh, UserBoosterData rh)
    {
        return !(lh == rh);
    }
}
