using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterManager
{


    public StatusBars intoxBarPrefab, enduranceBarPrefab, stressBarPrefab, moneyTickerPrefab;
    public Inventory inventoryPrefab;
    StatusBars intoxBar, enduranceBar, stressBar, moneyTicker;
    Inventory inventory;


    void Start()
    {
        //break everything out into a new method that gets called at start.
        inventory = Instantiate(inventoryPrefab);

        //Intox
        intoxPoints.value = startingIntoxPoints;
        intoxBar = Instantiate(intoxBarPrefab);
        intoxBar.character = this;

        //Endurance
        endurancePoints.value = startingEndurancePoints;
        enduranceBar = Instantiate(enduranceBarPrefab);
        enduranceBar.character = this;


        //Stress
        stressPoints.value = startingStressPoints;
        stressBar = Instantiate(stressBarPrefab);
        stressBar.character = this;

        //Money
        moneyTicker = Instantiate(moneyTickerPrefab);
        moneyTicker.character = this;


    }

    private void Update()
    {
        AdjustStressLevelOverTime(stressPoints.value);
    }


   // Need to rewrite so that its a click event. Seems silly to just run into booze. Or money. Its a comerce based game. Maybe things that NPC's drop are auto looted? But only if the character is close enough.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item collisionObject = collision.gameObject.GetComponent<Consumable>().item;
            if (collisionObject != null)
            {
                bool shouldDestroy = false;
                //switch statement for pattern matching. I think I can make this better.
                switch (collisionObject.itemType)
                {
                    case Item.ItemType.MONEY:
                        shouldDestroy = moneyTicker.MoneyIncrementer(collisionObject);
                        Debug.Log("You Stepped on " + collisionObject);
                        break;

                    case Item.ItemType.INTOX:
                        AdjustEnnduranceLevel(collisionObject.quantity);
                        AdjustIntoxLevel(collisionObject.quantity);
                        shouldDestroy = inventory.AddItem(collisionObject);
                        // shouldDestroy = true;
                        break;

                    default:
                        break;
                }
                if (shouldDestroy)
                {
                    Destroy(collision.gameObject);

                }
            }
        }
    }

    //Yosh -- Need to set the amount to a non random range. Get the info from the consumable.
    public bool AdjustIntoxLevel(int amount)
    {
        if (intoxPoints.value < maxIntoxPoints)
        {
            amount = Random.Range(0, 3) + 1;
            intoxPoints.value = intoxPoints.value + amount;
            print("You drank something, youre " + amount + " points more trashed. " + intoxPoints.value);


            return true;
        }
        return false;

    }
    //TODO: Add a minimum endurance level that will knock the character out or some other action.
    public bool AdjustEnnduranceLevel(int amount)
    {
        if (endurancePoints.value <= maxEndurancePoints)
        {
            endurancePoints.value = endurancePoints.value - amount;
            print("Because of the booze, youve lost " + amount + " points of endurance. " + endurancePoints.value);
            print("Im amount! Im being returned! " + amount);
            return true;
        }

        return false;
    }

    public bool AdjustStressLevelOverTime(float stressTimer)
    {
        if (stressPoints.value <= startingStressPoints || stressPoints.value <= maxStressPoints)
        {
            stressTimer = Time.deltaTime * 1000;

            stressPoints.value = stressPoints.value + stressTimer;

            return true;
        }
        return false;
    }




}