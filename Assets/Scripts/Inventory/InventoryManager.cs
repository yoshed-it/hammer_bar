using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> ItemDetailsDictionary;

    [SerializeField] public SO_ItemList itemList = null;


    private void Start()
    {
        CreateItemDetailsDictionary();

    }

    /// <summary>
    /// Populates the ItemsDetailsDictionary from the scriptable object items list.
    /// </summary> 
    private void CreateItemDetailsDictionary()
    {
        ItemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {
            ItemDetailsDictionary.Add(itemDetails.itemID, itemDetails);
            Debug.Log("ITEM STUFF!!!  " + itemDetails.itemID);
        }
    }

    /// <summary>
    /// Returns itemDetails (from the SO_ItemList) for the itemCode, or null of the item code doesn't exist.
    /// </summary>
    public ItemDetails GetItemDetails(int itemID)
    {
        ItemDetails itemDetails;

        if (ItemDetailsDictionary.TryGetValue(itemID, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }
}

