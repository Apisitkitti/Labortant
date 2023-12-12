using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public int totalHealth = 0;
    public HealthBar healthBar; // Reference to the HealthBar script

    void Start()
    {
        CoreBossHp[] bossHealthScripts = FindObjectsOfType<CoreBossHp>();
        foreach (CoreBossHp bossHealthScript in bossHealthScripts)
        {
            totalHealth += bossHealthScript.maxHealth;
        }

        // Update the max health on the health bar
        healthBar.SetMaxHealth(totalHealth);
    }

    public void ReduceTotalHealth(int damage)
    {
        totalHealth -= damage;
        healthBar.SetHealth(totalHealth); // Update the health bar
        if (totalHealth <= 0)
        {
            Debug.Log("You Win ka Yedmae");
            // Handle game over or any other relevant logic
        }
    }
}
