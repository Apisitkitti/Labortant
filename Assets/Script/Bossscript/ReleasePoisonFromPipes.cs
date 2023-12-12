using UnityEngine;

public class ReleasePoisonFromPipes : MonoBehaviour
{
    public GameObject poisonPrefab;
    public Transform[] releaseZones; // Assign the zones in the inspector

   /* void Start()
    {
        ReleaseFromAllZones();
    }

    void ReleaseFromAllZones()
    {
        // Loop through each release zone and release poison
        for (int i = 0; i < releaseZones.Length; i++)
        {
            Release(i);
        }
    }*/

    public void Release(int zoneIndex)
    {
        // Instantiate and release poison at the designated zone
        Instantiate(poisonPrefab, releaseZones[zoneIndex].position, releaseZones[zoneIndex].rotation);
        
        // Add code for releasing poison in specific zone
    }
}
