using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//V0.1

public class ShopVehicleUI : MonoBehaviour
{
    ShopVehicleData data;
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI costText;

    public void SetData(ShopVehicleData data)
    {
        this.data = data;
        display.sprite = data.vehiclePrefab.GetComponent<SpriteRenderer>().sprite;
        nameText.text = data.vehicleName;
        costText.text = data.baseCost.ToString();
    }

    public void DisplayRelativeCost(int cost)
    {
        costText.text = "$" + (data.baseCost - cost).ToString();
    }

    public ShopVehicleData GetData() { return data; }
}
