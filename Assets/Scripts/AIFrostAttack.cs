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
        
        AttackBasic attack = Instantiate(linePrefab);
        attack.transform.position = transform.position;
        attack.SetUpLine(transform, sampledPoint);

        StartCoroutine(SmallDelay());
    }
    private IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(.3f);
        AttackIce iceball = Instantiate(icePrefab, sampledPoint, Quaternion.Euler(Random.insideUnitSphere));
        iceball.generatedByBoss = isBoss;
    }


}
