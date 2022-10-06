using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructure.Heap;

public class ItemManager : GlobalInstance<ItemManager>
{
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
