using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//V0.11

public class LaunchPadShop : MonoBehaviour
{
    public RectTransform content;
    public ShopLaunchPadUI prefab;
    List<ShopLaunchPadData> ShopLaunchPadDatas;

    private void Awake()
    {
        ShopLaunchPadDatas = new List<ShopLaunchPadData>(Resources.LoadAll<ShopLaunchPadData>("Launch Pads"));

        ShopLaunchPadDatas.Sort((ShopLaunchPadData lh, ShopLaunchPadData rh) => lh.baseCost.CompareTo(rh.baseCost));

        foreach(ShopLaunchPadData data in ShopLaunchPadDatas)
        {
            ShopLaunchPadUI spawnedObject = Instantiate(prefab, content);
            spawnedObject.SetData(data);
            spawnedObject.GetComponent<Button>().onClick.AddListener(() => { Buy(spawnedObject); });
        }
    }

    public void OnEnable()
    {
        foreach(Transform child in content)
        {
            child.GetComponent<ShopLaunchPadUI>().DisplayRelativeCost(UserData.instance.currentVehicle.totalCost);
        }
    }

    public void Buy(ShopLaunchPadUI launchPad)
    {
        int currentCost = UserData.instance.currentVehicle.totalCost;

        UserData.instance.currentMoney += currentCost - launchPad.GetData().baseCost;
        UserData.instance.currentLaunchPad.SetLaunchPad(launchPad.GetData());

        ShopMenu.instance.NotifyChangesMade();

        if(launchPad.GetData().launchPadName != Constants.defaultLaunchPadName)
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.LaunchPad);
        else
            ShopMenu.instance.CloseShop();
    }
}
