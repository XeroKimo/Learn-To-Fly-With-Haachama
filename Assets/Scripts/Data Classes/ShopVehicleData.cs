using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.11

[CreateAssetMenu()]
public class ShopVehicleData : ScriptableObject
{
    public string vehicleName;
    //Stats of the object at level 1
    public VehicleData baseStats;
    //Cost of buying the object at level 1
    public int baseCost;

    //How much stats will change based on the upgrade
    public VehicleData baseUpgradeStats;

    //How much it'll cost upgrade to level 2
    public int baseUpgradeCost;
    public GameVehicle vehiclePrefab;
}
