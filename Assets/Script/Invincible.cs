using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Invincible : MonoBehaviour
{
  [SerializeField] private Player player;
  [SerializeField] private Image imageCooldown;
  [SerializeField] private Image frame;
  public SpriteRenderer spriteRenderer;
  public bool isInvincible = false;
  private bool isCooldown = false;

  [SerializeField] private float invincibilityCooldown = 10f; // Set the cooldown time in seconds

  // Start is called before the first frame update
  void Start()
  {
   
    imageCooldown.fillAmount = 0.0f;
  }

  // Update is called once per frame
  void Update()
  {
    if (player.Health < 30)
    {
      return;
    }
    if (Input.GetKeyDown(KeyCode.E) && player.Health >= 30 && !isCooldown)
    {
      ActivateInvincibility(player.invincibilityDuration);
      StartCoroutine(CooldownCoroutine());
    }
  }

  private IEnumerator InvincibilityCoroutine(float duration)
  {
    // Add visual/audio effects for invincibility if desired
    spriteRenderer.color = Color.green; // Set player color to indicate invincibility
    yield return new WaitForSeconds(duration);
    // Reset invincibility state
    isInvincible = false;
    spriteRenderer.color = Color.white; // Reset player color
  }

  private IEnumerator CooldownCoroutine()
  {
    isCooldown = true;
    float cooldownTimer = invincibilityCooldown;

    

    while (cooldownTimer > 0f)
    {

      imageCooldown.fillAmount = 1 - (cooldownTimer / invincibilityCooldown);
      yield return new WaitForSeconds(1f);
      cooldownTimer -= 1f;
    }

    
    imageCooldown.fillAmount = 0.0f;
    isCooldown = false;
  }

  public void ActivateInvincibility(float duration)
  {
    if (!isInvincible && !isCooldown)
    {
      isInvincible = true;
      StartCoroutine(InvincibilityCoroutine(duration));
    }
  }
}
