using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILightningAttack : AttackBehaviour
{
    [SerializeField] AttackLightning lightningPrefab;
    [SerializeField] AttackBasic linePrefab;
    public override void DoFiringBehaviour()
    {
        base.DoFiringBehaviour();
        AttackBasic attack = Instantiate(linePrefab);
        attack.transform.position = transform.position;
        attack.SetUpLine(transform, sampledPoint);
        //AttackLightning lightning = Instantiate(lightningPrefab, Vector3.Scale( sampledPoint, new Vector3(1,0,1)), Quaternion.Euler(Random.insideUnitSphere));
        StartCoroutine(SmallDelay());
    }
    private IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(.3f);
        AttackLightning lightning = Instantiate(lightningPrefab, Vector3.Scale(sampledPoint, new Vector3(1, 0, 1)), Quaternion.identity);
    }
}
