using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  public HealthBar healthBar;
  public int MaxHealth = 100;
  [SerializeField]PlayerStat HP;
  public int currentHealth;
  public Animator anim;
  public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
  public float invincibilityDuration = 5f;
  [SerializeField] GameObject Lose;
  [SerializeField] Invincible immortal;

 

  
  void Start()
  {
    currentHealth = HP.Health;
    HP.CheckHealth = currentHealth;
    healthBar.SetHealth(HP.Health);
  }

  void Update()
    {
        Hp();
    }
  
  public void TakeDam(int damage)
{
    if (!immortal.isInvincible)
    {
        HP.Health -= damage;
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
    if(HP.Health <= 0)
    {
      Destroy(gameObject);
      Lose.SetActive(true);
    }
  }
 public void HealPlayer(int healAmount){
  currentHealth +=healAmount;
  if(currentHealth > 100)
  {
    currentHealth = 100;
  }
  HP.Health = currentHealth;
  healthBar.SetHealth(currentHealth);
 }

}
