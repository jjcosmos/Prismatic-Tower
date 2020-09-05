using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PersistantPlayer : MonoBehaviour
{
    public static PersistantPlayer StaticInstance;
    public Rigidbody playerRB;
    public CinemachineImpulseSource source;

    private void Start()
    {
        if (StaticInstance == null)
        {
            StaticInstance = this;
            DontDestroyOnLoad(this.gameObject);
            playerRB = GetComponent<Rigidbody>();
            source = GetComponent<CinemachineImpulseSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
