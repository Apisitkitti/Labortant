using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   #region Public
    public float speed = 1.5f;
    public float jumpboost = 5f;
    public float forward = 5f;
    public float invincibilityDuration = 5f;
    #endregion  

    
    #region Private
    private float horizontal;
    private float vertical;
    private bool groundcheck;
    private int jump =0;
   
    Vector2 Gravity;
    private bool canDash = true;
    bool isFacingRight =true;
    bool isDashing;
    float currentSpeed = 0.5f;
    #endregion
    
    #region SerrializeField
    [SerializeField] TrailRenderer tr;
    [SerializeField] float fallMultiplier;
   
    [Header("Dash Setting")]
    [SerializeField] private float dashingPower = 24f;
    [SerializeField]private float dashingTime =0.2f;
    [SerializeField]private float dashingCooldown = 1f;
    #endregion
    Rigidbody2D rb;

    void Start()
    {
        Gravity = new Vector2(0,-Physics2D.gravity.y);
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

            if(isDashing)
            {
                return;
            }
            if(Input.GetKeyDown(KeyCode.Space)&&groundcheck)
            { 
                Jump(jumpboost);
            }
            if(rb.velocity.y<0)
            {
                rb.velocity -= Gravity*fallMultiplier*Time.deltaTime;
            }
            if(Input.GetMouseButtonDown(1)&& canDash)
            {
                StartCoroutine(Dash());
                Debug.Log("dash");
            }

            Flip();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal*speed*Time.deltaTime,rb.velocity.y);
      
    }

    void Jump(float jumpboost)
    {
        
        rb.AddForce(Vector2.up*jumpboost);
        groundcheck = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform" || col.gameObject.tag == "Spike")
        {
           groundcheck = true; 
           speed = currentSpeed;
        }
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
        rb.velocity = new Vector2(transform.localScale.x*dashingPower,0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
  

}
