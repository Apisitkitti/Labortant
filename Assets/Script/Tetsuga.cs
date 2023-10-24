using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetsuga : MonoBehaviour
{
    [SerializeField] private GameObject WavePrefab;
    [SerializeField] private Transform attackpo;
    public void PerformWaveAttack()
    {
        // Instantiate the wave prefab
        GameObject wave = Instantiate(WavePrefab, attackpo.position, Quaternion.identity);

       
    }
}
