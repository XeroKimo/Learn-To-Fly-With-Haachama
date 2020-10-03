using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.11

[CreateAssetMenu]
public class ShopBoosterData : ScriptableObject
{
    public string boosterName;
    //Stats of the object at level 1
    public BoosterData baseStats;
    //Cost of buying the object at level 1
    public int baseCost;

    //How much stats will change based on the upgrade
    public BoosterData baseUpgradeStats;

    //How much it'll cost upgrade to level 2
    public int baseUpgradeCost;
    public GameBooster boosterPrefab;
}
