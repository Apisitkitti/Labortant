using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MegaAttack : MonoBehaviour
{
    public Attack attackScript; // Reference to the Attack script
    public KeyCode megaAttackKey = KeyCode.E; // Define the key for mega attack
    public int buffDamage = 2;
    public bool isMegaAttackActive = false;
    bool isCooldown = false;
    bool isTimerRunning = false;
    float timer = 0f;
    public Player player; // Reference to the Player script
    public float cooldownDuration = 10f; // Cooldown duration in seconds
    public float timeToHitEnemy = 5f; // Time limit to hit an enemy
    public bool hasHealedDuringMegaAttack = false;
    private int originalDamage;
    
    [SerializeField] private Image imageCooldown;
    [SerializeField] private TMP_Text textCooldown;
    [SerializeField] private Image frame;

    void Start()
    {
        attackScript = GetComponentInChildren<Attack>();
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

        if (attackScript == null)
        {
            Debug.LogError("Attack script not found in children!");
        }

        Debug.Log("Damage Before = " + attackScript.damage);
        originalDamage = attackScript.damage;
    }

    void Update()
    {
        if (player.currentHealth < 50)
        {

            return;
        }

        if (Input.GetKeyDown(megaAttackKey) && !isCooldown)
        {
            ToggleMegaAttack();
        }

        if (isTimerRunning)
        {
            timer += Time.deltaTime;

            if (timer >= timeToHitEnemy)
            {
                isTimerRunning = false;

                if (isMegaAttackActive)
                {
                    DeactivateMegaAttack();
                }
            }
        }
    }

    void ToggleMegaAttack()
    {
        isMegaAttackActive = !isMegaAttackActive;

        if (isMegaAttackActive)
        {
            attackScript.damage *= buffDamage;
            Debug.Log("Mega Attack Activated! Damage multiplied.");
            Debug.Log("Damage now = " + attackScript.damage);
            StartCoroutine(StartCooldown());
            isTimerRunning = true;
            timer = 0f;
            // Reset the flag for healing during the mega attack
            hasHealedDuringMegaAttack = false;
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        float cooldownTimer = cooldownDuration;
        textCooldown.gameObject.SetActive(true);
        while (cooldownTimer > 0f)
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = 1 - (cooldownTimer / cooldownDuration);
            yield return new WaitForSeconds(1f);
            cooldownTimer -= 1f;
        }

        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
        isCooldown = false;
        isMegaAttackActive = false;
        Debug.Log("Cooldown Success =  " + attackScript.damage);
    }

    void DeactivateMegaAttack()
    {
        attackScript.damage = originalDamage;
        Debug.Log("Buff Time Out.");
        Debug.Log("Damage reset = " + attackScript.damage);
        isMegaAttackActive = false;
        isTimerRunning = false;
    }

    public void ResetDamageAttack()
    {
        attackScript.damage = originalDamage;
        Debug.Log("Mega Attack Deactivated! Damage returned to normal.");
        Debug.Log("Damage reset = " + attackScript.damage);
    }
}
