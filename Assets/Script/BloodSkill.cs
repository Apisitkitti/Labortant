using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class BloodSkill : MonoBehaviour
  {
    [SerializeField]Attack atk;
    [SerializeField]Player player;
    public int Hp_regain =0;
    public int skill_dam = 0;
      public void AttackUpGrade()
      {
        atk.damage = skill_dam;
        player.Health += Hp_regain;
      }
    //   void Update()
    // {
    //     if (player.Health <= 0 && player.GetComponent<Player>() != null)
    //     {
    //         player.EndMegaAttack();
    //         Destroy(gameObject);
    //     }
    // }
  }
