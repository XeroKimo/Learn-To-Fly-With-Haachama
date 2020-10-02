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

        if (Input.GetKeyDown(KeyCode.E))
        {
            this.activeBooster.UseBooster(this.rb);
        }
    }

    public void Initialize()
    {
        //check if there's a vehicle, if yes then initialize
        ShopVehicleData vPrefab = UserData.instance.currentVehicle.vehicle;
        if (vPrefab)
        {
            this.vehicle = Instantiate(vPrefab.vehiclePrefab);
            this.vehicle.Initialize(UserData.instance.currentVehicle.currentStats);
        }

        //check if there's is boosters, if yes then initialize
        ShopBoosterData bPrefab = UserData.instance.currentBoosters[0].booster;
        if (bPrefab)
        {
            for (int i = 0; i < UserData.instance.currentBoosters.Length; i++)
            {
                //might need to do a if here in case of less booster than the max
                this.boosters[i].Initialize(UserData.instance.currentBoosters[i].currentStats);
            }
            this.boosters[0] = Instantiate(bPrefab.boosterPrefab);
            this.activeBooster = this.boosters[0];
        }
    }
}
