using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
  #region Public
  public float speed = 1.5f;
  public float jumpboost = 5f;
  public float forward = 5f;
  public Animator anim;


  #endregion


  #region Private
  private float horizontal;
  private float vertical;
  private bool groundcheck;
  private int jump = 0;
  private bool isWallSliding;


  Vector2 Gravity;
  private bool canDash = true;
  bool isFacingRight = true;
  bool isDashing;
  float currentSpeed = 0.5f;
  #endregion

  #region WallJump
  private bool isTouchingWall;
  private float wallJumpTime = 0.2f;
  private float wallJumpCounter;
  [SerializeField] private float wallJumpCooldown = 1f;
  #endregion


  #region SerrializeField
  [SerializeField] TrailRenderer tr;
  [SerializeField] float fallMultiplier;

  [Header("Dash Setting")]
  [SerializeField] private float dashingPower = 24f;
  [SerializeField] private float dashingTime = 0.2f;
  [SerializeField] private float dashingCooldown = 1f;
  #endregion
  [Header("WallJump")]
  private bool isWallJump;
  private float wallJumpingDirection;
  private float wallJumpingTime = 0.2f;
  private float wallJumpingCounter;
  private bool isCooldown = false;

  private float wallJumpingDuration = 0.4f;
  [SerializeField] private Vector2 wallJumpingPower = new Vector2(8f, 16f);
  [SerializeField] private Image imageCooldown;
  [SerializeField] private Image frame;
  [SerializeField] private Image dashCooldownFill;



  [Header("WallSLide")]
  [SerializeField] private Transform wallCheck;
  [SerializeField] private LayerMask wallLayer;
  Rigidbody2D rb;

  void Start()
  {
    Gravity = new Vector2(0, -Physics2D.gravity.y);
    currentSpeed = speed;
    rb = GetComponent<Rigidbody2D>();
    dashCooldownFill.fillAmount = 0.0f;
  }
  void Update()
  {
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");

    if (isDashing)
    {
      return;
    }
    if (horizontal > 0 || horizontal < 0)
    {
      anim.SetBool("run", true);
    }
    else if (horizontal == 0)
    {
      anim.SetBool("run", false);
    }
    if (Input.GetKeyDown(KeyCode.Space) && groundcheck)
    {
      Jump(jumpboost);
    }
    if (groundcheck)
    {
      anim.SetBool("Jump", false);
      anim.SetBool("fall",false);

    }
    if (rb.velocity.y < 0)
    {
      rb.velocity -= Gravity * fallMultiplier * Time.deltaTime;
      anim.SetBool("Jump", false);
      anim.SetBool("fall",true);
    }
    if (Input.GetMouseButtonDown(1) && canDash || Input.GetKeyDown(KeyCode.LeftShift) && canDash)
    {
      StartCoroutine(Dash());
      Debug.Log("dash");
    }
    isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);

    if (isTouchingWall && !groundcheck && !isDashing)
    {
      wallJumpCounter = wallJumpTime;

      if (Input.GetKeyDown(KeyCode.Space))
      {
        WallJump();
      }
    }
    if (wallJumpCounter > 0)
    {
      wallJumpCounter -= Time.deltaTime;
    }
    if (isTouchingWall && rb.velocity.y < 0 && !groundcheck && !isDashing)
    {
      isWallSliding = true;
      anim.SetBool("Jump", false);
    }
    else
    {
      isWallSliding = false;
    }

    // Handle wall sliding effect
    if (isWallSliding)
    {
      // Apply a custom sliding behavior here, e.g., reduce falling speed
      rb.velocity = new Vector2(rb.velocity.x, -1f);
    }
    Flip();


  }

  // Update is called once per frame
  void FixedUpdate()
  {

    if (isDashing)
    {
      return;
    }
    rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);

  }

  void Jump(float jumpboost)
  {

    rb.AddForce(Vector2.up * jumpboost);
    anim.SetBool("Jump", true);
    anim.SetBool("fall",false);
    groundcheck = false;
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform" || col.gameObject.tag == "Trap" || col.gameObject.tag == "enemy")
    {
      groundcheck = true;
      speed = currentSpeed;
    }
  }
  void WallJump()
  {
    if (wallJumpCounter > 0)
    {
      // Determine the direction of the wall jump based on player's facing direction
      wallJumpingDirection = isFacingRight ? -1f : 1f;

      // Perform wall jump
      Vector2 jumpDirection = new Vector2(wallJumpingDirection * transform.localScale.x, 1f);
      rb.velocity = wallJumpingPower * jumpDirection;
      anim.SetBool("Jump", true);
      groundcheck = false;

      // Apply cooldown to wall jump
      wallJumpCounter = 0;
      StartCoroutine(WallJumpCooldown());
    }
  }

  private IEnumerator WallJumpCooldown()
  {
    yield return new WaitForSeconds(wallJumpCooldown);
    wallJumpCounter = wallJumpTime;
  }
  private void Flip()
  {
    if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    {
      Vector3 localScale = transform.localScale;
      isFacingRight = !isFacingRight;
      localScale.x *= -1f;
      transform.localScale = localScale;
    }
  }
  private IEnumerator DashCooldown()
{
    isCooldown = true;
    float cooldownTimer = dashingCooldown;

    while (cooldownTimer > 0f)
    {
        // Update UI elements during cooldown
        dashCooldownFill.fillAmount = 1 - (cooldownTimer / dashingCooldown);

        yield return new WaitForSeconds(1f);
        cooldownTimer -= 1f;
    }

    // Reset UI elements when cooldown is complete
    dashCooldownFill.fillAmount = 0.0f;
    isCooldown = false;  // Corrected line to set isCooldown to false after the cooldown period
}

private IEnumerator Dash()
{
    if (!isCooldown)  // Added a check to see if there is no cooldown
    {
        canDash = false;
        isDashing = true;
        anim.SetBool("dash", true);

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;

        // Start dash cooldown coroutine
        StartCoroutine(DashCooldown());

        yield return new WaitForSeconds(dashingTime);

        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        anim.SetBool("dash", false);

        // No need to yield for dashingCooldown here
        canDash = true;
    }
}



}
