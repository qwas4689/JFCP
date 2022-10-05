using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> Inventory = new List<Item>();

    public void PushItemToInventory(Item item)
    {
        if(item != null)
        { 
            Inventory.Add(item);
        }
    }

    public Item PopItemFromInventory(Item item)
    {
        if(Inventory.Contains(item))
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
