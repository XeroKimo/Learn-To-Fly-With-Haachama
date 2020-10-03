using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//V0.11

public class VehicleShop : MonoBehaviour
{
    public RectTransform content;
    public ShopVehicleUI prefab;
    List<ShopVehicleData> shopVehicleDatas;

    private void Awake()
    {
        shopVehicleDatas = new List<ShopVehicleData>(Resources.LoadAll<ShopVehicleData>("Vehicles"));

        shopVehicleDatas.Sort((ShopVehicleData lh, ShopVehicleData rh) => lh.baseCost.CompareTo(rh.baseCost));

        foreach(ShopVehicleData data in shopVehicleDatas)
        {
            ShopVehicleUI spawnedObject = Instantiate(prefab, content);
            spawnedObject.SetData(data);
            spawnedObject.GetComponent<Button>().onClick.AddListener(()=> { Buy(spawnedObject); });
        }
    }

    public void OnEnable()
    {
        foreach(Transform child in content)
        {
            child.GetComponent<ShopVehicleUI>().DisplayRelativeCost(UserData.instance.currentVehicle.totalCost);
        }
    }

    public void Buy(ShopVehicleUI vehicle)
    {
        int currentCost = UserData.instance.currentVehicle.totalCost;

        UserData.instance.currentMoney += currentCost - vehicle.GetData().baseCost;
        UserData.instance.currentVehicle.SetVehicleData(vehicle.GetData());

        ShopMenu.instance.NotifyChangesMade();

        if(vehicle.GetData().vehicleName != Constants.defaultVehicleName)
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.Vehicle);
        else
            ShopMenu.instance.CloseShop();
    }
}
