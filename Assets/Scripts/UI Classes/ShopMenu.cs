using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum ShopTag
{
    Vehicle,
    LaunchPad,
    Booster_1,
    Booster_2,
    Booster_3
};

//V0.11

public class ShopMenu : MonoBehaviour
{
    public static ShopMenu instance;

    [SerializeField]
    TextMeshProUGUI cashText;
    [SerializeField]
    TextMeshProUGUI dayText;
    [SerializeField]
    TextMeshProUGUI weightText;

    [SerializeField]
    UserVehicleSlotUI vehicleSlot;
    [SerializeField]
    UserBoosterSlotUI[] boosterSlots = new UserBoosterSlotUI[Constants.maxBoosterCount];
    [SerializeField]
    UserLaunchPadSlotUI launchPadSlot;

    [SerializeField]
    UpgradeMenu upgradeMenu;
    [SerializeField]
    VehicleShop vehicleShop;
    [SerializeField]
    LaunchPadShop launchPadShop;
    [SerializeField]
    BoosterShop boosterShop;

    public ShopTag shopTag { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        for(int i = 0; i < Constants.maxBoosterCount; i++)
        {
            boosterSlots[i].UpdateData(UserData.instance.currentBoosters[i]);
        }
        NotifyChangesMade();
    }

    public void NotifyChangesMade()
    {
        UserData user = UserData.instance;

        //Call update on user scripts
        vehicleSlot.UpdateData(user.currentVehicle);
        for(int i = 0; i < Constants.maxBoosterCount; i++)
        {
            boosterSlots[i].UpdateData(user.currentBoosters[i]);
            boosterSlots[i].GetComponent<Button>().interactable = i < user.currentVehicle.currentStats.boosterSlots;
        }
        launchPadSlot.UpdateData(user.currentLaunchPad);

        cashText.text = "$" + user.currentMoney;
        float weight = user.currentVehicle.currentStats.weight;
        for(int i = 0; i < user.currentVehicle.currentStats.boosterSlots; i++)
        {
            weight += user.currentBoosters[i].currentStats.weight;
        }

        weightText.text = weight.ToString("F1") + "kg";
    }

    public void OpenShopMenu(ShopTag shopTag)
    {
        this.shopTag = shopTag;

        switch(shopTag)
        {
        case ShopTag.Vehicle:
            vehicleShop.gameObject.SetActive(true);
            launchPadShop.gameObject.SetActive(false);
            boosterShop.gameObject.SetActive(false);
            upgradeMenu.gameObject.SetActive(false);
            break;
        case ShopTag.LaunchPad:
            vehicleShop.gameObject.SetActive(false);
            launchPadShop.gameObject.SetActive(true);
            boosterShop.gameObject.SetActive(false);
            upgradeMenu.gameObject.SetActive(false);
            break;
        default:
            vehicleShop.gameObject.SetActive(false);
            launchPadShop.gameObject.SetActive(false);
            boosterShop.gameObject.SetActive(true);
            upgradeMenu.gameObject.SetActive(false);
            break;
        }
    }

    public void OpenUpgradeMenu(ShopTag shopTag)
    {
        this.shopTag = shopTag;
        upgradeMenu.RefreshDisplay();

        vehicleShop.gameObject.SetActive(false);
        launchPadShop.gameObject.SetActive(false);
        boosterShop.gameObject.SetActive(false);
        upgradeMenu.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        vehicleShop.gameObject.SetActive(false);
        launchPadShop.gameObject.SetActive(false);
        boosterShop.gameObject.SetActive(false);
        upgradeMenu.gameObject.SetActive(false);
    }
}
