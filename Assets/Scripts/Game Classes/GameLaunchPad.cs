using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.11

public class GameLaunchPad : MonoBehaviour
{
    LaunchPadData stats;
    SpriteRenderer sprite;
    Transform startingPoint;


    public virtual void Initialize(LaunchPadData data, Player haachama)
    {
        stats = data;
        haachama.transform.position = startingPoint.position;
    }

    public virtual void Launch(Player haachama)
    {
        haachama.GetComponent<Rigidbody2D>().AddForce(Vector2.up * stats.power);
        GameState.instance.SignalLaunched();
    }
}
