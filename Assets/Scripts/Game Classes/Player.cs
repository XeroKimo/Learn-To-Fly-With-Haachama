using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*From XeroKimo:
    UML used to state that it is player's responsibility to spawn and initialize the:
    - VEHICLE
    - BOOSTERS
    - LAUNCHPAD

    I have changed it so that player only need to to spawn and initialize: 
    - VEHICLE
    - BOOSTERS

    GameState is now responsible for spawning
    - LAUNCHPAD

You may delete this after you've read it
*/
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
        mainCamera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        if (Input.GetKeyDown(KeyCode.Space) && !spaceOnce)
        {
            rb.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);
            rb.AddTorque(-2, ForceMode2D.Impulse);
            spaceOnce = true;
        }
    }
}
