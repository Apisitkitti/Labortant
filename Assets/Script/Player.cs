using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mono.Cecil;

public class Player : MonoBehaviour
{
  
  public int Health = 100;
  public HealthBar healthBar;
  public GameObject button;
  public int currentHealth;
  public Animator anim;
  public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
  public float invincibilityDuration = 5f;
  [SerializeField] TMP_Text Hp_text;
  [SerializeField] GameObject Lose;
  [SerializeField] BloodSkill mega_attack;
  [SerializeField] Invincible immortal;
  private bool immortal_stat;

 
  private bool isMegaAttackActive = false;

  
  void Start()
  {
    currentHealth = Health;
    healthBar.SetMaxHealth(Health);

  }

  void Update()
    {
        Hp();
        immortal_stat = immortal.isInvincible;
        if (Input.GetKeyDown(KeyCode.E) && Health >= 50 && !isMegaAttackActive)
        {
            ActivateMegaAttack();
        }
    }
    private void ActivateMegaAttack()
    {
        mega_attack.AttackUpGrade();
        isMegaAttackActive = true;
    }

    public void EndMegaAttack()
    {
        isMegaAttackActive = false;
    }
  


  public void TakeDam(int damage)
{
    if (!immortal.isInvincible)
    {
        Health -= damage;
        currentHealth -= damage;
        StartCoroutine(Damage());
        healthBar.SetHealth(currentHealth);
    }
}

  private IEnumerator Damage()
  {
    anim.SetBool("Hurt",true);
    spriteRenderer.color = Color.red;
    yield return new WaitForSeconds(Color_Transition);
    anim.SetBool("Hurt",false);
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
    immortal.ActivateInvincibility(invincibilityDuration);
  }
}
