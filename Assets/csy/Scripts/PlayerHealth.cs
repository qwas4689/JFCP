using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerState
{
    Working,
    Stealing,
    Damaged,
}

public class PlayerHealth : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }
    public UnityEvent<Item> OnDamage = new UnityEvent<Item>();
    
    private Player

    public void GotDamage()
    {

    }
}
