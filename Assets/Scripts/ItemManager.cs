using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

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

    }

    private void SetOrder()
    {

    }

    private void SetOrder(Item item)
    {

    }
}
