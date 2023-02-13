using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Container
{
    public ContainerCollidable collidable;
    public Container otherContainer;
    private bool open = false;
    private bool otherOpen = false;
    // Start is called before the first frame update

    void Start()
    {
        otherContainer = collidable.col.container;
    }

    // Update is called once per frame
    void Update()
    {
        otherContainer = collidable.col.container;
        
        if (Input.GetKey(KeyCode.I)) {
            if (!open)
            {
                open((item) => { });
                open = true;
            }
            else
            {
                close();
                open = false;
            }
        }
        if(otherContainer != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!otherOpen && !open)
                {
                    otherContainer.open((item) => addItem(item));
                    open((item) => otherContainer.addItem(item));
                    open = true;
                    otherOpen = true;
                }
                else if (otherContainer && open)
                {
                    otherContainer.close();
                    close();
                    open = false;
                    otherOpen = false;
                }
            }
        }
        else
        {
            if (open)
                close();
            if (otherOpen)
                otherContainer.close();
        }
       
    }
}
