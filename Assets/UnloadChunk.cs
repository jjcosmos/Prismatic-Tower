using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadChunk : MonoBehaviour
{
    [SerializeField] GameObject toDisable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            toDisable.SetActive(false);
        }
    }
}
