using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public TMP_Text heartDisplay;

    public void UpdateHealth(int healthleft, int healthMax)
    {
        //Debug.Log($"recieved {healthleft} and {healthMax}");
        transform.localScale = Vector3.one;
        string display = "";
        for (int i = 0; i < healthMax; i++)
        {
            if(i >= healthleft)
            {
                display += "<color=#8F8E85>\u2665</color>";
            }   //
            else
                display += "<color=#FA2B20>\u2665</color>";
        }
        heartDisplay.text = display;
    }
}
