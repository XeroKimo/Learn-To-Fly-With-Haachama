using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.1

public class UserData : MonoBehaviour
{
    public static UserData instance;
    public UserVehicleData currentVehicle = new UserVehicleData();
    public UserBoosterData[] currentBoosters = new UserBoosterData[Constants.maxBoosterCount];
    public UserLaunchPadData currentLaunchPad = new UserLaunchPadData();
    public int currentMoney = 0;
    public int currentDay = 1;

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }
}
