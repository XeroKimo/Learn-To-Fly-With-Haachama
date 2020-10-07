using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserLaunchPadSlotUI : MonoBehaviour
{
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI launchPadName;
    [SerializeField]
    TextMeshProUGUI level;

    UserLaunchPadData oldLaunchPadData;

    public void UpdateData(UserLaunchPadData data)
    {
        if(data.launchPad.launchPadName == Constants.defaultLaunchPadName)
        {
            display.sprite = data.launchPad.displaySprite;
            launchPadName.text = "Empty";
            level.text = "";
        }
        else if(oldLaunchPadData != data)
        {
            display.sprite = data.launchPad.displaySprite;
            launchPadName.text = data.launchPad.launchPadName;
            level.text = "Level " + data.currentLevel;
        }
        oldLaunchPadData = data;
    }

    public void OpenMenu()
    {
        if(oldLaunchPadData.launchPad.launchPadName == Constants.defaultLaunchPadName)
            ShopMenu.instance.OpenShopMenu(ShopTag.LaunchPad);
        else
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.LaunchPad);
    }
}
