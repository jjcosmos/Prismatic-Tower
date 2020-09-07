using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    //should be placed with an eye. Needs the lookat behaviour
    [SerializeField] float minCooldownTime;
    [SerializeField] float maxCooldownTime;
    [SerializeField] float chargeupTime;
    [SerializeField] ParticleSystem chargeupFX;
    [SerializeField] float attackRange = 20;
    [SerializeField] AudioSource aSource;
    
    public float currentCooldownTime;
    public float currentCDTimer;
    private Coroutine firingCoroutine;
    protected Vector3 sampledPoint;
    protected GameObject sampledGameobject;
    bool inRange;
    public static bool cannotAttackOverride = true;
    
    void Start()
    {
        chargeupFX.gameObject.SetActive(true);
        chargeupFX.Stop(true);
        currentCooldownTime = Random.Range(minCooldownTime, maxCooldownTime) + chargeupTime;
        currentCDTimer = currentCooldownTime;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentCDTimer -= Time.deltaTime;
        if(currentCDTimer <= 0 && inRange && !cannotAttackOverride)
        {
            if (chargeupFX.gameObject.activeSelf) { chargeupFX.gameObject.SetActive(true); }
            else { Debug.Log("chargeup is active?"); }
            if (firingCoroutine != null) {
                //Debug.Log("Cooldown is shorter than firing animation");
            }
            if(GetSamplePoint())
                firingCoroutine = StartCoroutine(FireCoroutine());
            


            currentCooldownTime = Random.Range(minCooldownTime, maxCooldownTime) + chargeupTime;
            currentCDTimer = currentCooldownTime;
        }
    }

    public IEnumerator FireCoroutine()
    {
        float lazyStop = .1f;
        //Debug.Log("FIRING");
        aSource?.Play();
        chargeupFX.Play(true);
        yield return new WaitForSeconds(chargeupTime-lazyStop);
        chargeupFX.Stop(true);
        float vol = 0;
        if (aSource) { vol = aSource.volume; aSource.volume = 0; }
        aSource?.Stop();
        if (aSource) { aSource.volume = vol; }
        GetSamplePoint();
        yield return new WaitForSeconds(lazyStop);
        
        DoFiringBehaviour();
    }

    private bool GetSamplePoint()
    {
        Ray myRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(myRay, out RaycastHit hit, 1000f))
        {
            sampledPoint = hit.point;
            sampledGameobject = hit.collider.gameObject;
            if (sampledGameobject.CompareTag("Player")) { return true; }
            else { Debug.Log($"Hit {sampledGameobject.name}, not player"); }
        }
        else
        {
            sampledPoint = Vector3.zero;
            sampledGameobject = null;
            return false;
        }
        return false;
    }
    public virtual void DoFiringBehaviour()
    {

    }

    private void FixedUpdate()
    {
        inRange = attackRange > (Vector3.Distance(transform.position, PersistantPlayer.StaticInstance.transform.position));
    }
}
