using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject {
    public string objectName;
    public Sprite sprite;
    public int quantity;
    public bool stackable;
    public bool hasMonetaryValue;
    public int monetaryValue;
    public int intoxModifier;
    public int stressModifier;
    public int enduranceModifier;

    public enum ItemType
    {
        MONEY,
        INTOX,
        STRESS,
        ENDURANCE
    }

    public ItemType itemType;  
}
