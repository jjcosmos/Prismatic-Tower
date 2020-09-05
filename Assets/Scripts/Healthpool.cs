using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpool : MonoBehaviour
{
    public EOnDeathBehaviour deathBehaviour;
    [SerializeField] int maxHealth = 10;
    public int currentHealth;
    [SerializeField] GameObject FXObject;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void ModifyHealth(int mod)
    {
        currentHealth += mod;
        Debug.Log($"modding {name}'s health by {mod}. Current health is {currentHealth}");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(deathBehaviour == EOnDeathBehaviour.SpawnFXAndDestroy)
        {
            Debug.Log($"{gameObject.name} Died");
            if (FXObject != null) { Instantiate(FXObject, transform.position, Quaternion.identity); }
            Destroy(this.gameObject);
        }
        else if(deathBehaviour == EOnDeathBehaviour.Player)
        {
            Debug.Log("Player Died");
        }
        else if(deathBehaviour == EOnDeathBehaviour.DeactivateAIAndToggleGrav)
        {
            if(TryGetComponent(out EnemyAI enemyAI)) { enemyAI.enabled = false; }
            if(TryGetComponent(out Rigidbody rb)) { rb.useGravity = true; }
        }
    }


}

public enum EOnDeathBehaviour {SpawnFXAndDestroy, Player, DeactivateAIAndToggleGrav}
