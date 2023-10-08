using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.0f;
    private float nextFireTime = 0.0f;

    void Update()
    {
        // Check if it's time to fire again
        if (Time.time >= nextFireTime)
        {
            // Fire a bullet
            Shoot();
            // Set the next fire time
            nextFireTime = Time.time + 1.0f / fireRate;
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Add force to the bullet (adjust the force as needed)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 10.0f, ForceMode2D.Impulse);
    }
}
