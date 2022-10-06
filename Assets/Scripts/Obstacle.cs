using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, IBeatable
{
    public static UnityEvent OnSteppedByPlayer;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HitPlayer();
        }
    }

    public void HitPlayer()
    {
        OnSteppedByPlayer.Invoke();
    }
}
