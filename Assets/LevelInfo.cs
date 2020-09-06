using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] bool isBossLevel = false;
    private void Awake()
    {
        AttackBehaviour.cannotAttackOverride = isBossLevel;
    }
}
