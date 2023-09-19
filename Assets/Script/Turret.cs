using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;

    void Update()
    {
        // Check if it's time to shoot
        if (Time.time >= nextFireTime)
        {
            // Call the Shoot function and update the nextFireTime
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
    
    void Shoot()
    {
        // Instantiate a bullet at the fire point
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
