using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_code : MonoBehaviour
{
  [SerializeField] private Checkpawn spawn;
  [SerializeField] private Checkpawn spawn2;
  [SerializeField] private PlayerStat HP;
  public void SetExit()
  {
    Application.Quit();
  }
  public void ChangeScene()
  {
    spawn2.SpawnPoint = spawn.SpawnPoint;
    spawn2.Scene = spawn.Scene;
    HP.Health = 20;
    Time.timeScale = 1;

    SceneManager.LoadScene(spawn.Scene);
  }
}
