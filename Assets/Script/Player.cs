using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
  public int Health = 100;
  public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
  [SerializeField] GameObject Lose;

  void Update()
  {
    Hp();
  }
  public void TakeDam(int damage)
  {
    Health-= damage;
    StartCoroutine(Damage());
  }
  private IEnumerator Damage()
  {
    spriteRenderer.color = Color.red;
    yield return new WaitForSeconds(Color_Transition);
    spriteRenderer.color = Color.white;
  }
  void Hp()
  {
    if(Health <= 0)
    {
      Destroy(gameObject);
      Lose.SetActive(true);
    }
  }
}
