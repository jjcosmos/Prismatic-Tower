using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    [SerializeField] AutoPooler fireballPooler;
    [SerializeField] List<Attackdef> attacks;
    public ELensType currentAbility = ELensType.None;
    [SerializeField] LensFXController lensFXController;
    [SerializeField] AimRaycaster aimRaycaster;
    [SerializeField] Transform firingPoint;
    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (attacks[(int)currentAbility].isUp)
            {
                Attack();
            }
        }
        if (Input.GetButtonDown("CycleAblity"))
        {
            CycleAbility();
            Debug.Log("Cycle ability");
        }
    }

    private void Attack()
    {
        if (currentAbility == ELensType.None)
        {
            return;
        }
        else if (currentAbility == ELensType.Flame)
        {
            GameObject fireball = fireballPooler.RequestDequeue();
            fireball.transform.position = firingPoint.position;
            fireball.SetActive(true);
            fireball.GetComponent<AttackFireball>().owner = this.gameObject;
            fireball.GetComponent<Rigidbody>().velocity = (aimRaycaster.currentLookPosition - firingPoint.position).normalized * attacks[(int)currentAbility].projectileSpeed;
        }
        else if (currentAbility == ELensType.Frost)
        {
            return;
        }
        else if (currentAbility == ELensType.Lightning)
        {
            return;
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
    [SerializeField] public GameObject prefabToSpawn;
    [SerializeField] public float projectileSpeed;
    public bool isUp { get => currentCooldown <= 0;}
}