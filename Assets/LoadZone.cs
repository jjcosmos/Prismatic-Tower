using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadZone : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 0;
    [SerializeField] float fadeOutDelay = 3f;
    [SerializeField] Image blackout;
    public bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            StartCoroutine(FadeOut(sceneToLoad));
            triggered = true;
        }
    }

    public void GlobalLoadScene(int scene)
    {
        if (triggered) { return; }
        StartCoroutine(FadeOut(scene));
        triggered = true;
    }
    private IEnumerator FadeOut(int scene)
    {
        float timer = fadeOutDelay;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            if (blackout != null)
            {
                Color colorTemp = blackout.color;
                colorTemp.a = 1f -(timer / fadeOutDelay);
                blackout.color = colorTemp;
            }
            yield return null;
        }
        SceneManager.LoadScene(scene);
    }
}
