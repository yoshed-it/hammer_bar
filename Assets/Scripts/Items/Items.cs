using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [ItemCodeDescription]
    [SerializeField] private int _itemID;

    private SpriteRenderer spriteRenderer;
    public int ItemID { get { return _itemID; } set { _itemID = value; } }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (ItemID != 0)
        {
            Init(ItemID);
        }
    }

    public void Init(int itemCodeParam)
    {

    }
}
