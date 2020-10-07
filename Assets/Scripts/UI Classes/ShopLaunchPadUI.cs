using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//V0.1

public class ShopLaunchPadUI : MonoBehaviour
{
    ShopLaunchPadData data;
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI costText;

    public void SetData(ShopLaunchPadData data)
    {
        this.data = data;
        display.sprite = data.displaySprite;
        nameText.text = data.launchPadName;
        costText.text = data.baseCost.ToString();
    }

    public void DisplayRelativeCost(int cost)
    {
        costText.text = "$" + (data.baseCost - cost).ToString();
    }

    public ShopLaunchPadData GetData() { return data; }
}
