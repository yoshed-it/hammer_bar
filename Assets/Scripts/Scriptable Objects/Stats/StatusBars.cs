using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBars : MonoBehaviour
{
    public IntoxPoints intoxPoints;

    [HideInInspector]
    public Player character;

    public Image statusMask;

    public TextMeshProUGUI intoxText;

    float maxIntoxPoints;

    void Start()
    {
        // maxIntoxPoints = character.maxIntoxPoints;

    }

    void Update()
    {
        if (character != null)
        {
            statusMask.fillAmount = intoxPoints.value / character.maxIntoxPoints;
            intoxText.text = "" + (statusMask.fillAmount * 100);
        }
    }


}   