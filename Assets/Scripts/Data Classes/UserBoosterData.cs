using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//0.13

public class UserBoosterData : IUpgradeable
{
    public ShopBoosterData booster;
    public BoosterData currentStats;
    public int currentLevel;
    public int totalCost;
    public int nextLevelCost;
    public int previousLevelCost;

    public void Downgrade()
    {
        //Checks to see if I'm lowest level
        //Return if I'm at lowest level

        //Worsen my overall stats
        //Change the next level and previous level cost?
        throw new System.NotImplementedException();
    }

    public int GetDowngradeCost()
    {
        return previousLevelCost;
    }

    public int GetSellValue()
    {
        return totalCost;
    }

    public int GetUpgradeCost()
    {
        return nextLevelCost;
    }

    public void Upgrade()
    {
        //Checks to see if I'm max level
        //Return if I'm at max level

        //Improve my overall stats
        //Change the next level and previous level cost?
        throw new System.NotImplementedException();
    }
}
