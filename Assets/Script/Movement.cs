using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;

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
  private float wallJumpingDuration = 0.4f;
  private Vector2 wallJumpingPower = new Vector2(8f, 16f);


  [Header("WallSLide")]
  private bool isWallSlide;
  private float WallSlidingSpeed = 2f;
  [SerializeField] private Transform wallCheck;
  [SerializeField] private LayerMask wallLayer;
  Rigidbody2D rb;

  void Start()
  {
    Gravity = new Vector2(0, -Physics2D.gravity.y);
    currentSpeed = speed;
    rb = GetComponent<Rigidbody2D>();
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

    }
    if (rb.velocity.y < 0)
    {
      rb.velocity -= Gravity * fallMultiplier * Time.deltaTime;
      anim.SetBool("Jump", false);
    }
    if (Input.GetMouseButtonDown(1) && canDash || Input.GetKeyDown(KeyCode.LeftShift))
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
    groundcheck = false;
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform" || col.gameObject.tag == "Spike" || col.gameObject.tag == "enemy")
    {
      groundcheck = true;
      speed = currentSpeed;
    }
  }
  void WallJump()
{
    if (wallJumpCounter > 0)
    {
        // Perform wall jump
        Vector2 jumpDirection = new Vector2(wallJumpingDirection * -transform.localScale.x, 1f);
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
  private IEnumerator Dash()
  {
    canDash = false;
    isDashing = true;
    float originalGravity = rb.gravityScale;
    rb.gravityScale = 0f;
    rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
    tr.emitting = true;
    yield return new WaitForSeconds(dashingTime);
    tr.emitting = false;
    rb.gravityScale = originalGravity;
    isDashing = false;
    yield return new WaitForSeconds(dashingCooldown);
    canDash = true;
  }


}
