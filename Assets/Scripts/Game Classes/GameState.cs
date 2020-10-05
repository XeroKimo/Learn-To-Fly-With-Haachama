﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    [SerializeField]
    ObstacleDetector obstacleDetector;
    [SerializeField]
    TrackingCamera trackingCamera;

    ProgressState currentState = ProgressState.Initializing;

    private void Awake()
    {
        instance = this;
        currentState = ProgressState.Initializing;
        gameObstacles = new List<ObstacleData>(Resources.LoadAll<ObstacleData>("Obstacles"));
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        currentState = ProgressState.Launching;

        if(UserData.instance.currentLaunchPad.launchPad.launchPadName != Constants.defaultLaunchPadName)
        {
            //Call launch
            launchPad.Launch(haachama);
        }
        else
        {
            haachama.enabled = true;

            Debug.LogWarning("Testing launching of Haachama");
            int degree = 45;
            haachama.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad)) * launchPad.GetStats().power, ForceMode2D.Impulse);
            Invoke("SignalLaunched", 1f);

            //EditorApplication.isPaused = true;
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
        //Initialize Haachama
        this.haachama.Initialize();

        //If there is a launchpad to spawn, spawn and initialize it
        ShopLaunchPadData launchPadPrefab = UserData.instance.currentLaunchPad.launchPad;

        launchPad = Instantiate(launchPadPrefab.launchPadPrefab, Vector3.zero, Quaternion.identity);
        launchPad.Initialize(UserData.instance.currentLaunchPad.currentStats, haachama);

        //Have ObstacleDetector begin tracking Haachama
        obstacleDetector.TrackGameObject(haachama.gameObject);
        trackingCamera.TrackGameObject(haachama.gameObject);

        Vector2 detectorPos = obstacleDetector.transform.position;
        Vector2 detectorHalfSize = obstacleDetector.GetSize() / 2;

        
        Debug.Assert(gameObstacles.Count > 0);
        for(int i = 0; i < Constants.maxObstacles; i++)
        {
            //Initialize gameObstacles and activeObstacles
            GameObstacle obstacle = Instantiate(gameObstacles[Random.Range(0, gameObstacles.Count - 1)].obstaclePrefab);

            float xPos = Random.Range(detectorPos.x - detectorHalfSize.x, detectorPos.x + detectorHalfSize.x);
            float yPos = Random.Range(Mathf.Max(0, detectorPos.y - detectorHalfSize.y), detectorPos.y + detectorHalfSize.y);
            yPos = Mathf.Clamp(yPos, 0, float.MaxValue);
            obstacle.SetPosition(new Vector2(xPos, yPos));
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

        Debug.LogWarning("Testing returning to Shop Menu");
        UserData.instance.currentMoney += Mathf.Max(0, (int)haachama.transform.position.x);
        UserData.instance.currentDay += 1;

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }

    public void SignalLaunched()
    {
        haachama.enabled = true;
        currentState = ProgressState.InAir;
    }

    public void SignalObstacleOutOfRange(GameObstacle obstacle)
    {
        obstacle.SetObstacle(gameObstacles[Random.Range(0, gameObstacles.Count - 1)].obstaclePrefab);

        Vector2 detectorPos = obstacleDetector.transform.position;
        Vector2 detectorHalfSize = obstacleDetector.GetSize() / 2;
        float xPos = Random.Range(detectorPos.x - detectorHalfSize.x, detectorPos.x + detectorHalfSize.x);
        float yPos = Random.Range(Mathf.Max(0, detectorPos.y - detectorHalfSize.y), detectorPos.y + detectorHalfSize.y);
        obstacle.SetPosition(new Vector2(xPos, yPos));
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
