﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healthpool : MonoBehaviour
{
    public EOnDeathBehaviour deathBehaviour;
    [SerializeField] int maxHealth = 10;
    public int currentHealth;
    [SerializeField] GameObject FXObject;
    [SerializeField] public EnemyUI linkedDisplay;
    Vector3 minuteOffset;
    private bool canDie = true;
    public bool notifyListener;
    public List<CustomListener> listeners;

    private void Start()
    {

        minuteOffset = new Vector3(0, .01f, 0);
        currentHealth = maxHealth;
        linkedDisplay?.UpdateHealth(currentHealth, maxHealth);
    }
    public void ModifyHealth(int mod)
    {
        currentHealth += mod;
        //Debug.Log($"modding {name}'s health by {mod}. Current health is {currentHealth}");
        if(currentHealth <= 0 && canDie)
        {
            Die();
            canDie = false;
        }
        linkedDisplay?.UpdateHealth(currentHealth, maxHealth);
    }

    private void Die()
    {
        if(deathBehaviour == EOnDeathBehaviour.SpawnFXAndDestroy)
        {
            Debug.Log($"{gameObject.name} Died");
            if (FXObject != null) { Instantiate(FXObject, transform.position + minuteOffset, Quaternion.identity); }
            Destroy(this.gameObject);
        }
        else if(deathBehaviour == EOnDeathBehaviour.Player)
        {
            Debug.Log("Player Died");
            PersistantCanvas.staticCanvas.globalLoadZone.GlobalLoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(deathBehaviour == EOnDeathBehaviour.DeactivateAIAndToggleGrav)
        {
            if(TryGetComponent(out EnemyAI enemyAI)) {
                enemyAI.KillSelf();
                enemyAI.enabled = false; 
            }
            if(TryGetComponent(out Rigidbody rb)) { rb.useGravity = true; }
        }
        else if(deathBehaviour == EOnDeathBehaviour.SpawnFX)
        {
            if(FXObject != null) { Instantiate(FXObject, transform.position + minuteOffset, Quaternion.identity); }
        }
        else if (deathBehaviour == EOnDeathBehaviour.ToggleAIAndSpawnFX)
        {
            if (FXObject != null) { Instantiate(FXObject, transform.position + minuteOffset, Quaternion.identity); }
            if (TryGetComponent(out EnemyAI enemyAI))
            {
                enemyAI.KillSelf();
                enemyAI.enabled = false;
            }
        }
        if(notifyListener)
        {
            foreach (CustomListener c in listeners)
            {
                c.Notify();
            }
        }
    }

    public void ResetHealthPool()
    {
        currentHealth = maxHealth;
        linkedDisplay?.UpdateHealth(currentHealth, maxHealth);
        linkedDisplay?.OverrideScale(Vector3.one);
        canDie = true;
    }

}

public enum EOnDeathBehaviour {SpawnFXAndDestroy, Player, DeactivateAIAndToggleGrav, SpawnFX, ToggleAIAndSpawnFX}
