using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBossHp : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private SpriteRenderer CoreRenderer;
    public Color damageColor = Color.red;
    public float Color_Transition = 1f;
    private HealthBoss healthBoss; // Reference to the HealthBoss

    void Start()
    {
        currentHealth = maxHealth;
        CoreRenderer = GetComponent<SpriteRenderer>();
        healthBoss = FindObjectOfType<HealthBoss>(); // Find the HealthBoss in the scene
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashDamageColor());
        if (currentHealth <= 0)
        {
            Die();
        }

        // Call ReduceTotalHealth in HealthBoss to update total health
        healthBoss.ReduceTotalHealth(damage);
    }

    IEnumerator FlashDamageColor()
    {
        CoreRenderer.color = damageColor;
        yield return new WaitForSeconds(Color_Transition - 0.5f);
        CoreRenderer.color = Color.white;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
