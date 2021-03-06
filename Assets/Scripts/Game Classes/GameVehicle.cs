﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameVehicle : MonoBehaviour
{
    private VehicleData stats;
    private Collider2D collider;
    private SpriteRenderer sprite;

    [SerializeField]
    Transform boosterSlot;

    void Awake()
    {
        this.collider = gameObject.GetComponent<Collider2D>();
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
        return this.collider;
    }

    public SpriteRenderer GetSprite()
    {
        return this.sprite;
    }
    public Transform GetBoosterSlot()
    {
        return boosterSlot;
    }
}
