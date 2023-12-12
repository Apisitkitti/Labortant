using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float mincurrenttime = 0f;
    [SerializeField] public float currentAttack = 0f;
    
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
                if (megaAttackScript != null && megaAttackScript.isMegaAttackActive && !megaAttackScript.hasHealedDuringMegaAttack)
                    {
                        megaAttackScript.player.HealPlayer(20);
                        megaAttackScript.hasHealedDuringMegaAttack = true;
                        // Reset the damage in MegaAttack script
                        megaAttackScript.ResetDamageAttack();
                    }
            }  
                        // Check for barrels
                Collider2D[] hitBarrels = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
                foreach (Collider2D barrel in hitBarrels)
                {
                    if (barrel.CompareTag("HPBarrel")) // Assuming barrel has the tag "Barrel"
                    {
                        DamageBarrel(barrel);
                    }
                }
                Collider2D[] hitCore = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
                foreach (Collider2D Core in hitCore)
                {
                    if (Core.CompareTag("CoreBoss")) // Assuming barrel has the tag "Barrel"
                    {
                        DamageCore(Core);
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
    void DamageBarrel(Collider2D barrel)
{
    // Check if the collider belongs to a barrel and apply damage to it
    HPBarrel hpBarrel = barrel.GetComponent<HPBarrel>();
    if (hpBarrel != null)
    {
        hpBarrel.TakeDamage(damage);
    }
}
 void DamageCore(Collider2D core)
{
    // Check if the collider belongs to a boss core and apply damage to it
    CoreBossHp coreBossHp = core.GetComponent<CoreBossHp>();
    if (coreBossHp != null)
    {
        coreBossHp.TakeDamage(damage);
    }
}
}
