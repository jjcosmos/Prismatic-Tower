﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireball : MonoBehaviour
{
    public GameObject owner;
    public GameObject owner2;
    public bool destroyOnHit = false;
    public List<GameObject> owners;
    [SerializeField] List<ParticleSystem> explosionFx;
    [SerializeField] ParticleSystem idleParticles;
    [SerializeField] float AOERadius = 5f;
    [SerializeField] int damagePerShot = 1;
    LayerMask mask;
    public Rigidbody myRigidbody;
    public MeshRenderer myMeshRend;
    bool triggered = false;
    [SerializeField] AudioClip impactSound;
    [SerializeField] AudioSource soundSource;
    private void Awake()
    {

        mask = LayerMask.GetMask("Damageable");
        myRigidbody = GetComponent<Rigidbody>();
        myMeshRend = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("NoHit") && other.gameObject != owner && !triggered && other.gameObject != owner2 && !owners.Contains(other.gameObject))
        {
            PersistantPlayer.StaticInstance.source.GenerateImpulse(.7f);
            foreach (ParticleSystem p in explosionFx)
            {
                p.Play();
            }
            soundSource.PlayOneShot(impactSound,1);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, AOERadius, mask);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.TryGetComponent(out Hittable hittable)) 
                {
                    hittable.DealDamage(damagePerShot);
                }
            }
            myRigidbody.isKinematic = true;
            myMeshRend.enabled = false;
            triggered = true;
            StartCoroutine(DisableTimer());
        }
    }

    private IEnumerator DisableTimer()
    {
        float timer = 0;
        while(timer<1.3f)
        {
            timer += Time.deltaTime;
            soundSource.volume = 1.3f - timer;
            yield return null;
        }
        this.gameObject.SetActive(false);
        if(destroyOnHit)
        { Destroy(this.gameObject); }
    }

    private void OnEnable()
    {
        soundSource.Play();
        soundSource.volume = .5f;
        triggered = false;
        myRigidbody.isKinematic = false;
        myMeshRend.enabled = true;
        idleParticles.Play();
    }
}
