using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public abstract class Colidable : MonoBehaviour
{

    
    private AbsColider colider;
    // Start is called before the first frame update
    public void Awake()
    {
        colider = GetColiderInstance(gameObject);
    }



    public abstract AbsColider GetColiderInstance(GameObject go);


    private void Enter(Collider2D c)
    {
        //Debug.Log(gameObject.name + " collided with " + c.name);
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
            other.colider.AcceptEnter(colider);
            colider.AnyEnterCollision(other.colider);
        }
    }
    public void OnCollisionEnter2D(Collision2D c)
    {
        Enter(c.collider);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        Enter(c);
    }


    private void Stay(Collider2D c)
    {
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
            other.colider.AcceptStay(colider);
            colider.AnyStayCollision(other.colider);
        }
    }
    public void OnCollisionStay2D(Collision2D c)
    {
        Stay(c.collider);
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        Stay(c);
    }

    private void Exit(Collider2D c)
    {
       
        Colidable other = c.gameObject.GetComponent<Colidable>();
        if (other != null)
        {
            other.colider.AcceptExit(colider);
            colider.AnyExitCollision(other.colider);
        }
    }

    public void OnCollisionExit2D(Collision2D c)
    {
        Exit(c.collider);
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        Exit(c);
    }


}
