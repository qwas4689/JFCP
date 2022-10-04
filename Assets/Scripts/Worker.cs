using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Worker : MonoBehaviour
{
    private PlayerInteraction playerInteraction;


    [SerializeField]
    private Item _pickedItem;

    protected GameObject PickedItemGameObject;

    private Item _focusedItem;

    protected Tool SelectedTool;

    private void Start()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    protected void OnFocusItem()
    {

    }
    
    protected void OutFocusItem()
    {

    }

    protected void PackItem()
    {

    }
    protected void PickItem()
    {

    }
    protected void DropItem()
    {

    }
    protected void SelectTool()
    {

    }
    protected void UseToolToItem()
    {

    }

}
