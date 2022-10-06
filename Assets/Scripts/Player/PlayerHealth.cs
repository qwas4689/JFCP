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
        // �켱 �κ��丮�� ó� �ε����� ����ϴ� ����� ��.
        if(_inventory.Inventory.Count != 0)
        {
            _lostItem = _inventory.Inventory[0];
        }

        OnDamage.Invoke(_lostItem);
        // Ÿ���� ����� Ÿ�ٸ���

        // Ÿ���� ����� ��ġ�����

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
