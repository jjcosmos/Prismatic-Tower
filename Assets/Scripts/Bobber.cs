using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public float phase;
    float offset = 0;
    private void Update()
    {
        offset = Mathf.Sin(Time.time + phase) * 2;
        transform.localPosition = new Vector3(transform.localPosition.x, offset, transform.localPosition.z);
    }
}
