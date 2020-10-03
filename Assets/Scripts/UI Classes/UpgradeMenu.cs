using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI itemName;
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI upgradeText;

    [SerializeField]
    TextMeshProUGUI levelText;
    [SerializeField]
    TextMeshProUGUI upgradeCostText;
    [SerializeField]
    TextMeshProUGUI downgradeCostText;

    public void OnEnable()
    {
        RefreshDisplay();
    }

    public void Upgrade()
    {
        ShopTag tag = ShopMenu.instance.shopTag;

        switch(tag)
        {
        case ShopTag.Vehicle:
            UserData.instance.currentVehicle.Upgrade();
            break;
        case ShopTag.LaunchPad:
            UserData.instance.currentLaunchPad.Upgrade();
            break;
        case ShopTag.Booster_1:
            UserData.instance.currentBoosters[0].Upgrade();
            break;
        case ShopTag.Booster_2:
            UserData.instance.currentBoosters[1].Upgrade();
            break;
        case ShopTag.Booster_3:
            UserData.instance.currentBoosters[2].Upgrade();
            break;
        }

        RefreshDisplay();
    }

    public void Downgrade()
    {
        ShopTag tag = ShopMenu.instance.shopTag;

        switch(tag)
        {
        case ShopTag.Vehicle:
            UserData.instance.currentVehicle.Downgrade();
            break;
        case ShopTag.LaunchPad:
            UserData.instance.currentLaunchPad.Downgrade();
            break;
        case ShopTag.Booster_1:
            UserData.instance.currentBoosters[0].Downgrade();
            break;
        case ShopTag.Booster_2:
            UserData.instance.currentBoosters[1].Downgrade();
            break;
        case ShopTag.Booster_3:
            UserData.instance.currentBoosters[2].Downgrade();
            break;
        }

        RefreshDisplay();
    }

    public void Sell()
    {
        ShopMenu.instance.OpenShopMenu(ShopMenu.instance.shopTag);
    }

    private void RefreshDisplay()
    {
        ShopTag tag = ShopMenu.instance.shopTag;

        switch(tag)
        {
        case ShopTag.Vehicle:
            UserVehicleData vehicleData = UserData.instance.currentVehicle;

            itemName.text = vehicleData.vehicle.vehicleName;
            display.sprite = vehicleData.vehicle.vehiclePrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text =
                "Max Speed: " + vehicleData.currentStats.maximumSpeed;
            break;
        case ShopTag.LaunchPad:
            UserLaunchPadData launchPadData = UserData.instance.currentLaunchPad;

            itemName.text = launchPadData.launchPad.launchPadName;
            display.sprite = launchPadData.launchPad.launchPadPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text =
                "Power: " + launchPadData.currentStats.power;
            break;
        case ShopTag.Booster_1:
            UserBoosterData boosterData = UserData.instance.currentBoosters[0];

            itemName.text = boosterData.booster.boosterName;
            display.sprite = boosterData.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text =
                "Power: " + boosterData.currentStats.power + "\n" +
                "Fuel: " + boosterData.currentStats.fuel;
            break;
        case ShopTag.Booster_2:
            boosterData = UserData.instance.currentBoosters[1];

            itemName.text = boosterData.booster.boosterName;
            display.sprite = boosterData.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text =
                "Power: " + boosterData.currentStats.power + "\n" +
                "Fuel: " + boosterData.currentStats.fuel;
            break;
        case ShopTag.Booster_3:
            boosterData = UserData.instance.currentBoosters[2];

            itemName.text = boosterData.booster.boosterName;
            display.sprite = boosterData.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text =
                "Power: " + boosterData.currentStats.power + "\n" +
                "Fuel: " + boosterData.currentStats.fuel;
            break;
        }
    }
}
