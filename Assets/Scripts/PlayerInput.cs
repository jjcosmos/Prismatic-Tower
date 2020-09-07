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
    public bool canJump = true;
    private LayerMask mask;
    public static bool canMove = true;
    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip jumpSfx;
    void Start()
    {
        mask = LayerMask.NameToLayer("Default");
        playerCameraTransform = SystemSetup.StaticInstance.playerCameraTransforms;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) { return; }
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float jumpMult = 0;
        if (Input.GetButtonDown("Jump") && canJump) { jumpMult = 1; canJump = false; aSource.PlayOneShot(jumpSfx); }

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

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Trying to reset jump");
        if (Physics.Raycast(transform.position, Vector3.down, 5f, ~mask))
        {
            canJump = true;
        }
    }
    public static Vector3 RemoveYAxis(Vector3 vecToSquash, bool normalize)
    {
        Vector3 squashedVec = new Vector3(vecToSquash.x, 0, vecToSquash.z);
        if (normalize) { return squashedVec.normalized; }
        return squashedVec;
    }

    
}
