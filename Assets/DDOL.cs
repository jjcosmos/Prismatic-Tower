using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public static DDOL staticDDOL;
    private SpringJoint joint;
    private void Awake()
    {
        if (staticDDOL == null)
        {
            staticDDOL = this;
            DontDestroyOnLoad(this);
            joint = GetComponent<SpringJoint>();

        }
        else
            Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
    // called first
    

    

}
