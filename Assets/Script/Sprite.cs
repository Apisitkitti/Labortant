using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public int damage = 10;
    public Player player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDam(damage);
            }
        }
    }
}
