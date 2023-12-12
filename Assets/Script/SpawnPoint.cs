using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    public Checkpawn check_save;
    public PlayerStat hp;
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
      if(collider2D.gameObject.CompareTag("Player"))
      {   
        Debug.Log("spawn");
        check_save.SpawnPoint = transform.position;
        check_save.Scene = SceneManager.GetActiveScene().buildIndex;
        hp.CheckHealth = hp.Health;

      }
    }
    
}
