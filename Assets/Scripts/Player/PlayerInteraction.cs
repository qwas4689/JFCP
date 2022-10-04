using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    private Item item;

    public UnityEvent<bool> OnPack = new UnityEvent<bool>();
    public UnityEvent OnPickUp = new UnityEvent();
    public UnityEvent<bool> OnUnPack = new UnityEvent<bool>();
    public UnityEvent OnDropItem = new UnityEvent();


    

    private void UnPackItem()
    {

    }

    public Item DropItem()
    {
        return item;
    }
    

    
}
