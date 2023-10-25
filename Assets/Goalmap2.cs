using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalmap2 : MonoBehaviour
{
  [SerializeField] GameObject Player;
  [SerializeField] GameObject Win;
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.tag == "Player")
    {
      Destroy(Player);
      Win.SetActive(true);
   }

  }
}
