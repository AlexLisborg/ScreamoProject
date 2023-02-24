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


 
    public void OnCollisionEnter2D(Collision2D c)
    {
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
            other.colider.AcceptEnter(colider);
            colider.AnyEnterCollision(other.colider);
        }
    }

    public void OnCollisionStay2D(Collision2D c)
    {
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
            other.colider.AcceptStay(colider);
            colider.AnyStayCollision(other.colider);
        }
    }

    public void OnCollisionExit2D(Collision2D c)
    {
        //Debug.Log(gameObject.name + " stoped colding with " + c.collider.name);
        Colidable other = c.gameObject.GetComponent<Colidable>();
        if (other != null)
        {
            other.colider.AcceptExit(colider);
            colider.AnyExitCollision(other.colider);
        }
    }


}
