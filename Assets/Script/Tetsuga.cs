using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tetsuga : MonoBehaviour
{
    [SerializeField] private GameObject WavePrefab;
    [SerializeField] private Transform attackpo;
    [SerializeField] private Image imageCooldown;
    [SerializeField] private TMP_Text textCooldown;
    [SerializeField] private Image frame;
    [SerializeField] private Player player;
    private bool isCooldown = false;
    [SerializeField] private float WaveCooldown = 10f;

    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        if(player.Health < 80)
        {
          return;
        }
        if (Input.GetKeyDown(KeyCode.R) && !isCooldown)
        {
            PerformWaveAttack();
            StartCoroutine(CooldownCoroutine());
        }
    }

    public void PerformWaveAttack()
    {
        // Instantiate the wave prefab
        Instantiate(WavePrefab, attackpo.position, Quaternion.identity);
    }

    private IEnumerator CooldownCoroutine()
    {
        isCooldown = true;
        float cooldownTimer = WaveCooldown;

        textCooldown.gameObject.SetActive(true);

        while (cooldownTimer > 0f)
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = 1 - (cooldownTimer / WaveCooldown);
            yield return new WaitForSeconds(1f);
            cooldownTimer -= 1f;
        }

        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
        isCooldown = false;
    }
}
