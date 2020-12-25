using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterManager
{


    public StatusBars intoxBarPrefab;
    public Inventory inventoryPrefab;
    StatusBars intoxBar;
    Inventory inventory;


    void Start()
    {
        inventory = Instantiate(inventoryPrefab);
        intoxPoints.value = startingIntoxPoints;
        intoxBar = Instantiate(intoxBarPrefab);
        intoxBar.character = this;

    }


    //Need to rewrite so that its a click event? Maybe? seems silly to just run into booze. Or money. Its a comerce based game. Maybe things that NPC's drop are auto looted?
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item collisionObject = collision.gameObject.GetComponent<Consumable>().item;
            if (collisionObject != null)
            {
                Debug.Log("There was a collision with " + collisionObject.objectName);

                bool shouldDestroy = false;
                //switch statement for pattern matching. I think I can make this better.
                switch (collisionObject.itemType)
                {
                    case Item.ItemType.MONEY:
                        shouldDestroy = inventory.AddItem(collisionObject);
                        break;

                    case Item.ItemType.INTOX:
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

}