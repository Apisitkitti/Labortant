using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Transform StartPoint;
    public Transform Endpoint;
    Vector2 targetpos;
    public float Speed =1.5f;
    
   
    void Start()
    {
         targetpos = Endpoint.position;
    }
    void Update()
    {
        if(Vector2.Distance(transform.position,StartPoint.position)<.1f)
        {
            targetpos = Endpoint.position;
        }
        if(Vector2.Distance(transform.position,Endpoint.position)<.1f)
        {
            targetpos = StartPoint.position;
        }
        transform.position = Vector2.MoveTowards(transform.position,targetpos,Speed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
    
   /* private void OnDrawGizmos() 
    {
        if(Platform != null && StartPoint != null && Endpoint != null)
        {
            Gizmos.DrawLine(Platform.transform.position,StartPoint.position);
            Gizmos.DrawLine(Platform.transform.position,Endpoint.position);
        }
    }*/
}
