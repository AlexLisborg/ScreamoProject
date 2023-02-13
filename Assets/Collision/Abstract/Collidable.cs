using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public abstract class Colidable : MonoBehaviour
{

    
    public AbsColider colider;
    // Start is called before the first frame update
    private void Awake()
    {
        colider = GetColiderInstance(gameObject);
    }

    private void Update()
    {

    }

    public abstract AbsColider GetColiderInstance(GameObject go);

    public void OnCollisionEnter2D(Collision2D c)
    {
        //Debug.Log(gameObject.name + " is colding with " + c.collider.name);
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
            other.colider.AcceptEnter(colider);
        }
    }

    public void OnCollisionStay2D(Collision2D c)
    {
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
            other.colider.AcceptStay(colider);
        }
    }

    public void OnCollisionExit2D(Collision2D c)
    {
        //Debug.Log(gameObject.name + " stoped colding with " + c.collider.name);
        Colidable other = c.gameObject.GetComponent<Colidable>();
        if (other != null)
        {
            colider.AcceptExit(other.colider);
        }
    }


}
