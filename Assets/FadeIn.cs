using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float fadeInDelay = 2f;
    public Image blackout;
    IEnumerator Start()
    {
        blackout = GetComponent<Image>();
        float timer = fadeInDelay;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            if (blackout != null)
            {
                Color colorTemp = blackout.color;
                colorTemp.a = timer / fadeInDelay;
                blackout.color = colorTemp;
            }
            yield return null;
        }
    }

    public void StartAnew()
    {
        StartCoroutine(Start());
    }
}
