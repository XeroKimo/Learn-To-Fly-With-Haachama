﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProgressState
{
    Initializing,
    Launching,
    InAir,
    End
}

public class GameState : MonoBehaviour
{
    public static GameState instance;

    [SerializeField]
    Player haachama;

    GameLaunchPad launchPad;

    List<ObstacleData> gameObstacles;
    List<GameObstacle> activeObstacles;

    [SerializeField]
    ObstacleDetector obstacleDetector;

    ProgressState currentState = ProgressState.Initializing;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        currentState = ProgressState.Launching;

        if(launchPad)
        {
            //Call launch
            launchPad.Launch(haachama);
        }
        else
        {
            Invoke("SignalLaunched", 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == ProgressState.InAir)
        {
            if(HaachamaCrashed() || HaachamaWin())
            {
                OnGameEnd();
            }
        }
    }

    void Initialize()
    {
        haachama.enabled = false;
        //Initialize Haachama

        Debug.LogError("Haachama not initialized");

        //If there is a launchpad to spawn, spawn and initialize it
        ShopLaunchPadData launchPadPrefab = UserData.instance.currentLaunchPad.launchPad;
        if(launchPadPrefab)
        {
            launchPad = Instantiate(launchPadPrefab.launchPadPrefab);
            launchPad.Initialize(UserData.instance.currentLaunchPad.currentStats, haachama);
        }

        //Have ObstacleDetector begin tracking Haachama
        obstacleDetector.TrackGameObject(haachama.gameObject);


        for(int i = 0; i < Constants.maxObstacles; i++)
        {
            //Spawn a random obstacle 
            Debug.LogError("Haachama not initialized");
        }
    }

    void OnGameEnd()
    {
        currentState = ProgressState.End;

        if(HaachamaWin())
        {
            //Display end game visual
            Debug.LogError("Not implemented");
        }
        else
        {
            //Call whoever should be handling a game end status
            Debug.LogError("Not implemented");
        }
    }

    public void SignalLaunched()
    {
        haachama.enabled = true;
        currentState = ProgressState.InAir;
    }

    public void SignalObstacleOutOfRange(GameObstacle obstacle)
    {
        //Randomly select a new obstacle
        //Randomly generate a new position
        //Copy over the new obstacle data to obstacle
        //Set obstacle's position to the new position

        Debug.LogError("Not implemented");
    }

    bool HaachamaCrashed()
    {
        return haachama.transform.position.y <= 0;
    }

    bool HaachamaWin()
    {
        return haachama.transform.position.x >= Constants.distanceToJapan;
    }
}
