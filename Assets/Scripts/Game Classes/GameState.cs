using System.Collections;
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
    [SerializeField]
    TrackingCamera trackingCamera;

    ProgressState currentState = ProgressState.Initializing;

    private void Awake()
    {
        instance = this;
        currentState = ProgressState.Initializing; Debug.Log(currentState);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(currentState);
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
            haachama.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.7071f, 0.7071f) * 20, ForceMode2D.Impulse);
            Invoke("SignalLaunched", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
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


        for(int i = 0; i < Constants.maxObstacles; i++)
        {
            //Initialize gameObstacles and activeObstacles
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
        UserData.instance.currentMoney += (int)haachama.transform.position.x;
        UserData.instance.currentDay += 1;

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }

    public void SignalLaunched()
    {
        haachama.enabled = true;
        currentState = ProgressState.InAir;
    }

    //I have no idea if I understood your goal for that one Xero, hope I did
    //if I didn't, sorry about that, I made it at 2AM, I barely can't keep my eyes open :O
    public void SignalObstacleOutOfRange(GameObstacle obstacle)
    {
        for (int i = 0; i < Constants.maxObstacles; i++)
        {
            if (obstacle == activeObstacles[i])
            {
                //Randomly select a new obstacle
                int rand = Random.Range(0, gameObstacles.Count);
                GameObstacle newObstacle = gameObstacles[rand].obstaclePrefab;

                //Randomly generate a new position
                Vector2 newPosition = gameObstacles[rand].maximumDistance - gameObstacles[rand].minimumDistance;

                //Copy over the new obstacle data to obstacle
                activeObstacles[i].SetObstacle(newObstacle);

                //Set obstacle's position to the new position
                activeObstacles[i].SetPosition(newPosition);
            }
        }
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
