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

    [SerializeField]
    MouseOverlapComponent upgradeButton;
    [SerializeField]
    MouseOverlapComponent downgradeButton;

    string originalText;

    private void Start()
    {
        upgradeButton.PointerEnterEvent += UpgradeButton_PointerEnterEvent;
        upgradeButton.PointerExitEvent += UpgradeButton_PointerExitEvent;

        downgradeButton.PointerEnterEvent += DowngradeButton_PointerEnterEvent; ;
        downgradeButton.PointerExitEvent += UpgradeButton_PointerExitEvent;
    }

    private void DowngradeButton_PointerEnterEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        //Downgrade
        originalText = upgradeText.text;
        upgradeText.color = Color.red;

        ShopTag tag = ShopMenu.instance.shopTag;
        switch(tag)
        {
        case ShopTag.Vehicle:
            UserVehicleData vehicleData = UserData.instance.currentVehicle;
            VehicleData nextVehicleData = vehicleData.currentStats - vehicleData.vehicle.baseUpgradeStats;
            upgradeText.text =
                "Max Speed: " + nextVehicleData.maximumSpeed +
                "\nBooster Slots: " + nextVehicleData.boosterSlots +
                "\nWeight: " + nextVehicleData.weight + "kg";

            break;
        case ShopTag.LaunchPad:
            UserLaunchPadData launchPadData = UserData.instance.currentLaunchPad;
            LaunchPadData nextLaunchPadData = launchPadData.currentStats - launchPadData.launchPad.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextLaunchPadData.power;

            break;
        case ShopTag.Booster_1:
            UserBoosterData boosterData = UserData.instance.currentBoosters[0];
            BoosterData nextBoosterData = boosterData.currentStats - boosterData.booster.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextBoosterData.power +
                "\nFuel: " + nextBoosterData.fuel +
                "\nWeight: " + nextBoosterData.weight + "kg";

            break;
        case ShopTag.Booster_2:
            boosterData = UserData.instance.currentBoosters[1];
            nextBoosterData = boosterData.currentStats - boosterData.booster.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextBoosterData.power +
                "\nFuel: " + nextBoosterData.fuel +
                "\nWeight: " + nextBoosterData.weight + "kg";

            break;
        case ShopTag.Booster_3:
            boosterData = UserData.instance.currentBoosters[2];
            nextBoosterData = boosterData.currentStats - boosterData.booster.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextBoosterData.power +
                "\nFuel: " + nextBoosterData.fuel +
                "\nWeight: " + nextBoosterData.weight + "kg";
            break;
        }
    }

    private void UpgradeButton_PointerEnterEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        //Upgrade
        originalText = upgradeText.text;
        upgradeText.color = new Color(0, 0.7f , 0);
        ShopTag tag = ShopMenu.instance.shopTag;
        switch(tag)
        {
        case ShopTag.Vehicle:
            UserVehicleData vehicleData = UserData.instance.currentVehicle;
            VehicleData nextVehicleData = vehicleData.currentStats + vehicleData.vehicle.baseUpgradeStats;
            upgradeText.text =
                "Max Speed: " + nextVehicleData.maximumSpeed +
                "\nBooster Slots: " + nextVehicleData.boosterSlots +
                "\nWeight: " + nextVehicleData.weight + "kg";

            break;
        case ShopTag.LaunchPad:
            UserLaunchPadData launchPadData = UserData.instance.currentLaunchPad;
            LaunchPadData nextLaunchPadData = launchPadData.currentStats + launchPadData.launchPad.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextLaunchPadData.power;

            break;
        case ShopTag.Booster_1:
            UserBoosterData boosterData = UserData.instance.currentBoosters[0];
            BoosterData nextBoosterData = boosterData.currentStats + boosterData.booster.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextBoosterData.power +
                "\nFuel: " + nextBoosterData.fuel +
                "\nWeight: " + nextBoosterData.weight + "kg";

            break;
        case ShopTag.Booster_2:
            boosterData = UserData.instance.currentBoosters[1];
            nextBoosterData = boosterData.currentStats + boosterData.booster.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextBoosterData.power +
                "\nFuel: " + nextBoosterData.fuel +
                "\nWeight: " + nextBoosterData.weight + "kg";

            break;
        case ShopTag.Booster_3:
            boosterData = UserData.instance.currentBoosters[2];
            nextBoosterData = boosterData.currentStats + boosterData.booster.baseUpgradeStats;

            upgradeText.text =
                "Power: " + nextBoosterData.power +
                "\nFuel: " + nextBoosterData.fuel +
                "\nWeight: " + nextBoosterData.weight + "kg";
            break;
        }

    }

    private void UpgradeButton_PointerExitEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        upgradeText.text = originalText;
        upgradeText.color = Color.black;
    }


    public void Upgrade()
    {
        ShopTag tag = ShopMenu.instance.shopTag;

        int upgradeCost = 0;
        switch(tag)
        {
        case ShopTag.Vehicle:
            upgradeCost = UserData.instance.currentVehicle.nextLevelCost;
            UserData.instance.currentVehicle.Upgrade();
            break;
        case ShopTag.LaunchPad:
            upgradeCost = UserData.instance.currentLaunchPad.nextLevelCost;
            UserData.instance.currentLaunchPad.Upgrade();
            break;
        case ShopTag.Booster_1:
            upgradeCost = UserData.instance.currentBoosters[0].nextLevelCost;
            UserData.instance.currentBoosters[0].Upgrade();
            break;
        case ShopTag.Booster_2:
            upgradeCost = UserData.instance.currentBoosters[1].nextLevelCost;
            UserData.instance.currentBoosters[1].Upgrade();
            break;
        case ShopTag.Booster_3:
            upgradeCost = UserData.instance.currentBoosters[2].nextLevelCost;
            UserData.instance.currentBoosters[2].Upgrade();
            break;
        }

        UserData.instance.currentMoney -= upgradeCost;

        RefreshDisplay();
        ShopMenu.instance.NotifyChangesMade();
    }

    public void Downgrade()
    {
        ShopTag tag = ShopMenu.instance.shopTag;

        int downgradeCost = 0;
        switch(tag)
        {
        case ShopTag.Vehicle:
            downgradeCost = UserData.instance.currentVehicle.previousLevelCost;
            UserData.instance.currentVehicle.Downgrade();
            break;
        case ShopTag.LaunchPad:
            downgradeCost = UserData.instance.currentLaunchPad.previousLevelCost;
            UserData.instance.currentLaunchPad.Downgrade();
            break;
        case ShopTag.Booster_1:
            downgradeCost = UserData.instance.currentBoosters[0].previousLevelCost;
            UserData.instance.currentBoosters[0].Downgrade();
            break;
        case ShopTag.Booster_2:
            downgradeCost = UserData.instance.currentBoosters[1].previousLevelCost;
            UserData.instance.currentBoosters[1].Downgrade();
            break;
        case ShopTag.Booster_3:
            downgradeCost = UserData.instance.currentBoosters[2].previousLevelCost;
            UserData.instance.currentBoosters[2].Downgrade();
            break;
        }

        UserData.instance.currentMoney += downgradeCost;

        RefreshDisplay();
        ShopMenu.instance.NotifyChangesMade();
    }

    public void Sell()
    {
        ShopMenu.instance.OpenShopMenu(ShopMenu.instance.shopTag);
    }

    public void RefreshDisplay()
    {
        ShopTag tag = ShopMenu.instance.shopTag;

        Button upgradeButton = this.upgradeButton.GetComponent<Button>();
        Button downgradeButton = this.downgradeButton.GetComponent<Button>();

        upgradeButton.interactable = true;
        downgradeButton.interactable = true;

        switch(tag)
        {
        case ShopTag.Vehicle:
            UserVehicleData vehicleData = UserData.instance.currentVehicle;

            itemName.text = vehicleData.vehicle.vehicleName;
            display.sprite = vehicleData.vehicle.vehiclePrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text = originalText = 
                "Max Speed: " + vehicleData.currentStats.maximumSpeed +
                "\nBooster Slots: " + vehicleData.currentStats.boosterSlots +
                "\nWeight: " + vehicleData.currentStats.weight + "kg";

            levelText.text = vehicleData.currentLevel.ToString() + "/" + Constants.maxUpgradeLevel.ToString();
            upgradeCostText.text = "$" + vehicleData.nextLevelCost;
            downgradeCostText.text = "$" + (-vehicleData.previousLevelCost);

            downgradeButton.interactable = vehicleData.currentLevel > 1;
            upgradeButton.interactable = vehicleData.currentLevel < Constants.maxUpgradeLevel;
            break;
        case ShopTag.LaunchPad:
            UserLaunchPadData launchPadData = UserData.instance.currentLaunchPad;

            itemName.text = launchPadData.launchPad.launchPadName;
            display.sprite = launchPadData.launchPad.launchPadPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text = originalText =
                "Power: " + launchPadData.currentStats.power;

            levelText.text = launchPadData.currentLevel.ToString() + "/" + Constants.maxUpgradeLevel.ToString();
            upgradeCostText.text = "$" + launchPadData.nextLevelCost;
            downgradeCostText.text = "$" + (-launchPadData.previousLevelCost);

            downgradeButton.interactable = launchPadData.currentLevel > 1;
            upgradeButton.interactable = launchPadData.currentLevel < Constants.maxUpgradeLevel;
            break;
        case ShopTag.Booster_1:
            UserBoosterData boosterData = UserData.instance.currentBoosters[0];

            itemName.text = boosterData.booster.boosterName;
            display.sprite = boosterData.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text = originalText =
                "Power: " + boosterData.currentStats.power +
                "\nFuel: " + boosterData.currentStats.fuel +
                "\nWeight: " + boosterData.currentStats.weight + "kg";

            levelText.text = boosterData.currentLevel.ToString() + "/" + Constants.maxUpgradeLevel.ToString();
            upgradeCostText.text = "$" + boosterData.nextLevelCost;
            downgradeCostText.text = "$" + (-boosterData.previousLevelCost);

            downgradeButton.interactable = boosterData.currentLevel > 1;
            upgradeButton.interactable = boosterData.currentLevel < Constants.maxUpgradeLevel;
            break;
        case ShopTag.Booster_2:
            boosterData = UserData.instance.currentBoosters[1];

            itemName.text = boosterData.booster.boosterName;
            display.sprite = boosterData.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            upgradeText.text = originalText =
                "Power: " + boosterData.currentStats.power +
                "\nFuel: " + boosterData.currentStats.fuel +
                "\nWeight: " + boosterData.currentStats.weight + "kg";

            levelText.text = boosterData.currentLevel.ToString() + "/" + Constants.maxUpgradeLevel.ToString();
            upgradeCostText.text = "$" + boosterData.nextLevelCost;
            downgradeCostText.text = "$" + (-boosterData.previousLevelCost);

            downgradeButton.interactable = boosterData.currentLevel > 1;
            upgradeButton.interactable = boosterData.currentLevel < Constants.maxUpgradeLevel;
            break;
        case ShopTag.Booster_3:
            boosterData = UserData.instance.currentBoosters[2];

            levelText.text = boosterData.currentLevel.ToString() + "/" + Constants.maxUpgradeLevel.ToString();
            itemName.text = boosterData.booster.boosterName;
            display.sprite = boosterData.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;

            upgradeText.text =originalText = 
                "Power: " + boosterData.currentStats.power + 
                "\nFuel: " + boosterData.currentStats.fuel +
                "\nWeight: " + boosterData.currentStats.weight + "kg";
            upgradeCostText.text = "$" + boosterData.nextLevelCost;
            downgradeCostText.text = "$" + (-boosterData.previousLevelCost);

            downgradeButton.interactable = boosterData.currentLevel > 1;
            upgradeButton.interactable = boosterData.currentLevel < Constants.maxUpgradeLevel;
            break;
        }
    }
}
