using UnityEngine;
using System.Collections.Generic;

public class BossBehavior : MonoBehaviour
{
    public ReleaseMonsters releaseMonstersScript;
   // public ReleasePoisonPool releasePoisonPoolScript;
    public ReleasePoisonFromPipes releasePoisonFromPipesScript;

    public float releaseInterval = 3.0f; // Time interval between skill releases
    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= releaseInterval)
        {
            // Reset timer
            timer = 0.0f;

            // Randomly choose which skill to release
            int skillToRelease = Random.Range(1, 3);

            switch (skillToRelease)
            {
                case 1:
                    releaseMonstersScript.Release();
                    break;
                /*case 2:
                    releasePoisonPoolScript.Release();
                    break;*/
                case 2:
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
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
