using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensFXObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem idleParticles;
    [SerializeField] ELensType lensType;

    private void Awake()
    {
        idleParticles.Play();
    }


}

public enum ELensType {None, Flame, Frost, Lightning };
