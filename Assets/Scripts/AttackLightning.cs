using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLightning : MonoBehaviour
{

    [SerializeField] Light lighting;
    [SerializeField] Transform mainScalar;
    [SerializeField] float lifeTimeTicks = 10;
    [SerializeField] Collider reference;
    [SerializeField] int damagePerTick;
    WaitForSecondsRealtime tickIncrement;
    Vector3 worldCenter;
    Vector3 worldHalfExtents;
    LayerMask mask;
    IEnumerator Start()
    {
        InitStuffs();
        tickIncrement = new WaitForSecondsRealtime(.5f);
        Vector3 scalingVec = Vector3.one;
        scalingVec.x = .01f;
        scalingVec.z = .01f;
        mainScalar.localScale = scalingVec;
        while(scalingVec.x < 1.2f)
        {
            scalingVec.x += Time.deltaTime * 10;
            scalingVec.z += Time.deltaTime * 10;
            mainScalar.localScale = scalingVec;
            yield return null;
        }
        while (scalingVec.x > 1)
        {
            scalingVec.x -= Time.deltaTime * 5;
            scalingVec.z -= Time.deltaTime * 5;
            mainScalar.localScale = scalingVec;
            yield return null;
        }
        float ticksDone = 0;
        while(ticksDone < lifeTimeTicks)
        {
            //Collider[] colliders = Physics.OverlapBox(worldCenter, worldHalfExtents, reference.transform.rotation, mask);
            Collider[] colliders = Physics.OverlapBox(reference.transform.position, reference.bounds.extents, reference.transform.rotation, mask);
            foreach (var hitCollider in colliders)
            {

                if (hitCollider.TryGetComponent(out Hittable hittable))
                {
                    hittable.DealDamage(damagePerTick);
                    //Debug.Log($"Hitting {hitCollider.name}");
                }
                else
                {
                    //Debug.Log($"Hitting (but not..) {hitCollider.name}");
                }
            }
            PersistantPlayer.StaticInstance.source.GenerateImpulse(.8f);
            ticksDone++;
            yield return tickIncrement;
        }
        while (scalingVec.x > 0)
        {
            scalingVec.x -= Time.deltaTime * 5;
            scalingVec.z -= Time.deltaTime * 5;
            mainScalar.localScale = scalingVec;
            yield return null;
        }
        Destroy(this.gameObject);
    }

    
    private void InitStuffs()
    {
        mask = LayerMask.GetMask("Damageable");
        worldCenter = reference.transform.TransformPoint(reference.bounds.center);
        worldHalfExtents = reference.transform.TransformVector(reference.bounds.size * 0.5f); 
    }


}
