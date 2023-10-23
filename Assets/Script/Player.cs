using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  
  public int Health = 100;
  public HealthBar healthBar;
  public GameObject button;
  public int currentHealth;

  public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
  public float invincibilityDuration = 5f;
  [SerializeField] TMP_Text Hp_text;
  [SerializeField] GameObject Lose;
  [SerializeField] BloodSkill mega_attack;

  private bool isInvincible = false;

  
  void Start()
  {
    currentHealth = Health;
    healthBar.SetMaxHealth(Health);    
  }

  void Update()
  {
    Hp();
    if(Input.GetKeyDown(KeyCode.Q)&& Health>=30)
    {
      ActivateInvincibility(invincibilityDuration);
    }
     if(Input.GetKeyDown(KeyCode.E)&& Health>=50)
    {
      mega_attack.AttackUpGrade();
    }
    
  }
  public void ActivateInvincibility(float duration)
{
    if (!isInvincible)
    {
        isInvincible = true;
        StartCoroutine(InvincibilityCoroutine(duration));
    }
}

private IEnumerator InvincibilityCoroutine(float duration)
{
    // Add visual/audio effects for invincibility if desired
    spriteRenderer.color = Color.green; // Set player color to indicate invincibility

    yield return new WaitForSeconds(duration);

    // Reset invincibility state
    isInvincible = false;
    spriteRenderer.color = Color.white; // Reset player color
}

  public void TakeDam(int damage)
{
    if (!isInvincible)
    {
        Health -= damage;
        currentHealth -= damage;
        StartCoroutine(Damage());
        healthBar.SetHealth(currentHealth);
    }
}

  private IEnumerator Damage()
  {
    spriteRenderer.color = Color.red;
    yield return new WaitForSeconds(Color_Transition);
    spriteRenderer.color = Color.white;
  }
  void Hp()
  {
    Hp_text.text = "HP:  "+ Health;
    if(Health <= 0)
    {
      Destroy(gameObject);
      Lose.SetActive(true);
      Hp_text.text = "HP:  "+ 0;
    }
    if(Health <= 30)
    {
      button.SetActive(false);
    }
  }
  public void invincibility()
  {
    ActivateInvincibility(invincibilityDuration);
  }
}
