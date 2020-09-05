using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSpawner : MonoBehaviour
{
    [SerializeField] AutoPooler bulletPool;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = bulletPool.RequestDequeue();
            if(go == null) { return; }
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.SetActive(true);
        }
    }
}
