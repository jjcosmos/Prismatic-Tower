using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CooldownVisualizer : MonoBehaviour
{
    [SerializeField] List<Image> abilityArray;
    WaitForSecondsRealtime increment;
    IEnumerator Start()
    {
        increment = new WaitForSecondsRealtime(.1f);
        yield return null;
        AttackInput playerAttackInput = PersistantPlayer.StaticInstance.playerAttackInput;
        while (true)
        {
            int i = 0;
            foreach (Attackdef attack in playerAttackInput.attacks)
            {
                Color tempColor = abilityArray[i].color;
                tempColor.a = attack.currentCooldown / attack.attackCooldown;
                tempColor.a *= Convert.ToInt32(attack.isUnlocked);
                //Debug.Log($"{attack.lensType} alpha is {tempColor.a}");
                abilityArray[i].color = tempColor;
                i++;
            }
            yield return increment;
        }
    }

    
}
