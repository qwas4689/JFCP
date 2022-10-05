using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private float moveSpeed = 0.5f;

    private Transform _targetPosition;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // _targetPosition = ������� ��ȣ����

        if (/* AI�� �ൿ�� ��ĥ �� true*/ true)
        {
            MoveToNextItem(_targetPosition);
        }
    }

    // 
    private void MoveToNextItem(Transform NextItemPosition)
    {
        navMeshAgent.speed = moveSpeed;
        navMeshAgent.SetDestination(NextItemPosition.position);
    }

}
