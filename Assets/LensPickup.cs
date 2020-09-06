using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensPickup : MonoBehaviour
{
    [SerializeField] int indexToEnable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PersistantPlayer.StaticInstance.playerAttackInput.attacks[indexToEnable].isUnlocked = true;
            this.gameObject.SetActive(false);
        }
    }
}
