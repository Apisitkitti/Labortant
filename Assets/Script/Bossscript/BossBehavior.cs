using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BossBehavior : MonoBehaviour
{
    public ReleaseMonsters releaseMonstersScript;
    public ReleasePoisonFromPipes releasePoisonFromPipesScript;

    public float releaseMonstersTimer;
    public GameObject warningObject;
    public int warningTime;
    public int end_skil;
    [SerializeField] Animator anim;
    
    private bool isMonstersActivated = false;
    private bool isPoisonActivated = false;
    private bool isFloodSkillActivated = false;
    private bool isPullDownStaticActivated = false;
    public float elapsedTime = 0f;
    private bool floodSkillEnded = false;
    public float ReleasePosion;
    public float ReleasePool;
    public float BackReleaseMon;
    public float ResetTimeMon;
    private void Start()
    {
        releaseMonstersTimer = ResetTimeMon;
    }

    private void Update()
    {
        if (isMonstersActivated == false)
        {
            releaseMonstersTimer -= Time.deltaTime;
            if (releaseMonstersTimer <= 0)
            {
                ActivateReleaseMon();
                isMonstersActivated = true;
                elapsedTime = 0f;
            }
        }
        else if (!isPoisonActivated)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= ReleasePosion)
            {
                ActivateReleasePoison();
                isPoisonActivated = true;
                elapsedTime = 0f;
            }
        }
        else if (!isFloodSkillActivated)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= ReleasePosion)
            {
                StartCoroutine(ActivateFloodSkill());
                isFloodSkillActivated = true;
                elapsedTime = 0f;
            }
        }
        else if (floodSkillEnded)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= BackReleaseMon)
            {
                isMonstersActivated = false;
                isPoisonActivated = false;
                isFloodSkillActivated = false;
                isPullDownStaticActivated = false;
                floodSkillEnded = false;
                elapsedTime = 0f;
            }
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
        floodSkillEnded = true;
    }
}
