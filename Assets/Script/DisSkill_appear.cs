using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisSkill_appear : MonoBehaviour
{
  public GameObject Invincible;
  public GameObject Tetsuga;
  public GameObject berserk;
  [SerializeField] private Player player;
  void Update()
  {
    SetSkill();
    makeskill();
  }

  void SetSkill()
  {
     if(player.Health < 30)
    {
      Invincible.SetActive(false);
    }
    if(player.Health < 50)
    {
      berserk.SetActive(false);
    }
    if(player.Health < 80)
    {
      Tetsuga.SetActive(false);
    }
  }
  void makeskill()
  {
    if(player.Health >= 30)
    {
      Invincible.SetActive(true);
    }
    if(player.Health >= 50)
    {
      berserk.SetActive(true);
    }
    if(player.Health >= 80)
    {
      Tetsuga.SetActive(true);
    }
  }
}
