using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotationDirection;

    private void Update()
    {
        transform.Rotate(rotationDirection * Time.deltaTime);
    }

}
