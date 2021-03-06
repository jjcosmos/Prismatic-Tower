﻿using System;
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
    public bool isEnd = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            if (isEnd) { PersistantCanvas.staticCanvas.blackout.blackout.color = Color.white; }
            else { PersistantCanvas.staticCanvas.blackout.blackout.color = Color.black; }
            StartCoroutine(FadeOut(sceneToLoad));
            PlayerInput.canMove = false;
            PersistantPlayer.StaticInstance.playerRB.velocity=Vector3.zero;
            triggered = true;
            PersistantPlayer.StaticInstance.flagForHealthReset = true;
        }
    }

    public void GlobalLoadScene(int scene)
    {
        if (triggered) { return; }
        StartCoroutine(FadeOut(scene - 1));
        PersistantPlayer.StaticInstance.flagForHealthReset = true;
        triggered = true;
    }
    private IEnumerator FadeOut(int scene)
    {
        blackout = PersistantCanvas.staticCanvas.blackout.blackout;
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
        
        SceneManager.LoadScene(scene + 1);
    }
}
