using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject boxContainerRef;
    public GameObject box;
    public int size = 2;
    private ItemScript[] items;

    private void Awake()
    {
        items = new ItemScript[size];
    }


    public bool addItem(ItemScript item)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }
        return false;
    }

    public void moveItemToContainer(int index, Container nextContainer)
    {

        if (items[index] != null)
        {
            
            bool didRemove = nextContainer.addItem(items[index]);

            if(didRemove)
            {
                items[index] = null;
            }
        }
    }

    public void open(Action<ItemScript> onClickedItem)
    {
        
        List<Sprite> tmp = new List<Sprite>();
        foreach (ItemScript item in items)
        {
            tmp.Add(item.getIcon());
        }
        // boxContainerRef.SetActive(true);
        
        GameObject b = Instantiate<GameObject>(boxContainerRef);
        Debug.Log(b);
        b.GetComponent<ContainerBoxScript>().set(8, tmp, (i) => onClickedItem.Invoke(items[i]));
        box = b;
        
    }
    
    public void close()
    {
        Destroy(box);
    }



}
