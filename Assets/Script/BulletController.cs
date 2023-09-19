using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;

    void Start()
    {
        // Apply forward force to the bullet
        GetComponent<Rigidbody2D>().velocity = transform.forward * bulletSpeed;
    }
}
