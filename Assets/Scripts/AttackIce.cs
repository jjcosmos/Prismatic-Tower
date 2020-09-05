using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIce : MonoBehaviour
{
    [SerializeField] float lifeTime = 6f;
    [SerializeField] float forceRange = 8f;
    [SerializeField] float attractionForce = 100f;
    [SerializeField] int damagePerTick = 2;
    [SerializeField] float damageIncrement = 1f;
    private WaitForSecondsRealtime increment;
    LayerMask mask;
    float canDamageTimer = 0;
    private IEnumerator Start()
    {
        
        transform.localScale = Vector3.one * .01f;
        increment = new WaitForSecondsRealtime(.01f);
        mask = LayerMask.GetMask("Damageable");
        //mask = ~mask;
        StartCoroutine(DestroyTimer());
        while(transform.localScale.x <1.2)
        {
            transform.localScale *= 1.2f;
            yield return increment;
           
        }
        PersistantPlayer.StaticInstance.source.GenerateImpulse(.5f);
        while (transform.localScale.x > 1)
        {
            transform.localScale *= .9f;
            yield return increment;
        }
    }
    private void FixedUpdate()
    {
        bool flagForReset = false;
        canDamageTimer += Time.deltaTime;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, forceRange, mask);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce((transform.position - hitCollider.transform.position) * attractionForce);
            }
            if(canDamageTimer > damageIncrement && hitCollider.TryGetComponent(out Hittable hittable))
            {
                hittable.DealDamage(damagePerTick);
                flagForReset = true;
            }

        }
        if(flagForReset)
            canDamageTimer = 0;

    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSecondsRealtime(lifeTime);
        while(transform.localScale.x > .05f)
        {
            transform.localScale *= .9f;
            yield return increment;
        }
        Destroy(this.gameObject);
    }
}
