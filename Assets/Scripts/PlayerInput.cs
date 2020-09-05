using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float moveSpeedMult = 10;
    [SerializeField] float jumpHeightMult = 10;
    [SerializeField] [Range(0f,1f)] float lookSpeed = .2f;
    public Transform playerCameraTransform;
    void Start()
    {
        playerCameraTransform = SystemSetup.StaticInstance.playerCameraTransforms;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float jumpMult = 0;
        if (Input.GetButtonDown("Jump")) { jumpMult = 1; }

        Vector3 forwardVec = RemoveYAxis(playerCameraTransform.forward, true) * vInput * moveSpeedMult * Time.deltaTime;
        Vector3 rightVec = RemoveYAxis(playerCameraTransform.right, true) * hInput * moveSpeedMult * Time.deltaTime;
        Vector3 moveVec = forwardVec + rightVec + new Vector3(0,jumpMult * jumpHeightMult,0);
        if (vInput > 0)
        {
            Quaternion moveRot = Quaternion.LookRotation(moveVec, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, moveRot, lookSpeed);
        }
        playerRb.AddForce(moveVec);
    }

    private Vector3 RemoveYAxis(Vector3 vecToSquash, bool normalize)
    {
        Vector3 squashedVec = new Vector3(vecToSquash.x, 0, vecToSquash.z);
        if (normalize) { return squashedVec.normalized; }
        return squashedVec;
    }
}
