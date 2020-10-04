using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GameBooster : MonoBehaviour
{
    private BoosterData initialStats;
    private float fuelRemaining;
    private SpriteRenderer sprite;

    void Awake()
    {
        this.sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(BoosterData data)
    {
        this.initialStats = data;
    }

    public void UseBooster(Rigidbody2D rigidbody)
    {
        //Reduce fuel at a constant rate
        fuelRemaining = Mathf.Max(0, fuelRemaining - Constants.fuelConsumption * Time.deltaTime);

        //Add force in the up direction
        rigidbody.AddForce(rigidbody.transform.up * initialStats.power, ForceMode2D.Impulse);
    }

    public bool HasFuel()
    {
        if (this.fuelRemaining > 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetRemainingFuel()
    {
        return this.fuelRemaining;
    }

    public float GetFuelPercentage()
    {
        float result = this.fuelRemaining / this.initialStats.fuel; // return value between 0 and 1;
        return result;
    }

    public SpriteRenderer GetSprite()
    {
        return this.sprite;
    }

    public BoosterData GetStats()
    {
        return initialStats;
    }
}
