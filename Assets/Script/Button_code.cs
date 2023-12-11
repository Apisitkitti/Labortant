using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_code : MonoBehaviour
{

  public void SetExit()
  {
    Application.Quit();
  }
  public void ChangeScene()
  {
    SceneManager.LoadScene("Tutoral");
  }
}
