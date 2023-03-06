using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlaceable : Colidable
{
    public List<GameObject> Items;
    public GameObject boxContainerPrefab;
    private Container container;
    private ContainerCollider col;

    public override AbsColider GetColiderInstance(GameObject go)
    {
        if (col == null)
        {
            col = new ContainerCollider(go, () => container);
        }
        return col;
    }



    private new void Awake()
    {
        base.Awake();
        container = new Container(3, 3, boxContainerPrefab, Instantiate);
    }
    private void Start()
    {
        foreach (GameObject obj in Items)
        {
            container.addItem(obj.GetComponent<ItemScript>());
           
        }
        
    }
}
