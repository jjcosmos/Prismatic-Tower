using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerZone : MonoBehaviour
{
    [SerializeField] string bossIntroName;
    [SerializeField] string bossIntroDescription;
    [SerializeField] Collider trigger;
    [SerializeField] Collider protection;
    [SerializeField] EnemyUI bossUI;
    private void Start()
    {
        AttackBehaviour.cannotAttackOverride = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            trigger.enabled = false;
            protection.enabled = false;
            bossUI.OverrideScale(Vector3.one);
            AttackBehaviour.cannotAttackOverride = false;
            StartCoroutine(PersistantCanvas.staticCanvas.DisplayBossText(bossIntroName, bossIntroDescription));
        }
    }
}
