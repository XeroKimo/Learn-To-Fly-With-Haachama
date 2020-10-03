using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserBoosterSlotUI : MonoBehaviour
{
    [Range(0, Constants.maxBoosterCount - 1)]
    [SerializeField]
    int boosterSlot = 0;
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI boosterName;
    [SerializeField]
    TextMeshProUGUI level;

    UserBoosterData oldBoosterData;

    public void UpdateData(UserBoosterData data)
    {
        if(data.booster.boosterName == "Default")
        {
            display.sprite = data.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            boosterName.text = "Empty";
            level.text = "";
        }
        else if(oldBoosterData != data)
        {
            display.sprite = data.booster.boosterPrefab.GetComponent<SpriteRenderer>().sprite;
            boosterName.text = data.booster.boosterName;
            level.text = "Level " + data.currentLevel;
        }
        oldBoosterData = data;
    }

    public void OpenMenu()
    {
        if(oldBoosterData.booster.boosterName == "Default")
        {
            switch(boosterSlot)
            {
            case 0:
                ShopMenu.instance.OpenShopMenu(ShopTag.Booster_1);
                break;
            case 1:
                ShopMenu.instance.OpenShopMenu(ShopTag.Booster_2);
                break;
            case 2:
                ShopMenu.instance.OpenShopMenu(ShopTag.Booster_3);
                break;
            default:
                Debug.LogError("Booster slot " + boosterSlot + " does not exist");
                break;
            }
        }
        else
        {
            switch(boosterSlot)
            {
            case 0:
                ShopMenu.instance.OpenUpgradeMenu(ShopTag.Booster_1);
                break;
            case 1:
                ShopMenu.instance.OpenUpgradeMenu(ShopTag.Booster_2);
                break;
            case 2:
                ShopMenu.instance.OpenUpgradeMenu(ShopTag.Booster_3);
                break;
            default:
                Debug.LogError("Booster slot " + boosterSlot + " does not exist");
                break;
            }
        }
    }
}
