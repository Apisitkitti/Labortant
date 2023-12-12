using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
  [SerializeField] private PlayerStat HP;
  [SerializeField] private GameObject player;
  private int health_tuto = 20;
  [SerializeField] Checkpawn SpawnPoint;
   public void Restart()
{
    if (HP != null)
    {
        HP.Health = HP.CheckHealth;
    }
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    player.transform.position = SpawnPoint.SpawnPoint;
}

public void Restart_tutorial()
{
    if (HP != null)
    {
        HP.Health = health_tuto;
    }
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}
