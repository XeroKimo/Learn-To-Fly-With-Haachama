using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//V0.11

public class BoosterShop : MonoBehaviour
{
    public RectTransform content;
    public ShopBoosterUI prefab;
    List<ShopBoosterData> ShopBoosterDatas;
    public TMPro.TextMeshProUGUI contentText;

    private void Awake()
    {
        ShopBoosterDatas = new List<ShopBoosterData>(Resources.LoadAll<ShopBoosterData>("Boosters"));

        ShopBoosterDatas.Sort((ShopBoosterData lh, ShopBoosterData rh) => lh.baseCost.CompareTo(rh.baseCost));

        foreach(ShopBoosterData data in ShopBoosterDatas)
        {
            ShopBoosterUI spawnedObject = Instantiate(prefab, content);
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
        if(!obj.pointerCurrentRaycast.gameObject.GetComponent<ShopBoosterUI>())
            return;
        ShopBoosterData boosterData = obj.pointerCurrentRaycast.gameObject.GetComponent<ShopBoosterUI>().GetData();
        contentText.text =
    "Power: " + boosterData.baseStats.power +
    "\nFuel: " + boosterData.baseStats.fuel +
    "\nWeight: " + boosterData.baseStats.weight + "kg";
    }

    private void Overlap_PointerExitEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        contentText.text = "";
    }

    public void OnEnable()
    {
        int totalCost = 0;
        switch(ShopMenu.instance.shopTag)
        {
        case ShopTag.Booster_1:
            totalCost = UserData.instance.currentBoosters[0].totalCost;
            break;
        case ShopTag.Booster_2:
            totalCost = UserData.instance.currentBoosters[1].totalCost;
            break;
        case ShopTag.Booster_3:
            totalCost = UserData.instance.currentBoosters[2].totalCost;
            break;
        default:
            Debug.Log("Error, retriving bad data");
            break;
        }   

        foreach(Transform child in content)
        {
            child.GetComponent<ShopBoosterUI>().DisplayRelativeCost(totalCost);
        }
    }

    public void Buy(ShopBoosterUI booster)
    {
        int currentCost = 0;

        switch(ShopMenu.instance.shopTag)
        {
        case ShopTag.Booster_1:
            currentCost = UserData.instance.currentBoosters[0].totalCost;
            break;
        case ShopTag.Booster_2:
            currentCost = UserData.instance.currentBoosters[1].totalCost;
            break;
        case ShopTag.Booster_3:
            currentCost = UserData.instance.currentBoosters[2].totalCost;
            break;
        default:
            Debug.Log("Error, retriving bad data");
            break;
        }

        if(booster.GetData().baseCost - currentCost > UserData.instance.currentMoney)
            return;
        UserData.instance.currentMoney -= booster.GetData().baseCost - currentCost;

        switch(ShopMenu.instance.shopTag)
        {
        case ShopTag.Booster_1:
            UserData.instance.currentBoosters[0].SetBooster(booster.GetData());
            break;
        case ShopTag.Booster_2:
            UserData.instance.currentBoosters[1].SetBooster(booster.GetData());
            break;
        case ShopTag.Booster_3:
            UserData.instance.currentBoosters[2].SetBooster(booster.GetData());
            break;
        default:
            Debug.Log("Error, retriving bad data");
            break;
        }

        ShopMenu.instance.NotifyChangesMade();

        if(booster.GetData().boosterName != Constants.defaultBoosterName)
            ShopMenu.instance.OpenUpgradeMenu(ShopMenu.instance.shopTag);
        else
            ShopMenu.instance.CloseShop();
    }
}
