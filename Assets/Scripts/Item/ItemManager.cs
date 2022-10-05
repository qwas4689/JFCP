using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heap;

public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;

    public static ItemManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ItemManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            if(_instance != this)
            {
                Destroy(gameObject);
            }

            return;
        }
        _instance = GetComponent<ItemManager>();
    }


    public ItemHeap Items = new ItemHeap();
    // IsTarget == true�� ���� ������
    // ������ �켱 �� -> ������ �켱 (enum ��ġ �� ���� ���� ũ��)
    // ���ٸ� ���� �� -> ���ſ� ���� �켱
    

    private void SetOrder(Item item)
    {
        Items?.Remove(item);
    }

    private void SetOrder(int index)
    {
        Items?.Remove(index);
    }
}
