using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] List<GameObject> toDeactivateOnDeath;
    protected bool dead = false;
    public bool Roll(float percentChance)
    {
        if(Random.Range(0, 100) < percentChance) { return true; }
        return false;
    }

    public virtual void KillSelf()
    {
        //Debug.Log("doin' velocity pt1");
        if (toDeactivateOnDeath.Count < 1 || dead) { return; }
        foreach (GameObject go in toDeactivateOnDeath)
        {
            go.SetActive(false);
        }
        dead = true;
    }
}
