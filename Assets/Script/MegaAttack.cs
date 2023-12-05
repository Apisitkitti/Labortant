using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAttack : MonoBehaviour
{
    public Attack attackScript; // Reference to the Attack script
    public KeyCode megaAttackKey = KeyCode.E; // Define the key for mega attack
    public int Buffdam = 2;
    public bool isMegaAttackActive = false;
    bool isCooldown = false;
    public Player player; // Reference to the Player script
    public float cooldownDuration = 10f; // Cooldown duration in seconds
    public bool HasHealedDuringMegaAttack  = false;
    private int Originaldam;
    void Start()
    {
        attackScript = GetComponentInChildren<Attack>();
        if (attackScript == null)
        {
            Debug.LogError("Attack script not found in children!");
        }
        Debug.Log("Damage Before = " + attackScript.damage);
        Originaldam = attackScript.damage;
    }

    void Update()
    {
        if (Input.GetKeyDown(megaAttackKey) && !isCooldown)
        {
            ToggleMegaAttack();
        }
    }

    void ToggleMegaAttack()
    {
        isMegaAttackActive = !isMegaAttackActive;

        if (isMegaAttackActive)
        {
            attackScript.damage *= Buffdam;
            Debug.Log("Mega Attack Activated! Damage multiplied.");
            Debug.Log("Damage now = " + attackScript.damage);
            StartCoroutine(StartCooldown());
             // Reset the flag for healing during the mega attack
           HasHealedDuringMegaAttack = false;
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        ResetDamageAttack();
        isCooldown = false;
        isMegaAttackActive = false;
       Debug.Log("Cooldown Success =  " + attackScript.damage);
    }

    public void ResetDamageAttack()
    {
        attackScript.damage = Originaldam;
        Debug.Log("Mega Attack Deactivated! Damage returned to normal.");
        Debug.Log("Damage reset = " + attackScript.damage);
        
       
    }
  
 
}
