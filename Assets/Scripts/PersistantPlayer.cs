using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantPlayer : MonoBehaviour
{
    public static PersistantPlayer StaticInstance;
    private void Awake()
    {
        if (StaticInstance == null)
        {
            StaticInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
