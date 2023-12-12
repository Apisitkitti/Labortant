using UnityEngine;
using System.Collections.Generic;

public class BossBehavior: MonoBehaviour
{
    public ReleaseMonsters releaseMonstersScript;
    // public ReleasePoisonPool releasePoisonPoolScript;
    public ReleasePoisonFromPipes releasePoisonFromPipesScript;

    public float releaseMonstersTimer; // Time interval for ReleaseMonsters
    public float releasePoisonFromPipesTimer; // Time interval for ReleasePoisonFromPipes

    public float ResetTimeMon; // Time interval for ReleaseMonsters
    // public float ResetTimePoisonPool = 15.0f; // Time interval for ReleasePoisonPool
    public float ResetTimePoison ; // Time interval for ReleasePoisonFromPipes

    private void Start()
    {
        releaseMonstersTimer = ResetTimeMon;
        // releasePoisonPoolTimer = ResetTimePoisonPool;
        releasePoisonFromPipesTimer = ResetTimePoison;
    }

    private void Update()
    {
        // Update timers
        releaseMonstersTimer -= Time.deltaTime;
        releasePoisonFromPipesTimer -= Time.deltaTime;

        // Check if it's time to release monsters
        if (releaseMonstersTimer <= 0)
        {
            releaseMonstersScript.Release();
            releaseMonstersTimer = ResetTimeMon; // Reset the timer for ReleaseMonsters
        }

        // Check if it's time to release poison from pipes
        if (releasePoisonFromPipesTimer <= 0)
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
                releasePoisonFromPipesScript.Release(zoneIndex);
                releasePoisonFromPipesTimer = ResetTimePoison; // Reset the timer for ReleasePoisonFromPipes
            }
        }

    }
}
