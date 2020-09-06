using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : Targetable
{
    [SerializeField] Healthpool linkedPool;
    public bool hasSuperArmor = false;
    public int critMod = 1; // set separately for cit spots

    public override void DealDamage(int damage)
    {
        base.DealDamage(damage);
        if(!hasSuperArmor)
            linkedPool.ModifyHealth((damage * critMod) * -1);
        else
        {
            int reducedDamage = (int)(damage / 2f);
            if (reducedDamage < 1) { reducedDamage = 1; }
            linkedPool.ModifyHealth((reducedDamage * critMod) * -1);
        }
            
    }
}
