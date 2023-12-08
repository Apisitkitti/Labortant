using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.0f;
    private float nextFireTime = 0.0f;
    public float thrust = 20.0f;
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
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, (firePoint.rotation));

    // Get the Rigidbody2D component
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    // if transform rotation z = 0 || 180,-180 
    if(Mathf.Approximately(firePoint.rotation.eulerAngles.z, 0.0f)||Mathf.Approximately(firePoint.rotation.eulerAngles.x, .0f) )
    {
        //unfreeze PositionY
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        // Add force to the bullet (adjust the force as needed)
        rb.AddForce(firePoint.up * thrust, ForceMode2D.Impulse);
    }
    else
    {
        rb.AddForce(firePoint.up * thrust, ForceMode2D.Impulse);
    }

    
}
}
