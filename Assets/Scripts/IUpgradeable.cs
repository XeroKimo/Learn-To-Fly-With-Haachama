using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeable
{
    void Upgrade();
    void Downgrade();
    int GetUpgradeCost();
    int GetDowngradeCost();
    int GetSellValue();
}
