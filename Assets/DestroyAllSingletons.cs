using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllSingletons : MonoBehaviour
{
    private void Awake()
    {
        if(PersistantCanvas.staticCanvas != null) {
            Destroy(PersistantCanvas.staticCanvas.gameObject); 
            PersistantCanvas.staticCanvas = null;
        }
        if (PersistantPlayer.StaticInstance != null)
        {
            Destroy(PersistantPlayer.StaticInstance.gameObject);
            PersistantPlayer.StaticInstance = null; 
        }
        if (DDOL.staticDDOL != null)
        {
            Destroy(DDOL.staticDDOL.gameObject);
            DDOL.staticDDOL = null;
        }
        if (SystemSetup.StaticInstance != null)
        {
            Destroy(SystemSetup.StaticInstance.gameObject);
            SystemSetup.StaticInstance = null;
        }

    }
}
