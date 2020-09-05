using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AesPlayerHeadTracker : MonoBehaviour
{
    [SerializeField] AimRaycaster playerAimRaycaster;
    [SerializeField] float moveMult =1;
    // Update is called once per frame
    void Update()
    {
        if(playerAimRaycaster.currentLookPosition != Vector3.zero)
            transform.position = Vector3.MoveTowards(transform.position, playerAimRaycaster.currentLookPosition, Time.deltaTime * moveMult);
        else
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.TransformPoint(new Vector3(0,1.5f, 1)), Time.deltaTime * moveMult);

    }
}
