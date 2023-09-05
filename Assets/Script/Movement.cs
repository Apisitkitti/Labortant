using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Public
    public float speed = 1f;
    public float jumpboost = 5f;
    public float forward = 5f;
    #endregion
    
    #region Private
    private float horizontal;
    private float vertical;
    private bool groundcheck;
    private bool canDash = true;
    bool isFacingRight =true;
    bool isDashing;
    
    #endregion

    #region SerrializeField
    [SerializeField] TrailRenderer tr;
    
    [Header("Dash Setting")]
    [SerializeField] private float dashingPower = 24f;
    [SerializeField]private float dashingTime =0.2f;
    [SerializeField]private float dashingCooldown = 1f;
    #endregion

    
    Rigidbody2D rb;

    void Start()
    {
        
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
            if(Input.GetKeyDown(KeyCode.Space))
            { 
                if(groundcheck)
                    Jump(jumpboost);
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
        if(col.gameObject.tag == "Ground")
        {
           groundcheck = true; 
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
