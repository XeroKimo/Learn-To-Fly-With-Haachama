using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.11

[RequireComponent(typeof(SpriteRenderer))]
public class GameLaunchPad : MonoBehaviour
{
    LaunchPadData stats;
    SpriteRenderer sprite;
    [SerializeField]
    Transform startingPoint;


    public virtual void Initialize(LaunchPadData data, Player haachama)
    {
        stats = data;
    }

    public virtual void Launch(Player haachama)
    {
        haachama.transform.parent = startingPoint;
        if(haachama.GetVehicle().GetCollider() is BoxCollider2D)
        {
            haachama.transform.localPosition = (haachama.GetVehicle().GetCollider() as BoxCollider2D).size / 2;
        }
        haachama.transform.parent = null;
        
        haachama.GetComponent<Rigidbody2D>().AddForce(transform.up * stats.power, ForceMode2D.Impulse);
        //Invoke("SignalLaunched", 1f);
        GameState.instance.SignalLaunched();
    }

    void SignalLaunched()
    {
        GameState.instance.SignalLaunched();

    }

    public SpriteRenderer GetSprite()
    {
        return this.sprite;
    }

    public LaunchPadData GetStats()
    {
        return stats;
    }
}
