using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public int totalHealth = 0; // Total combined health of all CoreBossHp GameObjects

    void Start()
    {
        // Find all GameObjects with CoreBossHp script and sum up their maxHealth
        CoreBossHp[] bossHealthScripts = FindObjectsOfType<CoreBossHp>();
        foreach (CoreBossHp bossHealthScript in bossHealthScripts)
        {
            totalHealth += bossHealthScript.maxHealth;
        }
    }

    // Function to reduce total health when any CoreBossHp GameObject takes damage
    public void ReduceTotalHealth(int damage)
    {
        totalHealth -= damage;

        // You might want to add additional logic here, like checking for game over

        if (totalHealth <= 0)
        {
            // Handle game over or any other relevant logic
            Debug.Log("You Win ka Yedmae");
        }
    }
}
