using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorScript : Colidable
{
    [SerializeField] DoorScript leadsTo;
    [SerializeField] private bool isOpen = true;
    [SerializeField] private Transform spawnOffset;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new DoorCollider(go, leadsTo, (key) => { isOpen = true; key.destroyKey(); }, () => isOpen, spawnOffset.position);
    }

    public void openDoor()
    {
        isOpen = true;
    }

    public Vector3 spawnPosition()
    {
        return spawnOffset.position;
    }

 




    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
