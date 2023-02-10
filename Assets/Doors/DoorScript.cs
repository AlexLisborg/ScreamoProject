using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField]
    public DoorScript leadsTo;
    [SerializeField]
    public DoorColidable colidable;
    private DoorCollider col;
 

    public void reciveDoor(DoorCollider doorCollider)
    {
        col = doorCollider;
        col.set(leadsTo);
    }

    void Start()
    {
        col = colidable.col;
        if(col !=  null)
            col.set(leadsTo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
