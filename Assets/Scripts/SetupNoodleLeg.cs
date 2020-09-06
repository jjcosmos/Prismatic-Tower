using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupNoodleLeg : MonoBehaviour
{
    [SerializeField] public Transform noodleFollower;
    private void Start()
    {
        SetupNoodle();
    }

    public void SetupNoodle()
    {
        noodleFollower.position = transform.position;
        noodleFollower.gameObject.SetActive(true);
    }
}
