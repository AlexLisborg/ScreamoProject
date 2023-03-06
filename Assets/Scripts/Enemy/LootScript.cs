using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LootScript : Colidable
{
    private ContainerCollider col;
    public GameObject boxContainerPrefab;
    private Container container;
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
        gameObject.GetComponent<AudioSource>().Play();
        container = new Container(3, 3, boxContainerPrefab, Instantiate);
    }
    public void addItems(List<GameObject> Items)
    {
        foreach (GameObject obj in Items)
        {
            GameObject instaGo = Instantiate(obj);
            ItemScript item = instaGo.GetComponent<ItemScript>();
            if(item != null)
            {
                container.addItem(item);
            }
            
        }
    }
}
