using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryHotBarUI : MonoBehaviour
{
 [SerializeField] private InventorySlotUI[] inventorySlot = null;

 public void AddItem(List<InventoryItem> inventoryList) //ItemID and ItemQuantity
 {
     if (inventorySlot.Length > 0 && inventoryList.Count > 0)
     {
         for ( int i = 0; i < inventorySlot.Length; i++)
         {
             if (i < inventoryList.Count) 
             {
                 int itemId = inventoryList[i].itemID;

                 ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemId);

                 if( itemDetails != null)
                 {
                     inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                     inventorySlot[i].textMeshProUGUI.text = inventoryList[i].itemQuantity.ToString();
                     inventorySlot[i].itemDetails = itemDetails;
                     inventorySlot[i].itemQuantitiy = inventoryList[i].itemQuantity;
                     
                 }
             }
             else
             {
                break;
             }
         }
     }
 }

}
