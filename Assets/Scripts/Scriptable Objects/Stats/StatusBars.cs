using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBars : MonoBehaviour
{

    [HideInInspector]
    public Player character;
    public Endurance endurancePoints;
    public Intox intoxPoints;
    public Stress stressPoints;
    public Item money;
    public Image intoxStatusMask, enduranceStatusMask, stressStatusMask;
    public TextMeshProUGUI intoxText, enduranceText, stressText, moneyCounterText;


    public void Start()
    {

    }

    void Update()
    {

        //Yosh -- Gotta figure out a way where each status mask doesnt have a unique name.
        if (character != null)
        {
            intoxStatusMask.fillAmount = intoxPoints.value / character.maxIntoxPoints;
            intoxText.text = "" + (intoxStatusMask.fillAmount * 100);

            enduranceStatusMask.fillAmount = endurancePoints.value / character.maxEndurancePoints;
            enduranceText.text = "" + (enduranceStatusMask.fillAmount * 100);

            
            stressStatusMask.fillAmount = stressPoints.value / character.maxStressPoints;
            stressText.text = "" + (stressStatusMask.fillAmount * 100).ToString("F0");

            // Debug.Log("More Questions! " + intoxStatusMask.fillAmount);
            // Debug.Log("EVENMore Questions! " + enduranceStatusMask.fillAmount);

        }
    }
    public bool MoneyIncrementer(Item moneyToAdd)
    {
        if (money != null
        && money.itemType == moneyToAdd.itemType
        && moneyToAdd.hasMonetaryValue == true)
        {
            var updatedMoney = moneyToAdd.monetaryValue;
            moneyCounterText.text = "$" + updatedMoney.ToString();

            return true;
        }
        return false;
    }

    
    
}


