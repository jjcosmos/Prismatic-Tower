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
    public float currentCooldownTime;
    public float currentCDTimer;
    private Coroutine firingCoroutine;
    protected Vector3 sampledPoint;
    protected GameObject sampledGameobject;
    bool inRange;
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
        if(currentCDTimer <= 0 && inRange)
        {
            if (chargeupFX.gameObject.activeSelf) { chargeupFX.gameObject.SetActive(true); }
            else { Debug.Log("chargeup is active?"); }
            if (firingCoroutine != null) {
                //Debug.Log("Cooldown is shorter than firing animation");
            }
            firingCoroutine = StartCoroutine(FireCoroutine());


            currentCooldownTime = Random.Range(minCooldownTime, maxCooldownTime) + chargeupTime;
            currentCDTimer = currentCooldownTime;
        }
    }

    public IEnumerator FireCoroutine()
    {
        float lazyStop = .1f;
        //Debug.Log("FIRING");

        chargeupFX.Play(true);
        yield return new WaitForSeconds(chargeupTime-lazyStop);
        chargeupFX.Stop(true);
        GetSamplePoint();
        yield return new WaitForSeconds(lazyStop);
        
        DoFiringBehaviour();
    }

    private void GetSamplePoint()
    {
        Ray myRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(myRay, out RaycastHit hit, 1000f))
        {
            sampledPoint = hit.point;
            sampledGameobject = hit.collider.gameObject;
        }
        else
        {
            sampledPoint = Vector3.zero;
            sampledGameobject = null;
        }
        
    }
    public virtual void DoFiringBehaviour()
    {

    }

    private void FixedUpdate()
    {
        inRange = attackRange > (Vector3.Distance(transform.position, PersistantPlayer.StaticInstance.transform.position));
    }
}
