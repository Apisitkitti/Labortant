using System.Collections.Generic;
using UnityEngine;

public class WaveBehavior : MonoBehaviour
{
    [SerializeField] List<Collider2D> enemy;
    public float speed = 5f;
    public int damage = 0;
    private Vector3 moveDirection;

    void Start()
    {
        // Set the initial movement direction based on the speed
        moveDirection = (speed > 0) ? Vector3.right : Vector3.left;
    }

    void Update()
    {
        // Move the wave in the specified direction
        transform.Translate(moveDirection * Mathf.Abs(speed) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Ground"))
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
