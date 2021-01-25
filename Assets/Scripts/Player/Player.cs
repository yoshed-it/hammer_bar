using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : CharacterBase
{
    public StatusBars statusBarPrefab;
    public Inventory inventoryPrefab;
    private StatusBars statusBars;
    Inventory inventory;


    void Start()
    {
        //Instantiate
        //break everything out into a new method that gets called at start.
        inventory = Instantiate(inventoryPrefab);
        statusBars = Instantiate(statusBarPrefab);

        intox = ScriptableObject.CreateInstance<Stat>();
        endurance = ScriptableObject.CreateInstance<Stat>();
        stress = ScriptableObject.CreateInstance<Stat>();

        //Intox
        intox.startValue = 0;
        intox.maxValue = 10;

        //Endurance
        endurance.startValue = 10;
        endurance.maxValue = 10;

        //Stress
        stress.startValue = 0;
        stress.maxValue = 100000;
    }

    void Update()
    {
        AdjustStressLevelOverTime(stress.currentValue);
    }


    //Need to rewrite so that its a click event. Seems silly to just run into booze. Or money. Its a comerce based game. Maybe things that NPC's drop are auto looted? But only if the character is close enough.
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
                        money += collisionObject.monetaryValue;
                        statusBars.UpdateMoneyBar(money);
                        shouldDestroy = true;
                        Debug.Log("You Stepped on " + collisionObject);
                        break;

                    case Item.ItemType.INTOX:
                        AdjustEnduranceLevel(collisionObject.quantity);
                        AdjustIntoxLevel(collisionObject.quantity);
                        statusBars.UpdateEnduranceBar(endurance.currentValue, endurance.maxValue);
                        statusBars.UpdateIntoxBar(intox.currentValue, intox.maxValue);
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
        if (intox.currentValue < intox.maxValue)
        {
            intox.currentValue += amount;
            print("You drank something, you're " + amount + " points more trashed. " + intox.currentValue);
            return true;
        }
        return false;

    }
    //TODO: Add a minimum endurance level that will knock the character out or some other action.
    public bool AdjustEnduranceLevel(int amount)
    {
        if (endurance.currentValue <= endurance.maxValue)
        {
            // Small Note for Yoshi!
            // endurance.currentValue -= amount is shorthand for endurance.currentValue = endurance.currentValue - amount;
            endurance.currentValue -= amount;
            print("Because of the booze, you've lost " + amount + " points of endurance. " + endurance.currentValue);
            print("Im amount! Im being returned! " + amount);
            return true;
        }

        return false;
    }

    public bool AdjustStressLevelOverTime(float stressTimer)
    {
        if (stress.currentValue <= stress.startValue || stress.currentValue <= stress.maxValue)
        {
            stress.currentValue += Time.deltaTime * 1000;
            return true;
        }
        return false;
    }
}
