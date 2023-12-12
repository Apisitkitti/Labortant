using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BossBehavior : MonoBehaviour
{
    public ReleaseMonsters releaseMonstersScript;
    public ReleasePoisonFromPipes releasePoisonFromPipesScript;

    public float releaseMonstersTimer;
    public float releasePoisonFromPipesTimer;
    public float releasePoisonPoolTimer;
    public float ResetTimeMon;
    public float ResetTimePoisonPool = 15.0f;
    public float ResetTimePoison;
    public GameObject warningObject;
    public int warningTime;
    public int end_skil;
    [SerializeField] Animator anim;

    private void Start()
    {
        releaseMonstersTimer = ResetTimeMon;
     //   releasePoisonPoolTimer = ResetTimePoisonPool;
        releasePoisonFromPipesTimer = ResetTimePoison;
    }

    private void Update()
    {
        releaseMonstersTimer -= Time.deltaTime;
        releasePoisonFromPipesTimer -= Time.deltaTime;
        releasePoisonPoolTimer -= Time.deltaTime;

        if (releaseMonstersTimer <= 0)
        {
            ActivateReleaseMon();
        }

        if (releasePoisonFromPipesTimer <= 0)
        {
            ActivateReleasePoison();
        }

        if (releasePoisonPoolTimer <= 0)
        {
            StartCoroutine(ActivateFloodSkill());
            releasePoisonPoolTimer = ResetTimePoisonPool;
        }
    }

    void ActivateReleaseMon()
    {
        int randomZoneCount = Random.Range(1, 3);
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
            releaseMonstersTimer = ResetTimeMon;
        }
    }

    void ActivateReleasePoison()
    {
        int randomZoneCount = Random.Range(1, 3);
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
            releasePoisonFromPipesScript.Release(zoneIndex);
            releasePoisonFromPipesTimer = ResetTimePoison;
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
