using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public ShopVehicleData defaultVehicle;
    public ShopLaunchPadData defaultLaunchPad;
    public ShopBoosterData defaultBoosterData;

    public void StartNewGame()
    {
        UserData user = UserData.instance;
        user.currentVehicle.SetVehicleData(defaultVehicle);
        user.currentLaunchPad.SetLaunchPad(defaultLaunchPad);
        for(int i = 0; i < Constants.maxBoosterCount; i++)
        {
            user.currentBoosters[i].SetBooster(defaultBoosterData);
        }
        user.currentMoney = Constants.defaultStartingCash;
        user.currentDay = 1;

        SceneManager.LoadScene("Shop Menu");
    }
}
