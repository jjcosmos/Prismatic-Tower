using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleLookAt : MonoBehaviour
{
    public Transform currentTarget;
    [SerializeField] Transform effectorToMove;
    [SerializeField] Transform anchorPoint;
    [SerializeField] float squishScale = 5;
    private void Start()
    {
        currentTarget = PersistantPlayer.StaticInstance.transform;
    }
    private void Update()
    {
        Vector3 directionTotarget = currentTarget.position - transform.position;
        effectorToMove.position = anchorPoint.position + directionTotarget.normalized * squishScale;
    }
}
