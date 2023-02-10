using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public abstract class Colidable : MonoBehaviour
{

    
    public AbsColider colider;
    private List<AbsColider> areColidingWith = new List<AbsColider>();
    // Start is called before the first frame update
    private void Awake()
    {
       
        colider = GetColiderInstance(gameObject, areColidingWith);
        Debug.Log(gameObject.name);
    }

    private void Update()
    {
        foreach (var col in areColidingWith)
        {
            col.Accept(colider);
        }
    }

    public abstract AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith);

    public void OnCollisionEnter2D(Collision2D c)
    {
        //Debug.Log(gameObject.name + " is colding with " + c.collider.name);
        Colidable other = c.gameObject.GetComponent<Colidable>(); ;
        if (other != null)
        {
          
            other.colider.Accept(colider);
            areColidingWith.Add(other.colider);
        }
    }



    public void OnCollisionExit2D(Collision2D c)
    {
        //Debug.Log(gameObject.name + " stoped colding with " + c.collider.name);
        Colidable other = c.gameObject.GetComponent<Colidable>();
        if (other != null)
        {
            areColidingWith.Remove(other.colider);
        }
    }


}
