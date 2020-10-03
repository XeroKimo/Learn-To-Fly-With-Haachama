using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVehicle : MonoBehaviour
{
    private VehicleData stats;
    private Collider2D colliderr;
    private SpriteRenderer sprite;

    void Awake()
    {
        this.colliderr = gameObject.GetComponent<Collider2D>();
        this.sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Initialize(VehicleData data)
    {
        this.stats = data;
    }

    public VehicleData GetStats()
    {
        //stats = UserData.instance.currentVehicle.currentStats;
        return this.stats;
    }

    public Collider2D GetCollider()
    {
        return this.colliderr;
    }

    public SpriteRenderer GetSprite()
    {
        return this.sprite;
    }
}
