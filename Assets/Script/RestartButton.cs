using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
  [SerializeField] private PlayerStat HP;
  private int health_tuto = 20;
   public void Restart()
   {
      HP.Health = HP.CheckHealth;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
   public void Restart_tutorial()
   {
    HP.Health = health_tuto;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
