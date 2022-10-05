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

    protected abstract void OnFocusItem();

    protected abstract void OutFocusItem();

    protected abstract void PackItem();

    protected abstract void PickItem();

    protected abstract void DropItem();

    protected abstract void SelectTool();

    protected abstract void UseToolToItem();

}
