using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBars : MonoBehaviour
{
    [HideInInspector]
    public Image intoxStatusMask, enduranceStatusMask, stressStatusMask;
    public TextMeshProUGUI intoxText, enduranceText, stressText, moneyCounterText;

    public void UpdateIntoxBar(float intoxValue, float maxValue)
    {
        intoxStatusMask.fillAmount = intoxValue / maxValue;
        intoxText.text = "" + (intoxStatusMask.fillAmount * 100);
    }

    public void UpdateEnduranceBar(float enduranceValue, float maxValue)
    {
        enduranceStatusMask.fillAmount = enduranceValue / maxValue;
        enduranceText.text = "" + (enduranceStatusMask.fillAmount * 100);
    }

    public void UpdateStressBar(float stressValue, float maxValue)
    {
        stressStatusMask.fillAmount = stressValue / maxValue;
        stressText.text = "" + (stressStatusMask.fillAmount * 100).ToString("F0");

    }

    public void UpdateMoneyBar(int moneyValue)
    {
        moneyCounterText.text = moneyValue.ToString();
    }
}
