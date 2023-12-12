using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class BossBehavior : MonoBehaviour
{
  public ReleaseMonsters releaseMonstersScript;
  // public ReleasePoisonPool releasePoisonPoolScript;
  public ReleasePoisonFromPipes releasePoisonFromPipesScript;
  public GameObject warningObject;
  public int warningTime;
  public int end_skil;
  public float releaseMonstersTimer; // Time interval for ReleaseMonsters
  public float releasePoisonFromPipesTimer; // Time interval for ReleasePoisonFromPipes

  public float ResetTimeMon; // Time interval for ReleaseMonsters
                             // public float ResetTimePoisonPool = 15.0f; // Time interval for ReleasePoisonPool
  public float ResetTimePoison; // Time interval for ReleasePoisonFromPipes

  [SerializeField] Animator anim;

  private void Start()
  {
    ResetBoss_Summon_Position();
  }

  private void Update()
  {
    Boss_Spawnner_skill();
  }

  public void ResetBoss_Summon_Position()
  {
    releaseMonstersTimer = ResetTimeMon;
    // releasePoisonPoolTimer = ResetTimePoisonPool;
    releasePoisonFromPipesTimer = ResetTimePoison;
  }

  public void Boss_Spawnner_skill()
  {
    // Update timers
    releaseMonstersTimer -= Time.deltaTime;
    releasePoisonFromPipesTimer -= Time.deltaTime;

    // Check if it's time to release monsters
    if (releaseMonstersTimer <= 0)
    {
      int randomZoneCount = Random.Range(1, 3); // Randomly choose 1 or 2 zones
      List<int> chosenZones = new List<int>();

      while (chosenZones.Count < randomZoneCount)
      {
        int zoneIndex = Random.Range(0, 3);
        if (!chosenZones.Contains(zoneIndex))
        {
          chosenZones.Add(zoneIndex);
        }
      }

      foreach (int zoneIndex in chosenZones)
      {
        releaseMonstersScript.Release(zoneIndex);
        releasePoisonFromPipesTimer = ResetTimePoison; // Reset the timer for ReleasePoisonFromPipes
        releaseMonstersTimer = ResetTimeMon; // Reset the timer for ReleaseMonsters
      }
    }

    // Check if it's time to activate flood skill animation
    if (releasePoisonFromPipesTimer <= 0)
    {
      StartCoroutine(ActivateFloodSkill());
    }
  }

  IEnumerator ActivateFloodSkill()
  {
    anim.SetBool("PullDown", false);
    anim.SetBool("PullDownstatic", false);
    warningObject.SetActive(true);
    yield return new WaitForSeconds(warningTime);
    
    warningObject.SetActive(false);
    anim.SetBool("PullUp", true);
    anim.SetBool("PullTopStill", true);

    yield return new WaitForSeconds(end_skil);

    anim.SetBool("PullUp", false);
    anim.SetBool("PullTopStill", false);
    anim.SetBool("PullDown", true);
     anim.SetBool("PullDownstatic", true);
  }

}
