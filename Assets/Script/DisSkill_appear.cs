using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisSkill_appear : MonoBehaviour
{
  public GameObject Invincible;
  public GameObject Tetsuga;
  public GameObject berserk;
  [SerializeField] private PlayerStat HP;
  void Update()
  {
    SetSkill();
    makeskill();
  }

  void SetSkill()
  {
     if(HP.Health < 30)
    {
      Invincible.SetActive(false);
    }
    if(HP.Health < 50)
    {
      Tetsuga.SetActive(false);
    }
  }
  void makeskill()
  {
    if(HP.Health >= 30)
    {
      Invincible.SetActive(true);
    }
    if(HP.Health >= 50)
    {
      Tetsuga.SetActive(true);
    }
  }
}
