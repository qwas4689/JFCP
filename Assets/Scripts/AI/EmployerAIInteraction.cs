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
    /// 다음 타겟으로 추적??? 이거맞나요?
    /// </summary>
    private void MoveToTrack()
    {

    }

    ///// <summary>
    ///// 뺏은 물건을 원래의 위치로 옮기기
    ///// </summary>
    //private void MoveToOriginalPosition(Item item)
    //{
    //    item.gameObject.transform.position = _item.Data.OriginalPosition.position;
    //}

    private void EmployerPickUpItem()
    {

    }
}