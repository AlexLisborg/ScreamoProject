using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Container : MonoBehaviour
{
    private ItemScript[] items;

    private int with;

    private void Start()
    {
        
    }
    public void set(int with, int length)
    {
        items= new ItemScript[length];
    }

    public void addItem(ItemScript item)
    {
        for(int i =0; i<items.Length;i++)
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

    
}
