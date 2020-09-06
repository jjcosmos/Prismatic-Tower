using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public TMP_Text heartDisplay;
    private float scale;
    private bool closed;
    public bool isUnique = false;
    private void Awake()
    {
        scale = 1;
        if(!isUnique)
            transform.localScale = Vector3.one * .001f;
    }
    public void UpdateHealth(int healthleft, int healthMax)
    {
        //Debug.Log($"recieved {healthleft} and {healthMax}");
        if(healthleft<healthMax && !closed)
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

        if(healthleft <= 0 && !closed)
        {
            Debug.Log("Animating");
            StartCoroutine(FakeAnimateClose());
            closed = true;
        }
    }
    public void OverrideScale(Vector3 newScale)
    {
        transform.localScale = newScale;
    }
    private IEnumerator FakeAnimateClose()
    {
        while (scale > 0)
        {
            transform.localScale = Vector3.one * scale;
            scale -= Time.deltaTime;
            yield return null;
        }
    }

    
}
