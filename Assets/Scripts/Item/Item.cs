using System;
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

    public static event Action<bool> OnGrabChanged;

    private bool _isGrabbed;
    public bool IsGrabbed
    {
        get { return _isGrabbed; }
        set 
        {
            _isGrabbed = _grabbable.isGrabbed;
            OnGrabChanged.Invoke(_isGrabbed);
        }
    }

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
        _isGrabbed = false;

        ItemManager.Instance.Items.Push(this);
    }

    // Heap Å×½ºÆ® ¿ë
    //private void Start()
    //{
    //    int[] ints = { 4, 3, 2, 5, 1 };
    //    Heap.Heap<int> heap = new Heap.Heap<int>(compare);
    //
    //    foreach(int num in ints)
    //    {
    //        heap.Push(num);
    //    }
    //
    //    while(!heap.Empty())
    //    {
    //        Debug.Log(heap.Pop());
    //    }
    //}
    //
    //private bool compare(int left, int right)
    //{
    //    return left >= right;
    //}

    private void Update()
    {
        if(IsGrabbed != _grabbable.isGrabbed)
        {
            IsGrabbed = _grabbable.isGrabbed;
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
