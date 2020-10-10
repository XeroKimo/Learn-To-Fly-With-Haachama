using System.Collections;
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
    [SerializeField]
    EndDayUI endDay;

    ProgressState currentState = ProgressState.Initializing;

    float farthestDistanceTravled;
    //Vector3 newCurrentPosition;

    private void Awake()
    {
        instance = this;
        currentState = ProgressState.Initializing;
        gameObstacles = new List<ObstacleData>(Resources.LoadAll<ObstacleData>("Obstacles"));
        //StartCoroutine(UpdatePosition());
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

            //Debug.LogWarning("Testing launching of Haachama");
            //int degree = 45;
            //haachama.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad)) * launchPad.GetStats().power, ForceMode2D.Impulse);
            Invoke("SignalLaunched", 1f);


        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == ProgressState.InAir)
        {
            if(haachama.transform.position.x > farthestDistanceTravled)
            {
                farthestDistanceTravled = haachama.transform.position.x;
            }
            if(HaachamaCrashed() || HaachamaWin() || HaachamaNoProgress())
            {
                currentState = ProgressState.End;
                Invoke("EndGame", 0.5f);
            }
        }
    }

    void Initialize()
    {
        //Initialize Haachama
        this.haachama.Initialize();

        //If there is a launchpad to spawn, spawn and initialize it
        ShopLaunchPadData launchPadPrefab = UserData.instance.currentLaunchPad.launchPad;

        launchPad = Instantiate(launchPadPrefab.launchPadPrefab);
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
            GameObstacle obstacle = Instantiate(gameObstacles[0].obstaclePrefab);
            SignalObstacleOutOfRange(obstacle);
        }
    }

    public void EndGame()
    {
        OnGameEnd();
    }

    void OnGameEnd()
    {
        Time.timeScale = 0;

        currentState = ProgressState.End;

        if(HaachamaWin())
        {
            endDay.gameObject.SetActive(true);
            endDay.DisplayResults(true);
        }
        else
        {
            endDay.gameObject.SetActive(true);
            endDay.DisplayResults(false);
        }

        UserData.instance.currentDay += 1;
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
        Vector2 minimumHalfSize = obstacleDetector.GetMinimumSize() / 2;

        float xPos;
        do
        {
            xPos = Random.Range(detectorPos.x - detectorHalfSize.x, detectorPos.x + detectorHalfSize.x);
        } while(xPos >= detectorPos.x - minimumHalfSize.x && xPos <= detectorPos.x + minimumHalfSize.x) ;

        float yPos;
        do
        {
            yPos = Random.Range(Mathf.Max(0, detectorPos.y - detectorHalfSize.y), detectorPos.y + detectorHalfSize.y);
        } while(yPos >= detectorPos.y - minimumHalfSize.y && yPos <= detectorPos.y + minimumHalfSize.y);

        obstacle.SetPosition(new Vector2(xPos, yPos));
    }

    //don't think it's necessary, HaachamaNoProgress() is doing the same thing
    bool HaachamaCrashed()
    {
        return haachama.transform.position.y <= 0;
        //return false;
    }

    bool HaachamaWin()
    {
        return haachama.transform.position.x >= Constants.distanceToJapan;
    }

    //Change in the condition for when day end
    bool HaachamaNoProgress()
    {
        return !haachama.HasFuelLeft() && haachama.GetRigidbody().velocity.x < 0.1f;
    }

    //private IEnumerator UpdatePosition()
    //{
    //    while (true)
    //    {
    //        newCurrentPosition = haachama.transform.position;
    //        yield return new WaitForSeconds(1);
    //        if (!haachama.HasFuelLeft() && newCurrentPosition == haachama.transform.position)
    //        {
    //            EndGame();
    //        }
    //    }
    //}

    public Player GetPlayer()
    {
        return haachama;
    }

    public float GetFarthestDistanceTraveled()
    {
        return farthestDistanceTravled;
    }
}
