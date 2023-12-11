using UnityEngine;

public class ReleaseMonsters : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform releasePoint;

    void Start()
    {
        Release();
    }
    public void Release()
    {
        // Instantiate and release a single monster from releasePoint
        Vector3 spawnPosition = releasePoint.position; // Set spawn position to the releasePoint
        Instantiate(monsterPrefab, spawnPosition, releasePoint.rotation);
        // Add code for releasing a single monster
    }
}
