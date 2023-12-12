using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_to_scene2 : MonoBehaviour
{
  [SerializeField] Checkpawn spawn;
  [SerializeField] private Checkpawn spawn2;  
  // [SerializeField] GameObject Win;
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.tag == "Player")
    {
      spawn2.SpawnPoint = spawn.SpawnPoint;
      spawn2.Scene = spawn.Scene;
      SceneManager.LoadScene(spawn.Scene);
    }
   }
}
