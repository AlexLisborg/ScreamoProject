using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;


public class Container 
{
    private GameObject box; 
    private List<ItemScript> items = new List<ItemScript>();

    private int size;
    private bool isOpen = false;

    public Container(int with, int hight, GameObject boxContainerRef, Func<GameObject, GameObject> Instantiate)
    {
        this.size = with * hight;
        this.box = Instantiate(boxContainerRef);
        box.GetComponent<ContainerBoxScript>().set(with, hight);
    }

 

    public bool getIsOpen()
    {
        return isOpen;
    }



    public bool addItem(ItemScript item)
    {

       if(items.Count < size)
       {
            items.Add(item);
            box.GetComponent<ContainerBoxScript>().addNewIcon(item.getIcon());
            return true;
       }
       return false;
    }

    public bool moveItemToContainer(ItemScript item, Container nextContainer)
    {

        if (items.Contains(item)) 
        {
            int index = items.IndexOf(item);
            items.Remove(item);
            bool didAdd = nextContainer.addItem(item);
            if(!didAdd)
            {
                items.Insert(index, item);
            }
            else
            {
                box.GetComponent<ContainerBoxScript>().removeIcon(index);
            }
            return didAdd;
        }
        return false;
    }

    public void open(Action<ItemScript> onClickedItem, Func<Vector3> position)
    {
        if (!isOpen)
        {

            isOpen = true;
            ContainerBoxScript cbs = box.GetComponent<ContainerBoxScript>();
            cbs.show(position);
            box.GetComponent<ContainerBoxScript>().setOnwhenClicked((index) => onClickedItem(items[index]));
            
        }
        
    }
    
    public void close()
    {
        isOpen = false;
        box.GetComponent<ContainerBoxScript>().hide();    
    }



}
