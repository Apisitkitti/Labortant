using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalmap2 : MonoBehaviour
{
  [SerializeField] GameObject Player;
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.tag == "Player")
    {
      Destroy(Player);
      SceneManager.LoadScene("BossStage");
   }

  }
}
