using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRaycaster : MonoBehaviour
{

    public Vector3 currentLookPosition;
    public Targetable currentTargetable;
    [SerializeField] string[] ignoredLayers;
    private LayerMask mask;
    private Transform mainCamera;
    private void Start()
    {
        mainCamera = SystemSetup.StaticInstance.playerCameraTransforms;
        if (true) 
        {
            mask = LayerMask.GetMask(ignoredLayers);
            mask = ~mask;
        }

    }
    void Update()
    {
        Ray myRay = new Ray(mainCamera.position, mainCamera.forward);
        //ray info dist mask
        if(Physics.Raycast(myRay, out RaycastHit hit, 1000f, mask))
        {
            
            if(hit.transform.TryGetComponent(out Targetable targetable)) { currentTargetable = targetable; }
            currentLookPosition = hit.point;
            //Debug.Log($"Looking at {currentLookPosition} " + hit.collider.name);
        }
        else
        {
            currentLookPosition = Vector3.zero;
            currentTargetable = null;
        }
    }
}
