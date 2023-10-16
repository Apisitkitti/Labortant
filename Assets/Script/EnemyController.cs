using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
     public float knockbackDuration = 0.5f;
     public float knockbackForce = 100f;
    public float moveSpeed = 3.0f;
    public float chaseRange = 5.0f;
    private Vector3 initialPosition;
    private bool playerInRange = false;
    private float returnDelay = 3.0f; 
    private float returnTimer = 0.0f;
     private bool isKnockedBack = false;


    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (target == null)
        {
            return; // Target (player) has been destroyed, do nothing
        }

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= chaseRange)
        {
            playerInRange = true;
            returnTimer = 0.0f; 

            if (!isKnockedBack) // Only move towards the player if not knocked back
            {
                if (target.position.x > transform.position.x)
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (target.position.x < transform.position.x)
                {
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        else if (playerInRange)
        {
            returnTimer += Time.deltaTime;

            if (returnTimer >= returnDelay)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

   public void ApplyKnockback(Vector2 knockbackDirection)
{
    isKnockedBack = true;
    StartCoroutine(ResetKnockback());
    
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    rb.velocity = Vector2.zero; // Stop the current velocity
    rb.AddForce(-knockbackDirection * knockbackForce*Time.deltaTime, ForceMode2D.Impulse);
}


    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(knockbackDuration);
        isKnockedBack = false;
    }
}
