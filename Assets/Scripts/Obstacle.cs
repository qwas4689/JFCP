using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, IBeatable
{
    public UnityEvent OnStappedByPlayer;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HitPlayer();
        }
    }

    public void HitPlayer()
    {
        OnStappedByPlayer.Invoke();
    }
}
