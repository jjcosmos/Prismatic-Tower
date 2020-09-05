using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{

    [SerializeField] List<Attackdef> attacks;
    public ELensType currentAbility = ELensType.None;
    [SerializeField] LensFXController lensFXController;
    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

        }
        if (Input.GetButtonDown("CycleAblity"))
        {
            CycleAbility();
            Debug.Log("Cycle ability");
        }
    }

    //This is gross, I know
    private void CycleAbility()
    {
        int loopSafety = 0;
        int index = (int)currentAbility;
        while(loopSafety < 4) 
        {
            index = (int)Mathf.Repeat(index + 1f, 4);
            if (attacks[index].isUnlocked) 
            {
                currentAbility = (ELensType)index;
                lensFXController.ActivateLens(currentAbility);
                return; 
            }
            loopSafety++;
        }
        
    }

}
[System.Serializable]
public class Attackdef
{
    [SerializeField] public ELensType lensType;
    [SerializeField] public float attackCooldown;
    [SerializeField] public float currentCooldown;
    [SerializeField] public bool isUnlocked;
    public bool isUp { get => currentCooldown <= 0;}
}