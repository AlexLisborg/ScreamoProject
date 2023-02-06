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
        colider = GetNewColiderInstance(gameObject, areColidingWith);
    }

    public abstract AbsColider GetNewColiderInstance(GameObject go, List<AbsColider> areColidingWith);


    public void OnCollisionStay(Collision c) {
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
