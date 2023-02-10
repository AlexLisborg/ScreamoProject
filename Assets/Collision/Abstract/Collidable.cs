using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public abstract class Colidable : MonoBehaviour
{

    
    private AbsColider colider;
    private List<AbsColider> areColidingWith = new List<AbsColider>();
    // Start is called before the first frame update

    private void Start()
    {
        colider = GetColiderInstance(gameObject, areColidingWith);
    }

    public abstract AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith);

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name);
    }


    public void OnCollisionStay(Collision c) {
        Debug.Log(gameObject.name + " is colding with " + c.collider.name);
        AbsColider other = c.gameObject.GetComponent<AbsColider>();
        if(other != null)
        {
            other.Accept(colider);

            if (!areColidingWith.Contains(other))
            {
                areColidingWith.Add(other);
            }
        }
    }

    private void OnCollisionExit(Collision c)
    {
        AbsColider other = c.gameObject.GetComponent<AbsColider>();
        if (other != null)
        {
            areColidingWith.Remove(other);
        }
    }


}
