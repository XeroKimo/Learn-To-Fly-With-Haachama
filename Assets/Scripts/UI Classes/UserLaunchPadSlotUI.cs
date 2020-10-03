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
        if(data.launchPad.launchPadName == "Default")
        {
            display.sprite = data.launchPad.launchPadPrefab.GetComponent<SpriteRenderer>().sprite;
            launchPadName.text = "Empty";
            level.text = "";
        }
        else if(oldLaunchPadData != data)
        {
            display.sprite = data.launchPad.launchPadPrefab.GetComponent<SpriteRenderer>().sprite;
            launchPadName.text = data.launchPad.launchPadName;
            level.text = "Level " + data.currentLevel;
        }
        oldLaunchPadData = data;
    }

    public void OpenMenu()
    {
        if(oldLaunchPadData.launchPad.launchPadName == "Default")
            ShopMenu.instance.OpenShopMenu(ShopTag.LaunchPad);
        else
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.LaunchPad);
    }
}
