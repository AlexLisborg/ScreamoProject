using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject boxContainerRef;
    private GameObject box;
    public int size = 2;
    private ItemScript[] items;

    private void Awake()
    {
        items = new ItemScript[size];
    }


    public void addItem(ItemScript item)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
            }
        }
        
        
    }

    public void moveItemToContainer(int index, Container nextContainer)
    {

        if (items[index] != null)
        {
            ItemScript tmp = items[index];
            items[index] = null;
            nextContainer.addItem(tmp);
        }
    }

    public void open(Action<ItemScript> onClickedItem)
    {
        
        List<Sprite> tmp = new List<Sprite>();
        foreach (ItemScript item in items)
        {
            tmp.Add(item.getIcon());
        }
        box = Instantiate(boxContainerRef);
        box.GetComponent<ContainerBoxScript>().set(8, tmp, (i) => onClickedItem.Invoke(items[i]));
        
    }
    
    public void close()
    {
        Destroy(box);
    }



}
