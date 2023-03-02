using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DoorAudio;

public class InventoryAudio : Audio
{
    public AudioClip lootEnemy;
    public AudioClip openInventory;
    public AudioClip closeInventory;
    public AudioClip moveItem;
    public AudioClip destroyItem;
    public AudioClip lootItem;
    public AudioClip lootKey;
    public AudioClip useBandage;
    public AudioClip openContainer;
    public AudioClip closeContainer;

    public enum InventoryEvent
    {
        lootEnemy,
        addItem,
        addKey,
        openInventory,
        closeInventory,
        openContainer,
        closeContainer,
        useBandage,
        moveItem,
        destroyItem
    }

    public void PlayAudio(InventoryEvent invEvent)
    {
        switch (invEvent)
        {
            case InventoryEvent.lootEnemy:
                PlayAudio(lootEnemy);
                break;
            case InventoryEvent.addItem:
                PlayAudio(lootItem);    
                break;
            case InventoryEvent.addKey:
                PlayAudio(lootKey);
                break;
            case InventoryEvent.moveItem:
                PlayAudio(moveItem);
                break;
            case InventoryEvent.openInventory:
                PlayAudio(openInventory);
                break;
            case InventoryEvent.closeInventory:
                PlayAudio(closeInventory);
                break;  
            case InventoryEvent.openContainer:
                PlayAudio(openContainer);    
                break;
            case InventoryEvent.closeContainer:
                PlayAudio(closeContainer);
                break;
            case InventoryEvent.useBandage:
                PlayAudio(useBandage);
                break;
            case InventoryEvent.destroyItem:
                PlayAudio(destroyItem);
                break;
            default: break;
        }
    }
}
