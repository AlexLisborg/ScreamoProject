using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : Container
{
    public GameObject keyRef;
    private bool isOpen = false;
    private bool otherOpen = false;
    // Start is called before the first frame update

    private void Start()
    {
        List<GameObject> list = new List<GameObject>();
        list.Add(Instantiate(keyRef));
        list.Add(Instantiate(keyRef));
        list.Add(Instantiate(keyRef));


        foreach (GameObject obj in list)
        {
            addItem(obj.GetComponent<ItemScript>());
        }
    }
 

    // Update is called once per frame
    void Update()
    {
        Container otherContainer = GetComponent<PlayerCollidable>().col.containerAvilable;

        
        if (Input.GetKeyDown(KeyCode.I)) {
            
            if (!isOpen)
            {
          
                open((item) => { });
                isOpen = true;
            }
            else
            {
        
                close();
                isOpen = false;
            }
        }
        if(otherContainer != null)
        {

            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!otherOpen && !isOpen)
                {
                    otherContainer.open((item) => addItem(item));
                    open((item) => otherContainer.addItem(item));
                    isOpen = true;
                    otherOpen = true;
                }
                else if (otherContainer && isOpen)
                {
                    otherContainer.close();
                    close();
                    isOpen = false;
                    otherOpen = false;
                }
            }
        }
        else
        {
            if (isOpen)
                close();
            if (otherOpen)
                otherContainer.close();
        }
       
    }
}
