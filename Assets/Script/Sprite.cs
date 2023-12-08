using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public int damage = 10;
    public float cooldownTime = 2f; // Adjust this value as needed
    private float nextDamageTime;
    private Player player;

    void OnTriggerStay2D(Collider2D col)
{
    if (col.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
    {
        Debug.Log("Applying damage!");
        player = col.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDam(damage);
            nextDamageTime = Time.time + cooldownTime;

            // Optionally, reset the cooldown time to zero after applying damage
            // nextDamageTime = 0f;
        }
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        Debug.Log("Player exited the trigger zone. Resetting cooldown.");
        nextDamageTime = 0f; // Reset the cooldown when the player exits the trigger zone
    }
}

}


