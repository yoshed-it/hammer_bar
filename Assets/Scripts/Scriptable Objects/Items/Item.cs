using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject {
    public string objectName;
    public Sprite sprite;
    public int quantity;
    public bool stackable;

    public enum ItemType
    {
        MONEY,
        INTOX,
        STRESS,
        ENDURANCE
    }

    public ItemType itemType;  
}
