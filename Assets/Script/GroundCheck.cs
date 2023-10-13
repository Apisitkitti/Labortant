using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D Cap;
    [SerializeField] BoxCollider2D Box;
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Cap.isTrigger = true;
            Box.isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Cap.isTrigger = false;
            Box.isTrigger = true;
        }
        
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Cap.isTrigger = false;
            Box.isTrigger = false;
        }
        
    }


    void OnCollisionExit2D(Collision2D col)
    {
      if(col.gameObject.tag == "Ground")
        {
          Box.isTrigger = true;
        }
    }
     void OnCollisionStay2D(Collision2D col)
    {
      if(col.gameObject.tag == "Ground")
        {
          Box.isTrigger = false;
        }
    }
   
    
}
