using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class LoadScene : MonoBehaviour
{
  public void LoadSceneBack()
  {
    SceneManager.LoadScene("StartGame");
  }
}
