using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletContainer : Colidable
{
    public GameObject bandageRef;
    public GameObject boxContainerPrefab;
    private Container container;
    private ContainerCollider col;  

    public override AbsColider GetColiderInstance(GameObject go)
    {
        if(col == null)
        {
            col = new ContainerCollider(go, () => container);
        }
        return col;
    }



    private new void Awake()
    {
        base.Awake();
        container = new Container(3,3, boxContainerPrefab, Instantiate);
    }
    private void Start()
    {
        List<GameObject> list = new List<GameObject>();
        GameObject a = Instantiate(bandageRef);
     
        list.Add(Instantiate(bandageRef));
        list.Add(Instantiate(bandageRef));


        foreach (GameObject obj in list)
        {
            container.addItem(obj.GetComponent<ItemScript>());
        }
    }
}
