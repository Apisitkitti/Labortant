using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float mincurrenttime = 0f;
    [SerializeField] public float currentAttack = 0f;
    [SerializeField] Tetsuga wave;
    public int damage = 12;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackTime = 1.5f;
    public LayerMask enemyLayer;
    public Animator anim;
    public float knockbackForce = 5f;
    public MegaAttack megaAttackScript;

    void Update()
{
    if (currentAttack <= mincurrenttime)
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackMode();
            currentAttack = attackTime;
        }
    }
    if (Input.GetKeyDown(KeyCode.R))
    { 
        wave.PerformWaveAttack();
    }
    else
    {
        currentAttack -= Time.deltaTime;

        // Check if currentAttack is close enough to 0 using a tolerance value
        float tolerance = 0.001f; // Adjust the tolerance based on your specific needs
        if (currentAttack < tolerance)
        {
            currentAttack = mincurrenttime;
        }
    }
}

       

        void AttackMode()
        {
            anim.SetTrigger("attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                enemy.GetComponent<EnemyAttribute>().TakeDam(damage, knockbackDirection);
                if (megaAttackScript != null && megaAttackScript.isMegaAttackActive && !megaAttackScript.HasHealedDuringMegaAttack)
        {
            megaAttackScript.player.HealPlayer(20);
            megaAttackScript.HasHealedDuringMegaAttack = true;
            // Reset the damage in MegaAttack script
            megaAttackScript.ResetDamageAttack();
        }
            }  
        }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
