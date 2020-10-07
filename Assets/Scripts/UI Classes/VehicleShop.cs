using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//V0.11

public class VehicleShop : MonoBehaviour
{
    public RectTransform content;
    public ShopVehicleUI prefab;
    List<ShopVehicleData> shopVehicleDatas;
    public TMPro.TextMeshProUGUI contentText;

    private void Awake()
    {
        shopVehicleDatas = new List<ShopVehicleData>(Resources.LoadAll<ShopVehicleData>("Vehicles"));

        shopVehicleDatas.Sort((ShopVehicleData lh, ShopVehicleData rh) => lh.baseCost.CompareTo(rh.baseCost));

        foreach(ShopVehicleData data in shopVehicleDatas)
        {
            ShopVehicleUI spawnedObject = Instantiate(prefab, content);
            spawnedObject.SetData(data);
            spawnedObject.GetComponent<Button>().onClick.AddListener(()=> { Buy(spawnedObject); });
            MouseOverlapComponent overlap = spawnedObject.GetComponent<MouseOverlapComponent>();

            overlap.PointerEnterEvent += Overlap_PointerEnterEvent;
            overlap.PointerExitEvent += Overlap_PointerExitEvent;
        }
    }

    private void Overlap_PointerEnterEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        if(!obj.pointerCurrentRaycast.gameObject)
            return;
        if(!obj.pointerCurrentRaycast.gameObject.GetComponent<ShopVehicleUI>())
            return;
        ShopVehicleData vehicleData = obj.pointerCurrentRaycast.gameObject.GetComponent<ShopVehicleUI>().GetData();
        contentText.text =
    "Max Speed: " + vehicleData.baseStats.maximumSpeed +
    "\nBooster Slots: " + vehicleData.baseStats.boosterSlots +
    "\nWeight: " + vehicleData.baseStats.weight + "kg";
    }

    private void Overlap_PointerExitEvent(UnityEngine.EventSystems.PointerEventData obj)
    {
        contentText.text = "";
    }

    public void OnEnable()
    {
        foreach(Transform child in content)
        {
            child.GetComponent<ShopVehicleUI>().DisplayRelativeCost(UserData.instance.currentVehicle.totalCost);
        }
    }

    public void Buy(ShopVehicleUI vehicle)
    {
        int currentCost = UserData.instance.currentVehicle.totalCost;

        if(vehicle.GetData().baseCost - currentCost > UserData.instance.currentMoney)
            return;
        UserData.instance.currentMoney -= vehicle.GetData().baseCost - currentCost;
        UserData.instance.currentVehicle.SetVehicleData(vehicle.GetData());

        ShopMenu.instance.NotifyChangesMade();

        if(vehicle.GetData().vehicleName != Constants.defaultVehicleName)
            ShopMenu.instance.OpenUpgradeMenu(ShopTag.Vehicle);
        else
            ShopMenu.instance.CloseShop();
    }
}
