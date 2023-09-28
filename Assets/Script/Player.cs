using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  
  public int Health = 100;
  public HealthBar healthBar;
  public int currentHealth;

  public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
  [SerializeField] TMP_Text Hp_text;
  [SerializeField] GameObject Lose;

  void Start()
  {
    currentHealth = Health;
    healthBar.SetMaxHealth(Health);    
  }

  void Update()
  {
    Hp();
    
  }
  public void TakeDam(int damage)
  {
    Health-= damage;
    currentHealth-=damage;
    StartCoroutine(Damage());
    healthBar.SetHeatlh(currentHealth);
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

  }
}
