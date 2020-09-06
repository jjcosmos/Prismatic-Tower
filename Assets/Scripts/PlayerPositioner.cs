using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositioner : MonoBehaviour
{
    private void Awake()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Start");
        transform.position = target.transform.position + new Vector3(0,1.2f,0);
        transform.rotation = target.transform.rotation;
    }

    public void PositionPlayer()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Start");
        transform.position = target.transform.position + new Vector3(0, 1.2f, 0);
        transform.rotation = target.transform.rotation;
    }
}
