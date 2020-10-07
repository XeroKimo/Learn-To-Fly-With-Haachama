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
    public TMPro.TextMeshProUGUI contentText;

    private void Awake()
    {
        ShopLaunchPadDatas = new List<ShopLaunchPadData>(Resources.LoadAll<ShopLaunchPadData>("Launch Pads"));

        ShopLaunchPadDatas.Sort((ShopLaunchPadData lh, ShopLaunchPadData rh) => lh.baseCost.CompareTo(rh.baseCost));

        foreach(ShopLaunchPadData data in ShopLaunchPadDatas)
        {
            ShopLaunchPadUI spawnedObject = Instantiate(prefab, content);
            spawnedObject.SetData(data);
            spawnedObject.GetComponent<Button>().onClick.AddListener(() => { Buy(spawnedObject); });
            MouseOverlapComponent overlap = spawnedObject.GetComponent<MouseOverlapComponent>();

            overlap.PointerEnterEvent += Overlap_PointerEnterEvent;
            overlap.PointerExitEvent += Overlap_PointerExitEvent;
        }
    }

    private void Overlap_PointerEnterEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        if(!obj.pointerCurrentRaycast.gameObject)
            return;
        if(!obj.pointerCurrentRaycast.gameObject.GetComponent<ShopLaunchPadUI>())
            return;
        ShopLaunchPadData data = obj.pointerCurrentRaycast.gameObject.GetComponent<ShopLaunchPadUI>().GetData();
        contentText.text = "Power: " + data.baseStats.power;
    }

    private void Overlap_PointerExitEvent(UnityEngine.EventSystems.PointerEventData obj)
    {

        contentText.text = "";
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

        if(launchPad.GetData().baseCost - currentCost > UserData.instance.currentMoney)
            return;
        UserData.instance.currentMoney -= launchPad.GetData().baseCost - currentCost;
        UserData.instance.currentLaunchPad.SetLaunchPad(launchPad.GetData());

        ShopMenu.instance.NotifyChangesMade();

        if(launchPad.GetData().launchPadName != Constants.defaultLaunchPadName)
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.LaunchPad);
        else
            ShopMenu.instance.CloseShop();
    }
}
