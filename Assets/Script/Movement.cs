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
    bool isDashing;
    Vector2 moveDirection;
    #endregion

    [Header("Dash Setting")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 0.7f;
    [SerializeField] float dashCooldown = 1f;

    

    Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
            if(Input.GetKeyDown(KeyCode.Space))
            { 
                if(groundcheck)
                    Jump(jumpboost);
            }
        moveDirection = new Vector2(horizontal,vertical).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector2(moveDirection.x*dashSpeed,moveDirection.y*dashSpeed); 
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

}
