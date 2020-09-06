using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistantCanvas : MonoBehaviour
{
    public static PersistantCanvas staticCanvas;
    public LoadZone globalLoadZone;
    public FadeIn blackout;
    private void Awake()
    {
        if (staticCanvas == null)
        {
            staticCanvas = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
            Destroy(this.gameObject);
    }
}
