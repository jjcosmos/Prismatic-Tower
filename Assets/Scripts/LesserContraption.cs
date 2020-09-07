using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserContraption : EnemyAI
{
    [SerializeField] Rotator propellorRotator;
    [SerializeField] Rigidbody myRigidbody;
    [SerializeField] float followRange = 20f;
    [SerializeField] float decisionTime;
    [SerializeField] float minForcePerStep;
    [SerializeField] float maxForcePerStep;
    [SerializeField] float idleBobScaler;
    [SerializeField] float wanderOscillationFreq;
    [SerializeField] float randomTorqueRange;
    
    public float timeSinceLastDecision = 0;
    public EAIState myState;
    private Transform flankTargetSingleton;
    private Transform currentFlankTarget;
    void Start()
    {
        flankTargetSingleton = FlankTargetSingleton.StaticInstance.transform;
        currentFlankTarget = flankTargetSingleton.GetChild(Random.Range(0, 4));
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Roll(5))
        {
            myRigidbody.AddTorque(0, Random.Range(-randomTorqueRange, randomTorqueRange), 0);
        }
        timeSinceLastDecision += .1f;
        if(timeSinceLastDecision >= decisionTime)
        {
            timeSinceLastDecision = 0;
            if (Vector3.Distance(transform.position, flankTargetSingleton.position) < followRange)
            {
                if (myState ==EAIState.Following || Roll(70))
                {
                    myState = EAIState.Following;
                }
                else if (Roll(70))
                {
                    myState = EAIState.Wandering;
                }
                else
                    myState = EAIState.Idle;
            }
            else if (Roll(70))
            {
                myState = EAIState.Wandering;
            }
            else
            {
                myState = EAIState.Idle;
            }

            
            
        }
        DoState();
    }
    private void DoState()
    {
        float sinOfTime = Mathf.Sin(Time.time);
        float sinOfTimeLong = Mathf.Sin(Time.time * wanderOscillationFreq);
        switch (myState)
        {
            
            case EAIState.Following:
                myRigidbody.AddForce((currentFlankTarget.position - transform.position).normalized * Random.Range(minForcePerStep, maxForcePerStep));
                break;
            case EAIState.Idle:
                myRigidbody.AddForce(idleBobScaler * sinOfTime * Vector3.up);
                break;
            case EAIState.Wandering:
                myRigidbody.AddForce(( sinOfTime* transform.forward) + (sinOfTime * transform.right));
                break;
        }
    }

    public override void KillSelf()
    {
        
        if (!dead)
        {
            propellorRotator.enabled = false;
            myRigidbody.constraints = RigidbodyConstraints.None;
            //Debug.Log("doin' velocity");
            //myRigidbody.angularVelocity = 20f * Random.insideUnitSphere;
            myRigidbody.AddTorque(2000f * Random.insideUnitSphere, ForceMode.Impulse);
            myRigidbody.AddForceAtPosition(200f * Random.insideUnitSphere + Vector3.up * 500, transform.position + Random.insideUnitSphere);
        }
        base.KillSelf();
    }

}


public enum EAIState { Following, Idle, Wandering}