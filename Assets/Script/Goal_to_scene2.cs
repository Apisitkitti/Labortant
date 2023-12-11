using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_to_scene2 : MonoBehaviour
{
  [SerializeField] GameObject Player;
  [SerializeField] PlayerStat HP;
  // [SerializeField] GameObject Win;
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.tag == "Player")
    {
      Destroy(Player);
      SceneManager.LoadScene("2");
    }
   }
}
