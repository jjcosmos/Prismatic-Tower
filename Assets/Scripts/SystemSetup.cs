using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public static SystemSetup StaticInstance;
    public Cinemachine.CinemachineFreeLook playerCamera;
    public Transform playerCameraTransforms;
    public static float inputSensitivityX = 300f;
    public static float inputSensitivityY = 2f;
    public static float sensMult = 1;
    public AutoPooler defaultHitPool;
    private void Awake()
    {
        if(StaticInstance == null)
        {
            StaticInstance = this;
            DontDestroyOnLoad(this.gameObject);
            playerCameraTransforms = Camera.main.transform;
            inputSensitivityX = 300 * sensMult;
            inputSensitivityY = 2 * sensMult;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        playerCamera.m_XAxis.m_MaxSpeed = inputSensitivityX;
        playerCamera.m_YAxis.m_MaxSpeed = inputSensitivityY;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
}
