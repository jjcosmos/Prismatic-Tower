using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;


public class PersistantPlayer : MonoBehaviour
{
    public static PersistantPlayer StaticInstance;
    public Rigidbody playerRB;
    public CinemachineImpulseSource source;
    public Transform legRigTarget;
    public SetupNoodleLeg noodleSetup;
    public PlayerPositioner playerPositioner;
    public Healthpool healthpool;

    private void Awake()
    {
        if (StaticInstance == null)
        {
            StaticInstance = this;
            DontDestroyOnLoad(this.gameObject);
            playerRB = GetComponent<Rigidbody>();
            source = GetComponent<CinemachineImpulseSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnEnable()
    {

        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        noodleSetup.noodleFollower.gameObject.SetActive(false);
        playerPositioner.PositionPlayer();
        noodleSetup.SetupNoodle();
        PersistantCanvas.staticCanvas.blackout.StartAnew();
        PersistantCanvas.staticCanvas.globalLoadZone.triggered = false;
        healthpool.ResetHealthPool();
    }


    // called when the game is terminated
    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
