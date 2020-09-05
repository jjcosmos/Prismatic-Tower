using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupNoodleLeg : MonoBehaviour
{
    [SerializeField] Transform noodleFollower;
    private void Awake()
    {
        noodleFollower.position = transform.position;
    }
}
