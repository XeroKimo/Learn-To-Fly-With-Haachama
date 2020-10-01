using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    private GameVehicle vehicle;
    private GameBooster[] boosters;
    private GameBooster activeBooster;
    private Rigidbody2D rb;

    //Temporary
    public Camera mainCamera;
    private bool spaceOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);
            rb.AddTorque(-2, ForceMode2D.Impulse);
        }
    }

    public void Initialize()
    {
        
    }
}
