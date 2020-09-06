using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChildListener : CustomListener
{
    public override void Notify()
    {
        foreach (Transform child in transform)
        {
            GameObject go = SystemSetup.StaticInstance.defaultHitPool.RequestDequeue();
            go.transform.position = child.position;
            go.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }


}
