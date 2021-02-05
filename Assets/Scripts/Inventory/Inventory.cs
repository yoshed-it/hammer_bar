using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject slotPrefab;
    public const int numSlots = 5;
    Image[] itemImages = new Image[numSlots];
    Item[] items = new Item[numSlots];
    GameObject[] slots = new GameObject[numSlots];

    [SerializeField] private Sprite blank16x16sprite = null;
    [SerializeField] private InventorySlotUI[] inventorySlot = null;

    public void Start()
    {
        CreateSlots();
    }
    private void Update()
    {

    }


    public void CreateSlots()
    {
        if (slotPrefab != null)
        {
            for (int i = 0; i < numSlots; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot_" + i;
                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);

                slots[i] = newSlot;
                itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();

                //Creates the Number that corrisponds to the keyboard.
                //Should Probably  make this a scriptable object or something to get refrence to the keys.
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                TMP_Text hotBarNumber = slotScript.slotNumberText;

                hotBarNumber.text = slotScript.slotNumberText.text + (i + 1);
                hotBarNumber.name = "HotBar_" + (i + 1);
            }
        }
    }

    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null
            && items[i].itemType == itemToAdd.itemType
            && itemToAdd.stackable == true)
            {
                //Adding to existing slot.

                items[i].quantity = items[i].quantity + 1;

                //Grab refrence to "Slot" script
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();

                TMP_Text quantityText = slotScript.qtyText;
                quantityText.gameObject.SetActive(true);


                quantityText.text = items[i].quantity.ToString();

                return true;
            }
            if (items[i] == null)
            {
                itemImages[i].gameObject.SetActive(true);
                items[i] = Instantiate(itemToAdd);
                items[i].quantity = 1;
                itemImages[i].sprite = itemToAdd.sprite;

                return true;
            }
        }
        return false;
    }

    // public void AddItem(List<InventoryItem> inventoryList)
    // {
    //     for (int i = 0; i < inventorySlot.Length; i++)
    //     {
    //         if (i < inventoryList.Count)
    //         {
    //             int itemID = inventoryList[i].itemID;

    //             ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemID);
    //             Slot slotScript = inventorySlot[i].gameObject.GetComponent<Slot>();


    //             if (itemDetails != null)
    //             {
    //                 inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
    //                 Debug.Log( inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite);
    //                 inventorySlot[i].textMeshProUGUI.text = inventoryList[i].itemQuantity.ToString();
    //                 inventorySlot[i].itemDetails = itemDetails;
    //                 inventorySlot[i].itemQuantitiy = inventoryList[i].itemQuantity;

    //             }
    //         }
    //         else
    //         {
    //             break;
    //         }

    //     }
    }













