using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadChunk : MonoBehaviour
{
    [SerializeField] GameObject toDisable;
    [SerializeField] GameObject toEnable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Check start");
            if (toDisable != null) { toDisable.SetActive(false); }
            if (toEnable != null) { toEnable?.SetActive(true); }
            Debug.Log("Check end");
        }
    }
}
