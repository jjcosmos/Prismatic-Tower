using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody myRB;
    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        myRB.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
