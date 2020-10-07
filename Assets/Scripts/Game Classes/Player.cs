using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private GameVehicle vehicle;
    private GameBooster[] boosters;
    private GameBooster activeBooster;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-2 *  rb.mass);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(2 * rb.mass);
        }


        if(activeBooster)
        {
            activeBooster.UseBooster(rb);

            if(!activeBooster.HasFuel())
            {
                activeBooster.gameObject.SetActive(false);
                rb.mass -= activeBooster.GetStats().weight;
                activeBooster = GetNextBooster();

                if(activeBooster)
                    activeBooster.gameObject.SetActive(true);
            }
        }
        //Some drag equation that doesn't exceed 1, but approaching 1 gets tougher the closer we get to it
        float basedSpeed = vehicle.GetStats().maximumSpeed * Constants.metre * 10;
        rb.drag = (1.005f - basedSpeed / (basedSpeed + rb.velocity.magnitude)) * 2;
    }

    public void Initialize()
    {
        //check if there's a vehicle, if yes then initialize
        ShopVehicleData vPrefab = UserData.instance.currentVehicle.vehicle;

        this.vehicle = Instantiate(vPrefab.vehiclePrefab, transform);
        this.vehicle.Initialize(UserData.instance.currentVehicle.currentStats);
        rb.mass = vehicle.GetStats().weight;


        int boosterCount = vehicle.GetStats().boosterSlots;
        boosters = new GameBooster[boosterCount];

        for(int i = 0; i < vehicle.GetStats().boosterSlots; i++)
        {
            //might need to do a if here in case of less booster than the max
            boosters[i] = Instantiate(UserData.instance.currentBoosters[i].booster.boosterPrefab, vehicle.GetBoosterSlot());
            boosters[i].Initialize(UserData.instance.currentBoosters[i].currentStats);
            boosters[i].gameObject.SetActive(false);
            rb.mass += boosters[i].GetStats().weight;
        }

        if(vehicle.GetStats().boosterSlots > 0)
        {
            activeBooster = boosters[0];
            activeBooster.gameObject.SetActive(true);
        }
    }

    GameBooster GetNextBooster()
    {
        foreach(GameBooster booster in boosters)
        {
            if(booster.HasFuel())
                return booster;
        }
        return null;
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }

    public bool HasFuelLeft()
    {
        if(activeBooster)
            return activeBooster.HasFuel();
        return false;
    }

    public int GetBoostersRemaining()
    {
        int boosterCount = 0;
        for(int i = 0; i < vehicle.GetStats().boosterSlots; i++)
        {
            if(boosters[i].HasFuel())
                boosterCount++;
        }
        return Mathf.Max(boosterCount - 1, 0);
    }

    public GameBooster GetActiveBooster()
    {
        return activeBooster;
    }
}
