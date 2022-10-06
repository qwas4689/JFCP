using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructure.Heap;

public class ItemManager : GlobalInstance<ItemManager>
{
    public ItemHeap Items = new ItemHeap();
    // IsTarget == true면 가장 마지막
    // 사이즈 우선 비교 -> 작으면 우선 (enum 수치 상 작을 수록 크다)
    // 같다면 무게 비교 -> 무거울 수록 우선

    private void SetOrder(Item item)
    {
        Items?.Remove(item);
    }

    private void SetOrder(int index)
    {
        Items?.Remove(index);
    }
}
