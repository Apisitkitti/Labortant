using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D Cap;

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Cap.isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Cap.isTrigger = false;
        }
    }
}
