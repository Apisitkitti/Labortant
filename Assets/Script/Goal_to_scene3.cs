using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_to_scene3 : MonoBehaviour
{
  [SerializeField] GameObject Player;
  // [SerializeField] GameObject Win;
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.tag == "Player")
    {
      Destroy(Player);
      // Win.SetActive(true);
      SceneManager.LoadScene("3");
    }
   }
}
