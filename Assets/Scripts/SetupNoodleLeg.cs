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
        //noodleFollower.position = Vector3.Scale(new Vector3(1,0,1), transform.position);
        noodleFollower.position = transform.position;
        noodleFollower.gameObject.SetActive(true);
    }

    private void Update()
    {
        //transform.position = noodleFollower.position = Vector3.Scale(new Vector3(1, 0, 1), transform.position);
        noodleFollower.transform.position = new Vector3(noodleFollower.position.x, transform.position.y, noodleFollower.position.z);
    }
}
