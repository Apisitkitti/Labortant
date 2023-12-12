using UnityEngine;

public class ReleaseMonsters : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] releasePoints; // Array of positions to release monsters

    public void Release(int zoneIndex)
    {
        Vector3 spawnPosition = releasePoints[zoneIndex].position; // Get the spawn position for the chosen zone
        Instantiate(monsterPrefab, spawnPosition, releasePoints[zoneIndex].rotation);
        // Add code for releasing a single monster in the chosen zone
    }
}
