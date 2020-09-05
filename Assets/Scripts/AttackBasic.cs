using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBasic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LineRenderer line;
    Transform myFirePosition;
    Vector3 myEndPoint;
    float fadeout = 1;
    public int damage = 1;
    private void Awake()
    {
        fadeout = 1;
    }
    public void SetUpLine(Transform firePosition, Vector3 endPosition)
    {
        myFirePosition = firePosition;
        myEndPoint = endPosition;
    }
    // Update is called once per frame
    void Update()
    {

        line.SetPosition(0, myFirePosition.position);
        line.SetPosition(1, myEndPoint);
        Color temp = line.sharedMaterial.color;
        temp.a = fadeout;
        line.sharedMaterial.color = temp;
        fadeout -= Time.deltaTime * 4;
        if(fadeout <= 0)
        { Destroy(this.gameObject); }
    }
}
