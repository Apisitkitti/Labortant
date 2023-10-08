using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWater : MonoBehaviour
{
  public GameObject player;
  [SerializeField] GameObject Lose;
  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag == "Player")
    {
      Destroy(player);
      Lose.SetActive(true);

    }
  }
}
