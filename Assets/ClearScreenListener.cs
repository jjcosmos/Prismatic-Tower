using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreenListener : CustomListener
{
    public override void Notify()
    {
        base.Notify();
        PersistantCanvas.staticCanvas.RemoveBossText();
    }
}
