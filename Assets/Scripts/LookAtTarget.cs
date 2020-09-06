using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    private void Start()
    {
        target = PersistantPlayer.StaticInstance.transform;
    }
    void Update()
    {
        transform.LookAt(target);
    }
}
