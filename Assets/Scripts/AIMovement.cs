using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{

    //protected AIInteraction _interaction;

    protected NavMeshAgent _agent;
    protected Transform _targetPosition;
    protected Item _nextItem;
    protected LayerMask _itemLayer = 1 << 3;
    protected void Awake()
    {

       // _interaction = GetComponent<AIInteraction>();

        _agent = GetComponent<NavMeshAgent>();

        _agent.isStopped = true;
        SetTarget();
    }

    protected virtual void SetTarget()
    {
        //_nextItem = _interaction.GetNextItem();
        _targetPosition = _nextItem.transform;
    }

    protected void StartTrack()
    {
        _agent.SetDestination(_targetPosition.position);
        _agent.isStopped = false;
    }

    protected virtual IEnumerator CheckTarget()
    {
        while (true)
        {
            SetTarget();
            yield return new WaitForSeconds(1);
        }
    }

    protected void FindTarget()
    {
        _agent.isStopped = true;
        Collider[] candidates = new Collider[5];
        Physics.OverlapSphereNonAlloc(transform.position, 10f, candidates, _itemLayer);
        
        foreach(Collider item in candidates)
        {
            if (_nextItem == item.GetComponent<Item>())
            {
                _targetPosition = item.transform;
                StartTrack();
                return;
            }
        }
    }
}
