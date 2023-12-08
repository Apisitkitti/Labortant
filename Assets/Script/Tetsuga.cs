using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tetsuga : MonoBehaviour
{
    [SerializeField] private GameObject WavePrefab;
    [SerializeField] private Transform attackpo;
    [SerializeField] private Image imageCooldown;
    [SerializeField] private Image frame;
    [SerializeField] private Player player;
    [SerializeField] private Animator anim;
    private bool isCooldown = false;
    [SerializeField] private float WaveCooldown = 10f;

    void Start()
    {
        imageCooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        if(player.Health < 50)
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
        anim.SetTrigger("blood_trig");
        // Instantiate the wave prefab
        Instantiate(WavePrefab, attackpo.position, Quaternion.identity);
    }

    private IEnumerator CooldownCoroutine()
    {
        isCooldown = true;
        float cooldownTimer = WaveCooldown;
    

        while (cooldownTimer > 0f)
        {
            imageCooldown.fillAmount = 1 - (cooldownTimer / WaveCooldown);
            yield return new WaitForSeconds(1f);
            cooldownTimer -= 1f;
        }
        imageCooldown.fillAmount = 0.0f;
        isCooldown = false;
    }
}
