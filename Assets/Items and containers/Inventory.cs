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
            equipt.Unequipt();
        if (equipt == item)
        {
            equipt.Unequipt();
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
            PlayAudio(InventoryAudio.InventoryEvent.moveItem);
            equipt = null;
            Debug.Log("move item");
        }
    }

    private void nothing()
    {

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
                    equipt.Deactivate();
                }
                else
                {
                    equipt.Activate();
                }
            }
            else
            {
                equipt = null;
            }
            
        } else if(equipt == null)
        {
            Debug.Log("Equipped is null");
        }


            //Debug.Log(GetComponent<PlayerCollidable>().col);
            Container otherContainer = GetComponent<PlayerCollidable>().col.GetContainerAvilabe();

        
        if (Input.GetKeyDown(KeyCode.I)) {
            if (!container.getIsOpen())
            {

               //removeLockMouese0 = inputManager.addAction(0, KeyCode.Mouse0, KeyEvent.KeyDown, () => { });
                Debug.Log("1");
                PlayAudio(InventoryAudio.InventoryEvent.openInventory);
                //removeLockMouese0 = inputManager.addAction(0, KeyCode.Mouse0, KeyEvent.KeyDown, () => { });
                container.open((item) => toggleEquiped(item), () => transform.position);
            }
            else
            {
                if(otherContainer != null) {
                    if (otherContainer.getIsOpen())
                    {
                        Debug.Log("2");
                        PlayAudio(InventoryAudio.InventoryEvent.closeInventory);
                        container.close();
                        //removeLockMouese0();
                    }
                }
                else
                {
                    Debug.Log("3");
                    PlayAudio(InventoryAudio.InventoryEvent.closeInventory);
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

                    Debug.Log("4");
                    PlayAudio(InventoryAudio.InventoryEvent.openContainer);
                    otherContainer.open((item) => moveItem(otherContainer,container, item), () => transform.position);
                    //removeLockMouese0 = inputManager.addAction(0, KeyCode.Mouse0, KeyEvent.KeyDown, () => { });
                    container.open((item) => moveItem(container, otherContainer, item), () => { return transform.position + new Vector3(with + 0.5f, 0, 0); }) ;
                }
                else if (otherContainer.getIsOpen() && container.getIsOpen())
                {
                    Debug.Log("5");
                    PlayAudio(InventoryAudio.InventoryEvent.closeContainer);
                    otherContainer.close();
                    container.close();
                    //removeLockMouese0();
                }
            }
            
        }
       
    }

    // Checks if audio script is null before playing audio
    private void PlayAudio(InventoryAudio.InventoryEvent invEvent)
    {
        if (gameObject.GetComponent<InventoryAudio>() != null)
        {
            gameObject.GetComponent<InventoryAudio>().PlayAudio(invEvent);
        }
        else
        {
            Debug.Log("Scritp was null");
        }
    }
}
