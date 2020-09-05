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
        if (Input.GetButton("Fire1"))
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
        foreach (Attackdef attack in attacks)
        {
            attack.PassTime(Time.deltaTime);
        }
    }

    private void Attack()
    {
        if (currentAbility == ELensType.None)
        {
            AttackBasic attack = Instantiate(attacks[(int)currentAbility].prefabToSpawn).GetComponent<AttackBasic>();
            attack.SetUpLine(firingPoint, aimRaycaster.currentLookPosition);
            if(aimRaycaster.currentTargetable != null) { aimRaycaster.currentTargetable.DealDamage(attack.damage); }
        }
        else if (currentAbility == ELensType.Flame)
        {
            GameObject fireball = fireballPooler.RequestDequeue();
            fireball.transform.position = firingPoint.position;
            fireball.SetActive(true);
            fireball.GetComponent<AttackFireball>().owner = this.gameObject;
            fireball.GetComponent<Rigidbody>().velocity = 
                (aimRaycaster.currentLookPosition - firingPoint.position).normalized * attacks[(int)currentAbility].projectileSpeed;
            PersistantPlayer.StaticInstance.playerRB.AddForce((transform.position- aimRaycaster.currentLookPosition).normalized * 300f);
            PersistantPlayer.StaticInstance.source.GenerateImpulse(.3f);
        }
        else if (currentAbility == ELensType.Frost)
        {
            Instantiate(attacks[(int)currentAbility].prefabToSpawn, aimRaycaster.currentLookPosition, Quaternion.identity);
        }
        else if (currentAbility == ELensType.Lightning)
        {
            Instantiate(attacks[(int)currentAbility].prefabToSpawn, Vector3.Scale(aimRaycaster.currentLookPosition, new Vector3(1,0,1)), Quaternion.identity);
        }
        attacks[(int)currentAbility].currentCooldown = 0;
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
    public bool isUp { get => currentCooldown >= attackCooldown;}

    public void PassTime(float deltaTime)
    {
        currentCooldown += deltaTime;
        if (currentCooldown > attackCooldown) { currentCooldown = attackCooldown; }
    }
}