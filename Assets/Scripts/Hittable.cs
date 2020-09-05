using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : Targetable
{
    [SerializeField] Healthpool linkedPool;
    public int critMod = 1; // set separately for cit spots

    public void DealDamage(int damage)
    {
        linkedPool.ModifyHealth((damage * critMod) * -1);
    }
}
