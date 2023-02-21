using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Colidable
{
    [SerializeField] DoorScript leadsTo;
    private bool isOpen = false;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new DoorCollider(go, leadsTo, (key) => { isOpen = true; key.destroyKey(); }, () => isOpen);
    }

    public void openDoor()
    {
        isOpen = true;
    }

 




    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
