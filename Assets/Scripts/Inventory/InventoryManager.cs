using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    public List<InventoryItem>[] inventoryLists;


    [SerializeField] public SO_ItemList itemList = null;
    [HideInInspector] public int[] inventoryListCapacityIntArray; // the index of the array is the inventory list (from the InventoryLocation enum), and the value is the capacity of that inventory list


    protected override void Awake()
    {
        base.Awake();

        CreateInventoryLists();

        CreateitemDetailsDictionary();

    }


    private void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];
        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }

        // initialise inventory list capacity array
        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        // initialise player inventory list capacity
        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerInitialInventoryCapacity;
    }


    /// <summary>
    /// AddItem overload method to destory item when picked up.
    ///</summary>
    public void AddItem(InventoryLocation inventoryLocation, Items items, GameObject gameObjectToDestroy)
    {
        AddItem(inventoryLocation, items);
        Destroy(gameObjectToDestroy);

    }


    /// <summary>
    /// Add an item to the inventory list for the inventoryLocation
    ///</summary>
    public void AddItem(InventoryLocation inventoryLocation, Items items)
    {
        int itemID = items.ItemID;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        // Check if inventory already contains the item
        int itemPostitionInArray = FindItemInInventory(inventoryLocation, itemID);

        if (itemPostitionInArray != -1)
        {
            AddItemAtPositionInArray(inventoryList, itemID, itemPostitionInArray);
        }
        else
        {
            AddItemAtPositionInArray(inventoryList, itemID);
        }

        //Dispatch event that inventory has been updated, and update.
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }


    /// <summary>
    /// Find if an itemCode is already in the inventory. Returns the item position
    /// in the inventory list, or -1 if the item is not in the inventory
    /// </summary>    
    public int FindItemInInventory(InventoryLocation inventoryLocation, int ItemID)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        //Count does not refrence the enum. Its a property on list.
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemID == ItemID)
            {
                return i;
            }
        }
        return -1;
    }


    /// <summary>
    /// Add item to position in arry. position is comming from FindItemInInventory method.
    /// </summary>
    private void AddItemAtPositionInArray(List<InventoryItem> inventoryList, int itemID, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQuantity + 1;

        inventoryItem.itemID = itemID;
        inventoryItem.itemQuantity = 1;
        inventoryList.Add(inventoryItem);
        inventoryList[position] = inventoryItem;


        DebugPrintInventoryList(inventoryList);
    }

    /// <summary>
    /// Add item to end of the inventory array
    /// </summary>
    private void AddItemAtPositionInArray(List<InventoryItem> inventoryList, int itemID)
    {
        InventoryItem inventoryItem = new InventoryItem();

        inventoryItem.itemID = itemID;
        inventoryItem.itemQuantity = 1;
        inventoryList.Add(inventoryItem);

        DebugPrintInventoryList(inventoryList);
    }


    /// <summary>
    /// Populates the ItemsDetailsDictionary from the scriptable object items list.
    /// </summary> 
    private void CreateitemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemID, itemDetails);
            Debug.Log("ITEM STUFF!!!  " + itemDetails.itemID);
        }
    }


    /// <summary>
    /// Returns itemDetails (from the SO_ItemList) for the itemCode, or null of the item code doesn't exist.
    /// </summary>
    public ItemDetails GetItemDetails(int itemID)
    {
        ItemDetails itemDetails;

        if (itemDetailsDictionary.TryGetValue(itemID, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }

    private void DebugPrintInventoryList(List<InventoryItem> inventoryList)
    {
        foreach (InventoryItem inventoryItem in inventoryList)
        {
            Debug.Log("Item Description: " + InventoryManager.Instance.GetItemDetails(inventoryItem.itemID).itemDescription + "    Item Quantity: " + inventoryItem.itemQuantity);
        }
        Debug.Log("---------------------------------------------------------------------");
    }

}

