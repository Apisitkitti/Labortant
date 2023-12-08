using System.Collections.Generic;
using UnityEngine;

public class WaveBehavior : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 0;
    private Vector3 moveDirection;

    void Start()
    {
     Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
     Vector3 localScale = transform.localScale;
     if(playerTransform.localScale.x <0)
     {
       moveDirection = Vector3.left;
       localScale.x *= -1f;
        transform.localScale = localScale;
     }  
     else
     {
      moveDirection = Vector3.right;
      localScale.x *= 1f;
       transform.localScale = localScale;
     }
  
    }

    void Update()
    {
        // Move the wave in the specified direction
        transform.Translate(moveDirection * Mathf.Abs(speed) * Time.deltaTime);
         Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy") || col.gameObject.tag == "Platform"|| col.gameObject.tag == "Ground")
        {
            Collider2D enemyCollider = col.gameObject.GetComponent<Collider2D>();

            if (enemyCollider != null)
            {
                Vector2 knockbackDirection = (enemyCollider.transform.position - transform.position).normalized;
                EnemyAttribute enemyAttribute = enemyCollider.GetComponent<EnemyAttribute>();

                if (enemyAttribute != null)
                {
                    enemyAttribute.TakeDam(damage, knockbackDirection);
                }
            }

            // Destroy the wave object
            Destroy(gameObject);
        }
    }
}
