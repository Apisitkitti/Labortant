using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    void OnTriggerEnter2D(Collider2D col)
    {
     if (col.gameObject.tag == "Player")
        {
            // Find the Player script on the collided object (the player)
            Player playerScript = col.gameObject.GetComponent<Player>();

            // Check if the Player script is found
            if (playerScript != null)
            {
                // Apply damage to the player
                playerScript.TakeDam(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
      if(col.gameObject.tag == "Platform"|| col.gameObject.tag == "Ground")
      {
        Destroy(gameObject);
      }
      
    }
}
