﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class GameObstacle : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Awake()
    {
        this.boxCollider = gameObject.GetComponent<BoxCollider2D>();
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();
        this.sprite = gameObject.GetComponent<SpriteRenderer>();

        rigidBody.gravityScale = 0;
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObstacle(GameObstacle newObstacle)
    {
        boxCollider.size = (newObstacle.boxCollider) ? newObstacle.boxCollider.size : newObstacle.GetComponent<BoxCollider2D>().size;
        rigidBody.mass = (newObstacle.rigidBody) ? newObstacle.rigidBody.mass : newObstacle.GetComponent<Rigidbody2D>().mass;
        sprite.sprite = (newObstacle.sprite) ? newObstacle.sprite.sprite : newObstacle.GetComponent<SpriteRenderer>().sprite;

        rigidBody.angularVelocity = 0;
        rigidBody.velocity = Vector3.zero;
    }

    public void SetPosition(Vector2 NewPosition)
    {
        transform.position = NewPosition;
    }

    public Collider2D GetCollider()
    {
        return this.boxCollider;
    }

    public Rigidbody2D GetRigidBody()
    {
        return this.rigidBody;
    }

    public SpriteRenderer GetSprite()
    {
        return this.sprite;
    }
}
