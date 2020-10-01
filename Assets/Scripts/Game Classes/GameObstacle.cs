using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObstacle(GameObstacle newObstacle)
    {
        //need to implement
    }

    public void SetPosition(Vector2 NewPosition)
    {
        //need to implement
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
