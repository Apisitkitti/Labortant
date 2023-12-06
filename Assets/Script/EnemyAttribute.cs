using UnityEngine;
using System.Collections;
public class EnemyAttribute : MonoBehaviour
{
  public int Health = 50;
  public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
  public float KnockbackForce = 5f;

  void Update()
  {
    Hp();
  }

  public void TakeDam(int damage, Vector2 knockbackDirection)
  {
    Health -= damage;
    StartCoroutine(Damage());
    ApplyKnockback(knockbackDirection);
  }

  void Hp()
  {
    if (Health <= 0)
    {
      Destroy(gameObject);
    }
  }

 private IEnumerator Damage()
{
    spriteRenderer.color = Color.red;
    yield return new WaitForSeconds(Color_Transition-0.5f);
    spriteRenderer.color = Color.white; // Set the final color to red
    
} 


  private void ApplyKnockback(Vector2 knockbackDirection)
  {
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    if (rb != null)
    {
      rb.velocity = Vector2.zero; // Stop the current velocity
      rb.AddForce(knockbackDirection * KnockbackForce*Time.deltaTime, ForceMode2D.Impulse);
    }
  }

}
