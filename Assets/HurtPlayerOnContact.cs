﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PersistantPlayer.StaticInstance.playerRB.AddForce(Vector3.up * 300);
            if(collision.collider.TryGetComponent(out Hittable playerHittable))
            {
                playerHittable.DealDamage(2);
            }
        }
    }
}
