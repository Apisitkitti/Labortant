using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    public int Health = 50;
    public SpriteRenderer spriteRenderer;
    public float Color_Transition = 1f;
    void Update()
    {
      Hp();
    }
     public void TakeDam(int damage)
    {
        Health -= damage;
        // currentHealth -= damage;
        StartCoroutine(Damage());
        // healthBar.SetHealth(currentHealth);
    }
    void Hp()
  {
    if(Health <= 0)
    {
      Destroy(gameObject);
    }

  }

  private IEnumerator Damage()
  {
    spriteRenderer.color = Color.blue;
    yield return new WaitForSeconds(Color_Transition);
    spriteRenderer.color = Color.red;
  }
    
}
