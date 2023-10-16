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

    void FixedUpdate()
    {
      if(currentAttack <= mincurrenttime )
      {
         if (Input.GetMouseButtonDown(0))
        {
            AttackMode();
            currentAttack = attackTime; 
        }
       
      }
      else
      {
         currentAttack -= Time.fixedDeltaTime;
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
