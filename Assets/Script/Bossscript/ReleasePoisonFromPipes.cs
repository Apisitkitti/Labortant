using UnityEngine;
using System.Collections;

public class ReleasePoisonFromPipes : MonoBehaviour
{
    public GameObject poisonPrefab;
    public Transform[] releaseZones; // Assign the zones in the inspector
    public int numberOfPoisons = 1; // Number of poisons to release at each zone
    public float spawnInterval = 0.5f; // Time between each spawn

    public void Release(int zoneIndex)
    {
        // Start a coroutine to spawn multiple poisons with a delay
        StartCoroutine(SpawnPoisons(zoneIndex));
    }

    IEnumerator SpawnPoisons(int zoneIndex)
    {
        for (int i = 0; i < numberOfPoisons; i++)
        {
            Instantiate(poisonPrefab, releaseZones[zoneIndex].position, releaseZones[zoneIndex].rotation);
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }
}
