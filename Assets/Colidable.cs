using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Colidable : MonoBehaviour 
{
    [SerializeField]
    private AbsColider colider;
    // Start is called before the first frame update
    void Start()
    {
        colider.setParent(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision c) {
        AbsColider other = c.gameObject.GetComponent<AbsColider>();
        if(other != null)
        {
            other.Accept(colider);
        }
    }

    
}
