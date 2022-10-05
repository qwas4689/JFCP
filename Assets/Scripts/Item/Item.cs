using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemState
{
    UNPACKED,
    PACKED,
    GRASPED,
    STORED,
    MAX
}

public class Item : MonoBehaviour
{
    public EItemState CurrentState { get; private set; }
    public ItemData Data;

    //private ItemManager _manager;
    private Rigidbody _rigidbody;
    private OVRGrabbable _grabbable;
    private bool _isPacked;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _grabbable = GetComponent<OVRGrabbable>();
        CurrentState = EItemState.UNPACKED;
        _isPacked = false;

        ItemManager.Instance.Items.Push(this);
    }

    // Heap 테스트 용
    //private void Start()
    //{
    //    int[] ints = { 4, 3, 2, 5, 1 };

    //    Heap.Heap<int> heap = new Heap.Heap<int>(compare);

    //    foreach(int num in ints)
    //    {
    //        heap.Push(num);
    //    }

    //    while(!heap.Empty())
    //    {
    //        Debug.Log(heap.Pop());
    //    }
    //}

    private bool compare(int left, int right)
    {
        return left >= right;
    }

    private void Update()
    {
        if(_grabbable.isGrabbed)
        {
            SetGrasped();
        }
        else
        {
            if (_isPacked)
            {
                CurrentState = EItemState.PACKED;
            }
            else
            {
                CurrentState = EItemState.UNPACKED;
            }
        }
    }

    public void SetPacked()
    {
        _isPacked = true;

        if (CurrentState == EItemState.UNPACKED)
        {
            CurrentState = EItemState.PACKED;
        }
    }

    public void SetUnPacked()
    {
        _isPacked = false;

        if (CurrentState == EItemState.PACKED)
        {
            CurrentState = EItemState.UNPACKED;
        }
    }

    public void SetGrasped()
    {
        CurrentState = EItemState.GRASPED;
    }

    public void SetStored()
    {
        CurrentState = EItemState.STORED;
    }
}
