using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Items items = collision.GetComponent<Items>();

        if (items != null)
        {
            //Get Item Details
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(items.ItemID);

            if (itemDetails.canBePickedUp == true)
            {
                InventoryManager.Instance.AddItem(InventoryLocation.player, items, collision.gameObject);
            }
        }
    }
}
