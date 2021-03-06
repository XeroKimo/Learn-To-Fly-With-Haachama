﻿using System.Collections;
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
        if(data.vehicle.vehicleName == Constants.defaultVehicleName)
        {
            display.sprite = data.vehicle.displaySprite;
            vehicleName.text = "Haachama";
            level.text = "";
        }
        else if(oldVehicleData != data)
        {
            display.sprite = data.vehicle.displaySprite;
            vehicleName.text = data.vehicle.vehicleName;
            level.text = "Level " + data.currentLevel;
        }
        oldVehicleData = data;
    }

    public void OpenMenu()
    {
        if(oldVehicleData.vehicle.vehicleName == Constants.defaultVehicleName)
            ShopMenu.instance.OpenShopMenu(ShopTag.Vehicle);
        else
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.Vehicle);
    }
}
