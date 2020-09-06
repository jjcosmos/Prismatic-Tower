using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFireballAttack : AttackBehaviour
{
    [SerializeField] AttackFireball FireballPrefab;
    [SerializeField] float fireballSpeed;
    [SerializeField] Transform colliderParent;
    [SerializeField] List<GameObject> owners;
    public override void DoFiringBehaviour()
    {
        base.DoFiringBehaviour();
        AttackFireball fireball = Instantiate(FireballPrefab, transform.position, Quaternion.identity);
        fireball.owner = colliderParent.gameObject;
        fireball.owner2 = this.gameObject;
        fireball.destroyOnHit = true;
        foreach (GameObject o in owners)
        {
            fireball.owners.Add(o);
        }
        fireball.myRigidbody.velocity = (sampledPoint - transform.position).normalized * fireballSpeed;
    }

    
}
