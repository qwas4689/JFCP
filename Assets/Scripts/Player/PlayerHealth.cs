using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EPlayerState
{
    IDLE,
    WORKING,
    STEALING,
    DAMAGED,
    MAX
}


public class PlayerHealth : MonoBehaviour
{
   
    public EPlayerState CurrentState;
    public UnityEvent<Item> OnDamage = new UnityEvent<Item>();
    private PlayerInventory _inventory;
    private Item _lostItem;

    public void GotDamage()
    {
        // 우선 인벤토리의 처음 인덱스를 접근하는 것으로 함.
        if(_inventory.Inventory.Count != 0)
        {
            _lostItem = _inventory.Inventory[0];
        }

        OnDamage.Invoke(_lostItem);
        // 타겟이 있으면 타겟먼저

        // 타겟이 없으면 가치순으로

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AI"))
        {
            GotDamage();
        }
    }

    private void OnDisable()
    {
    }
}
