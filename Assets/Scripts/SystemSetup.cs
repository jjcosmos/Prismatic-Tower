using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public static SystemSetup StaticInstance;
    public Cinemachine.CinemachineFreeLook playerCamera;
    public Transform playerCameraTransforms;
    public float inputSensitivityX = 300f;
    public float inputSensitivityY = 2f;
    public AutoPooler defaultHitPool;
    private void Awake()
    {
        if(StaticInstance == null)
        {
            StaticInstance = this;
            DontDestroyOnLoad(this.gameObject);
            playerCameraTransforms = Camera.main.transform;
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
