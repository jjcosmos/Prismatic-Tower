using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIFrostAttack : AttackBehaviour
{
    [SerializeField] AttackIce icePrefab;
    [SerializeField] AttackBasic linePrefab;
    [SerializeField] bool isBoss = false;
    public override void DoFiringBehaviour()
    {
        base.DoFiringBehaviour();
        AttackIce iceball = Instantiate(icePrefab, sampledPoint, Quaternion.Euler(Random.insideUnitSphere));
        iceball.generatedByBoss = isBoss;
        AttackBasic attack = Instantiate(linePrefab);
        attack.transform.position = transform.position;
        attack.SetUpLine(transform, sampledPoint);
    }
    
    
}
