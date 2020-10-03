using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserVehicleSlotUI : MonoBehaviour
{
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI vehicleName;
    [SerializeField]
    TextMeshProUGUI level;

    UserVehicleData oldVehicleData;

    public void UpdateData(UserVehicleData data)
    {
        if(oldVehicleData != data)
        {
            //display.sprite = data.vehicle.vehiclePrefab.Get
        }
    }

    public void OpenMenu()
    {
        if(oldVehicleData.vehicle)
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.Vehicle);
        else
            ShopMenu.instance.OpenShopMenu(ShopTag.Vehicle);
    }
}
