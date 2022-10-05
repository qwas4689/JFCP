using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _targetPosition;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


}
