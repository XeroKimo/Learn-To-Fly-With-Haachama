﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//V0.1

public class ShopBoosterUI : MonoBehaviour
{
    ShopBoosterData data;
    [SerializeField]
    Image display;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI costText;

    public void SetData(ShopBoosterData data)
    {
        this.data = data;
        display.sprite = data.displaySprite;
        nameText.text = data.boosterName;
        costText.text = data.baseCost.ToString();
    }

    public void DisplayRelativeCost(int cost)
    {
        costText.text = "$" + (data.baseCost - cost).ToString();
    }

    public ShopBoosterData GetData() { return data; }
}
