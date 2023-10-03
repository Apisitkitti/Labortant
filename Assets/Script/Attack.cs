using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 12;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public Animator anim;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackMode();
        }
    }

  void AttackMode()
  {
    anim.SetTrigger("attack");

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);

    foreach(Collider2D enemy in hitEnemies)
    { 
      enemy.GetComponent<EnemyAttribute>().TakeDam(damage);
    }
  }
   void OnDrawGizmosSelected()
   {
    if(attackPoint == null)
    {
      return;
    }
    Gizmos.DrawWireSphere(attackPoint.position,attackRange);
   }
}
