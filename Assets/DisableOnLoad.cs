using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnLoad : CustomListener
{
    
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    
}
