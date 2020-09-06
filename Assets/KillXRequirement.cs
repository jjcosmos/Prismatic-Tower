using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillXRequirement : CustomListener
{
    [SerializeField] int enemiesToKill;
    public int currentEnemyKillCount;
    [SerializeField] CustomListener linkedListener;
    private void Awake()
    {
        currentEnemyKillCount = 0;
    }

    public override void Notify()
    {
        base.Notify();
        currentEnemyKillCount ++;
        if (currentEnemyKillCount == enemiesToKill)
        {
            linkedListener.Notify();
        }
    }
}
