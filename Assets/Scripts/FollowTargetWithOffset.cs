using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetWithOffset : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
