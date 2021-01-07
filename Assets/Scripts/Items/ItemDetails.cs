using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemID;
    public ItemType ItemType;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius; //Grid based use radius
    public float itemUseRadius; //Distance based use radius
    public float itemDecayRate;
    public bool isStartingItem;
    public bool canBePickedUp;
    public bool canBeDropped;
    public bool canBeCarried;
    public bool canBeConsumed;
}