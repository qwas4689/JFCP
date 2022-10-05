using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private AIInteraction _interaction;
    private NavMeshAgent _agent;
    private Transform _targetPosition;
    private Item _nextItem;
    private LayerMask _itemLayer = 1 << 3;
    private void Awake()
    {
        _interaction = GetComponent<AIInteraction>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void SetTarget()
    {
        //_nextItem = _interaction.GetNextItem();
        _targetPosition = _nextItem.Data.OriginalPosition;
    }

    private void FindTarget()
    {
        Collider[] candidates = new Collider[5];
        Physics.OverlapSphereNonAlloc(transform.position, 10f, candidates, _itemLayer);
        foreach(Collider item in candidates)
        {

        }
    }
}
