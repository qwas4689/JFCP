using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = GetComponent<PlayerInventory>();
    }
    public Item DropItem(Item item)
    {
        return _playerInventory.PopItemFromInventory(item);
    }
    void UnPackItem()
    {
        //item.GetComponent<Item>().SetUnPacked();
    }
}
