using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInPlayerHealth : MonoBehaviour
{
    [SerializeField] EnemyUI uiToLink;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Healthpool>().linkedDisplay = uiToLink;
        uiToLink.isUnique = true;
        uiToLink.OverrideScale(Vector3.one);
    }
}
