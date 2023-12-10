using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarrel : MonoBehaviour
{
    public int Healamount = 20;
    public int BarrelHP = 40;
    private int currentHp;
    public Player player; // Make sure to assign the player object in the Inspector
    public SpriteRenderer spriteRenderer;
  public float Color_Transition = 1f;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = BarrelHP;
    }

    // Update is called once per frame
    public void TakeDamage(int Damageamount)
    {
        currentHp -= Damageamount;
        Debug.Log("Hp Barrel = " + currentHp);
        StartCoroutine(Damage());
        if (currentHp <= 0)
        {
            DestroyHPBarrel();
        }
    }

    void DestroyHPBarrel()
    {
        if (player != null) // Check if player reference is not null
        {
            player.HealPlayer(Healamount);
        }
        Destroy(gameObject);
    }
    private IEnumerator Damage()
{
    spriteRenderer.color = Color.red;
    yield return new WaitForSeconds(Color_Transition-0.5f);
       spriteRenderer.color = Color.white; 
    
} 
}
