using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployerAIInteraction : MonoBehaviour
{
    private Item _item;

    private void Start()
    {
        _item = GetComponent<Item>();
    }

    /// <summary>
    /// ���� Ÿ������ ����??? �̰Ÿ³���?
    /// </summary>
    private void MoveToTrack()
    {

    }

    ///// <summary>
    ///// ���� ������ ������ ��ġ�� �ű��
    ///// </summary>
    //private void MoveToOriginalPosition(Item item)
    //{
    //    item.gameObject.transform.position = _item.Data.OriginalPosition.position;
    //}

    private void EmployerPickUpItem()
    {

    }
}