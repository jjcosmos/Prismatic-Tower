using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankTargetSingleton : MonoBehaviour
{

    public static FlankTargetSingleton StaticInstance;
    private void Awake()
    {
        if (StaticInstance == null)
        {
            StaticInstance = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this.gameObject);
    }
}
