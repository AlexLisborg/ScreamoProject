using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static InputManagerScript;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject keyRef;
    [SerializeField] private GameObject bandgeRef;
    [SerializeField] private GameObject boxContainerPrefab;
    [SerializeField] private GameObject pistolPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject batonPrefab;
    //[SerializeField] InputManagerScript inputManager;
    [SerializeField] private int hight;
    [SerializeField] private int with;
    [SerializeField] private PlayerScript player;
  
    private Container container;
    private ItemScript equipt;
    //private Action removeLockMouese0 = null;


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
        List<BulletScript> bullts = new List<BulletScript>();
        for (int i = 0; i < 5; i++)
        {
            bullts.Add(Instantiate(bulletPrefab).GetComponent<BulletScript>());
        }
        GameObject pistol = Instantiate(pistolPrefab);
        pistol.GetComponent<PistolScript>().setBullets(bullts);
        container.addItem(pistol.GetComponent<ItemScript>());
        container.addItem(Instantiate(bulletPrefab).GetComponent<ItemScript>());
        container.addItem(Instantiate(batonPrefab).GetComponent<ItemScript>());
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
        Debug.Log("toggel");
        if (equipt != null)
            equipt.Unequipt(player);
        if (equipt == item)
        {
            equipt.Unequipt(player);
            equipt = null;
           
        }
        else
        {
            equipt = item;
            equipt.Equipt(player);
        }
    }

    private void moveItem(Container from, Container to, ItemScript item)
    {
        bool didMove = from.moveItemToContainer(item, to);
        if(didMove && item == equipt)
        {
            equipt = null;
            Debug.Log("move item");
        }
    }

    public List<ItemType> getAllItemsOf<ItemType>() where ItemType : ItemScript
    {
        
        List<ItemScript> allItems = container.getItems();
        List<ItemType> typedItem = new List<ItemType>();
        foreach (ItemScript item in allItems)
        {
            if (item is ItemType)
            {
                typedItem.Add((ItemType)item);
            }
        }
        return typedItem;

    }


    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.Mouse0) && equipt != null && !container.getIsOpen())
        {
            if (container.contains(equipt))
            {
                if (equipt.isActivated())
                {
                    equipt.Deactivate(player);
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

               //removeLockMouese0 = inputManager.addAction(0, KeyCode.Mouse0, KeyEvent.KeyDown, () => { });
                container.open((item) => toggleEquiped(item), () => transform.position);
            }
            else
            {
                if(otherContainer != null) {
                    if (otherContainer.getIsOpen())
                    {
                        container.close();
                        //removeLockMouese0();
                    }
                }
                else
                {
                    container.close();
                    //removeLockMouese0();
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
                    //removeLockMouese0 = inputManager.addAction(0, KeyCode.Mouse0, KeyEvent.KeyDown, () => { });
                    container.open((item) => moveItem(container, otherContainer, item), () => { return transform.position + new Vector3(with + 0.5f, 0, 0); }) ;
                }
                else if (otherContainer.getIsOpen() && container.getIsOpen())
                {
                    otherContainer.close();
                    container.close();
                    //removeLockMouese0();
                }
            }
            
        }
       
    }
}
