using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : Worker
{
  
    [SerializeField]
    private Transform _rightHand;
    private PlayerHealth _playerHealth;
    private PlayerInventory _playerInventory;
    private Item _grapsedItem;
    private LayerMask InterativeLayer = 1 << 5;
    private float _interactDiastance = 5f;

    public UnityEvent Onpack = new UnityEvent();
    public UnityEvent OnUnPack = new UnityEvent();


    private void Start()
    {
        _playerInventory = GetComponent<PlayerInventory>();
        _playerHealth = GetComponent<PlayerHealth>();
        Item.OnGrabChanged -= PickAndDropItem;
        Item.OnGrabChanged += PickAndDropItem;
        Obstacle.OnSteppedByPlayer.RemoveListener(DroppedItemByObstacle);
        Obstacle.OnSteppedByPlayer.AddListener(DroppedItemByObstacle);
        Onpack.RemoveListener(PackItem);
        Onpack.AddListener(PackItem);
        OnUnPack.RemoveListener(UnPackItem);
        OnUnPack.AddListener(UnPackItem);
        _playerHealth.OnDamage.RemoveListener(DroppedItemByAI);
        _playerHealth.OnDamage.AddListener(DroppedItemByAI);
    }
   
    private void Update()
    {
        OnFocusItem();
    }

    protected override void OnFocusItem()
    {
        if (_grapsedItem != null)
        {
            return;
        }
       

        Ray ray = new Ray(_rightHand.position, _rightHand.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, _interactDiastance, InterativeLayer))
        {
            if (hit.collider.CompareTag("Item"))
            {
                _focusedItem = hit.collider.GetComponent<Item>();
            }
            else
            {
                OutFocusItem();
            }
        }
    }

    protected override void OutFocusItem()
    {
        _focusedItem = null;
    }

    protected override void PackItem()
    {
        _focusedItem.SetPacked();
    }

    private void UnPackItem()
    {
        _focusedItem.SetUnPacked();
    }

    private void PickAndDropItem(bool isGrapped)
    {
        if(isGrapped)
        {
            _grapsedItem = _focusedItem;
       
            OutFocusItem();
        }
        else
        {
            _grapsedItem = null;
        }

    }

    //protected override void DropItem()
    //{
    //    _grapsedItem = null;
    //}

    private void DroppedItemByObstacle()
    {
        //if(_grapsedItem != null)
        //{
        //    _grapsedItem.Gr
        //}

        int ranNum = Random.Range(0, _playerInventory.Inventory.Count);

        Item item = _playerInventory.Inventory[ranNum];

        _playerInventory.PopItemFromInventory(item);
    }

    private void DroppedItemByAI(Item item)
    {
        _playerInventory.PopItemFromInventory(item);
    }

    protected override void SelectTool()
    {

    }

    protected override void UseToolToItem()
    {

    }

    private void OnDisable()
    {
        Item.OnGrabChanged -= PickAndDropItem;
        Obstacle.OnSteppedByPlayer.RemoveListener(DroppedItemByObstacle);
        Onpack.RemoveListener(PackItem);
        OnUnPack.RemoveListener(UnPackItem);
        _playerHealth.OnDamage.RemoveListener(DroppedItemByAI);
    }
}
