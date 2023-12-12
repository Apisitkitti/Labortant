using UnityEngine;


public class HealthBoss : MonoBehaviour
{
    public int totalHealth = 0;
    [SerializeField] GameObject win;
    public HealthBar healthBar; // Reference to the HealthBar script

    void Start()
    {
      win.SetActive(false);
        CoreBossHp[] bossHealthScripts = FindObjectsOfType<CoreBossHp>();
        foreach (CoreBossHp bossHealthScript in bossHealthScripts)
        {
            totalHealth += bossHealthScript.maxHealth;
        }

        // Update the max health on the health bar
        healthBar.SetMaxHealth(totalHealth);
    }
    void Update()
    {
      if (totalHealth <= 0)
        {
           Time.timeScale = 0;
            win.SetActive(true);
        }
    }

    public void ReduceTotalHealth(int damage)
    {
        totalHealth -= damage;
        healthBar.SetHealth(totalHealth); // Update the health bar
    }
}
