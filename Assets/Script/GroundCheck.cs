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
        }
        // if(col.gameObject.tag == "Ground")
        // {
        //  Box.isTrigger = false;
        // }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Cap.isTrigger = false;
        }
        //  if(col.gameObject.tag == "Ground")
        // {
        //  Box.isTrigger = true ;
        // }
    }
}
