using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class GameObstacle : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        this.boxCollider = gameObject.GetComponent<BoxCollider2D>();
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();

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
        sprite.sprite = (newObstacle.sprite) ? newObstacle.sprite.sprite : newObstacle.GetComponentInChildren<SpriteRenderer>().sprite;
        source.clip = (newObstacle.source) ? newObstacle.source.clip : newObstacle.GetComponentInChildren<AudioSource>().clip;
        source.volume = 0.5f;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //FindObjectOfType<AudioManager>().Play(this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name);
            if (this.transform.GetChild(0).GetComponent<AudioSource>())
            {
                this.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
            Invoke("SignalOutOfRange", 1f);
        }
    }

    void SignalOutOfRange()
    {
        GameState.instance.SignalObstacleOutOfRange(this);
    }
}
