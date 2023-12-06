using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public int damage = 10;
    public float cooldownTime = 2f; // Adjust this value as needed
    private float nextDamageTime;
    public Player player;

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDam(damage);
                nextDamageTime = Time.time + cooldownTime;
            }
        }
    }
}
