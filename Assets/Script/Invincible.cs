using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Unity.Mathematics;
using System;
public class Invincible : MonoBehaviour
{
  [SerializeField] Player player;
  [SerializeField] private Image imageCooldown;
  [SerializeField] private TMP_Text textCooldown;
  [SerializeField] private Image frame;
  public SpriteRenderer spriteRenderer;
  public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
       textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;  
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q) && player.Health >= 30)
        {
            ActivateInvincibility(player.invincibilityDuration);
        }
    }
    private IEnumerator InvincibilityCoroutine(float duration)
{
    // Add visual/audio effects for invincibility if desired
    spriteRenderer.color = Color.green; // Set player color to indicate invincibility
    textCooldown.text = Mathf.RoundToInt(duration).ToString();
    imageCooldown.fillAmount =duration;
    yield return new WaitForSeconds(duration);
    // Reset invincibility state
    isInvincible = false;
    spriteRenderer.color = Color.white; // Reset player color
}
public void ActivateInvincibility(float duration)
{
    if (!isInvincible)
    {
        isInvincible = true;
        StartCoroutine(InvincibilityCoroutine(duration));
    }
}

}
