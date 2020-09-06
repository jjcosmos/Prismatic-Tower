using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorListener : CustomListener
{
    // Start is called before the first frame update
    private Vector3 open;
    public bool isOpen;
    bool isStatic = true;
    void Start()
    {
        open = new Vector3(0, 0, -4.3f);
    }

    public override void Notify()
    {
        base.Notify();
        isOpen = !isOpen;
        isStatic = false;
    }
    void Update()
    {
        if (isStatic) { return; }
        if (isOpen)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, open, Time.deltaTime * 2);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, Time.deltaTime * 2);
        }
    }
}
