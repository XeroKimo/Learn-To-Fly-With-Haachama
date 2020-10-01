﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//V0.1

public class ObstacleDetector : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Transform trackingObject;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(trackingObject)
            transform.position = trackingObject.position;
    }

    public void TrackGameObject(GameObject gameObject)
    {
        trackingObject = gameObject.transform;
        if(trackingObject)
            transform.position = trackingObject.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObstacle obstacle = collision.GetComponent<GameObstacle>();
        if(obstacle)
        {
            GameState.instance.SignalObstacleOutOfRange(obstacle);
        }
    }
}
