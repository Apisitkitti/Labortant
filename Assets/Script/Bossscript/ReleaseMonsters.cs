using UnityEngine;

public class ReleaseMonsters : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] releasePoints; // Array of positions to release monsters

    public void Release()
    {
        foreach (Transform point in releasePoints)
        {
            // Instantiate and release a single monster from each releasePoint
            Vector3 spawnPosition = point.position; // Get the spawn position
            Instantiate(monsterPrefab, spawnPosition, point.rotation);
            // Add code for releasing a single monster
        }
    }
}
