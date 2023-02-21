using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    public GameObject keyRef;
    public GameObject bandgeRef;
    public GameObject boxContainerPrefab;
    public int hight;
    public int with;
    public PlayerScript player;
    private Container container;
    private ItemScript equipt;


    private void Awake()
    {
        container = new Container(with, hight, boxContainerPrefab, Instantiate);
    }

    private void Start()
    {
      
        for(int i = 0; i < 2; i++)
        {
            container.addItem(Instantiate(keyRef).GetComponent<ItemScript>());
        }
        container.addItem(Instantiate(bandgeRef).GetComponent<ItemScript>());
    }

 

    public int GetHeight()
    {
        return hight;
    }

    public Container GetInventory()
    {
        return container;
    } 

    private void toggleEquiped(ItemScript item)
    {
        if(equipt == item)
        {
            equipt = null;
        }
        else
        {
            equipt = item;
        }
    }

    private void moveItem(Container from, Container to, ItemScript item)
    {
        bool didMove = from.moveItemToContainer(item, to);
        if(didMove && item == equipt)
        {
            equipt = null;
        }
    }
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && equipt != null )
        {
            if (container.contains(equipt))
            {
                if (equipt.isActivated())
                {
                    equipt.Deactivate();
                }
                else
                {
                    equipt.Activate(player);
                }
            }
            else
            {
                equipt = null;
            }
            
        }


            //Debug.Log(GetComponent<PlayerCollidable>().col);
            Container otherContainer = GetComponent<PlayerCollidable>().col.GetContainerAvilabe();

        
        if (Input.GetKeyDown(KeyCode.I)) {
            if (!container.getIsOpen())
            {
                container.open((item) => toggleEquiped(item), () => transform.position);
            }
            else
            {
                if(otherContainer != null) {
                    if (otherContainer.getIsOpen())
                    {
                        container.close();
                    }
                }
                else
                {
                    container.close();
                }
            }
        }
        if(otherContainer != null)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!otherContainer.getIsOpen())
                {

                    otherContainer.open((item) => moveItem(otherContainer,container, item), () => transform.position);
                    container.open((item) => moveItem(container, otherContainer, item), () => { return transform.position + new Vector3(with + 0.5f, 0, 0); }) ;
                }
                else if (otherContainer.getIsOpen() && container.getIsOpen())
                {
                    otherContainer.close();
                    container.close();
                }
            }
            
        }
       
    }
}
