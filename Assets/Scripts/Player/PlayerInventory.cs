using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heap;

public class PlayerInventory : MonoBehaviour
{
    public InventoryHeap Inventory = new InventoryHeap();

    public void PushItemToInventory(Item item)
    {
        if(item != null)
        { 
            Inventory.Push(item);
        }
    }

    public Item PopItemFromInventory(Item item)
    {
        if (item != null)
        {
            Inventory.Remove(item);
            return item;
        }
        else
        {
            return null;
        }
    }

    public void StoreItem(Item item)
    {
        item.GetComponent<Item>().SetStored();
    }
}
